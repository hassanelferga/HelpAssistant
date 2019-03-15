
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpAssistant.Api.Models;
using HelpAssistant.Api.DAL;
using HelpAssistant.Api.Web.Utils;
using System.Data.SqlClient;

namespace HelpAssistant.Api.Web.Controllers
{  
    [RoutePrefix("api/user")]
    public class UserManagerController : ApiController
    {
        // Sign up or register
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage SignUp(RegisterModel user)
        {
            user.Password = Crypto.HashString(user.Password);
            string errorMessage;
            long userID;
            int status = UserManager.Register(user, out errorMessage, out userID);
            if(status == 0 || status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, errorMessage);
            }
            else
            {
                var userObject = new
                {
                    userID = userID
                };
                return Request.CreateResponse(HttpStatusCode.OK,  userObject);
            }
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(RegisterModel modify)
        {
            long userID = UserManager.Update(modify);

            return Ok(userID);  
        }

        [Route("Emergency")]
        [HttpPost]
        public IHttpActionResult Emergency(EmergencyModel contact)
        {
            int userID = SetupContacts.Emergency(contact);
            return Ok(userID);
        }

        [Route("getUser")]
        [HttpGet]
        public IHttpActionResult GetUser(long userID)
        {
            UserModel user = UserManager.GetUser(userID);
            return Ok(user);
        }

        [Route("signIn")]
        [HttpPost]
        public HttpResponseMessage SignIn(UserModel user)
        {
            // UserModel user = new UserModel() { UserName = userName, UserPassword = password };

            UserModel dbUser = UserManager.SignIn(user.UserName, user.Email);
            if(dbUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User does not exists. Please check your information.");
            }
            else if(!dbUser.IsActive)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User account is not active, please contact the administrator");
            }
            else
            {
                string incomingPassword = Crypto.HashString(user.UserPassword);
                if(dbUser.UserPassword == incomingPassword)
                {
                    dbUser.UserPassword = string.Empty;
                    return Request.CreateResponse(HttpStatusCode.OK, dbUser);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid username/email or password.");
                }
            }
        }

        [Route("deleteUser")]
        [HttpPost]
        public IHttpActionResult DeleteUser(RegisterModel Delete)
        {
            int UserID = UserManager.DeleteUser(Delete);
            return Ok(UserID);
        }
        [Route("ForgetPassword")]
        [HttpPost]
        public IHttpActionResult ForgotPassword(UserModel User)
        {
            string ErrorMsg = ForgetPassword.ForgotPassword(User);
            return Ok(ErrorMsg);
        }

        [Route("UpdatePassword")]
        [HttpPost]
        public IHttpActionResult UpdatePassword(ForgetPassswordModel UpdatePassword)
        {
            string ErrorMsg = ForgetPassword.UpdatePassword(UpdatePassword);
            return Ok(ErrorMsg);
        }
       
    }
}





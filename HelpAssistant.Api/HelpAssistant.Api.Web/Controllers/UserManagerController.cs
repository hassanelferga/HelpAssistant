
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
        public IHttpActionResult SignUp(RegisterModel user)
        {
            user.Password = Crypto.HashString(user.Password);
            long userID = UserManager.Register(user);
            return Ok(userID);
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(RegisterModel modify)
        {
            long userID = UserManager.Update(modify);

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
        public IHttpActionResult SignIn(string userName, string password)
        {
            UserModel user = new UserModel() { UserName = userName, UserPassword = password };
            int UserId = UserManager.SignIn(user);
            return Ok(UserId);
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





﻿
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
using System.Collections.Specialized;

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
            string code;
            int status = UserManager.Register(user, out errorMessage, out userID, out  code);
            if (status == 0 || status == -1)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, errorMessage);
            }
            else
            {
                // Send Email to user
                // Make Async in new Task
                string message = EmailFormatter.FormatNewUser(user.FirstName, code);
                bool isSent = EmailSender.SendEmail(user.Email, "Activate Your Account", message);
                var userObject = new
                {
                    userID = userID
                };
                return Request.CreateResponse(HttpStatusCode.OK, userObject);
            }
        }

        [Route("activateuser")]
        [HttpGet]
        public HttpResponseMessage ActivateUser(string code)
        {
            var resposne = Request.CreateResponse(HttpStatusCode.Found);
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            try
            {
                bool isDone = UserManager.ActivateUser(code);
                if (isDone)
                {
                    resposne.Headers.Location = new Uri(baseUrl + "/EmailTemplates/success.html");
                }
                else
                    resposne.Headers.Location = new Uri(baseUrl + "/EmailTemplates/error.html");
            }
            catch (Exception ex)
            {
                resposne.Headers.Location = new Uri(baseUrl + "/EmailTemplates/error.html");
            }
            return resposne;
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(RegisterModel modify)
        {
            
            string updatePassword = Crypto.HashString(modify.Password);
            modify.Password = updatePassword ;
            long userID = UserManager.Update(modify);
            return Ok(userID);  
        }

        [Route("Emergency")]
        [HttpPost]
        public IHttpActionResult Emergency(EmergencyModel model)
        {
            // Contactnate the number in the list and make them as string in the following format
            // string number = "number1,number2, number3"
            bool isDone = SetupContacts.Emergency(model.UserID, model.Numbers, model.Message);
            return Ok(isDone);
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

        [Route("smsHelper")]
        [HttpPost]
        public IHttpActionResult smsHelper(EmergencyModel sms)
        {
            List<EmergencyModel> list = UserManager.smsHelper(sms.UserID);
            foreach (EmergencyModel model in list)
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
             { "phone", model.Numbers },
             { "message", model.Message },
             { "key", "textbelt" } });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                }
            }
            return Ok("Success");
        }


        //[Route("Activate")]
        //[HttpGet]
        //public IHttpActionResult Activate(string activationCode)
        //{
        //    // Get user id by code
        //    // Update user table and set is active to true
        //    // Redirect user to Html Page with Success message
        //    Uri redirect = new Uri("http://127.0.0.1/Html/success.html");
        //    return Redirect(redirect);
        //}

       
    }
}





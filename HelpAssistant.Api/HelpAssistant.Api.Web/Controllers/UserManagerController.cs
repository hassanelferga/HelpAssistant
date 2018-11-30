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

        //there is an Error in postman (Exeption Error)
        [Route("getUser")]
        [HttpGet]
        public IHttpActionResult GetUser(long userID )
        {
            UserModel user = UserManager.GetUser(userID);
            return Ok( user);
        }
        //there is an Error in postman (Exeption Error)
        [Route("signIn")]
        [HttpPost]
        public IHttpActionResult SignIn(UserModel User)
        {
            int UserId = UserManager.SignIn(User);
            return Ok(UserId);
        }

       
    }
}

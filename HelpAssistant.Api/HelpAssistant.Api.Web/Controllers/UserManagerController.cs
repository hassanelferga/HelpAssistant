using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpAssistant.Api.Models;
using HelpAssistant.Api.DAL;
using HelpAssistant.Api.Web.Utils;

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
    }
}

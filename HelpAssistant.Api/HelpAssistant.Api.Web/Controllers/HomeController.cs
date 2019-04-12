using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpAssistant.Api.Models;
using HelpAssistant.Api.DAL;
using HelpAssistant.Api.Web.Utils;
using System.Net;
using System.Collections.Specialized;

namespace HelpAssistant.Api.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          /*  using (WebClient client = new WebClient())
            {
                byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
             { "phone", "+201067561051" },
             { "message", "Hello world" },
             { "key", "textbelt" },
  });
  
                string result = System.Text.Encoding.UTF8.GetString(response);
            }*/

            /*// Test Hashing
            string samplePassword = "test";
            string hashedPassword = Crypto.HashString(samplePassword);
            // Create User
            */


            /*
                       RegisterModel user = new RegisterModel();
                       user.FirstName = "Ali";
                       user.LastName = "Moahmed Ragb";
                       user.UserName = "hassanibrahim";
                       user.Email = "abc@abc.com";
                       user.Password = "Password";
                       user.PhoneNumber = "010888333";

                       long userId = UserManager.Register(user);

                    */


            //Update User

            /*
            RegisterModel update = new RegisterModel();
            update.UserID = 3;
            update.FirstName = "Zaki";
            update.LastName = "";
            update.PhoneNumber = "";
            update.Password = "";


            int userId = UserManager.Update(update);

    */
            /*   UserModel Get = new UserModel();
               Get.UserID = 4;
               */

            // Test Send Email
         //   bool isSent = EmailSender.SendEmail("mibrahim_elferga@hotmail.com", "Test From API", "<h1>Hello From my API</h1>");
         
            ViewBag.Title = "Home Page";

            return View();
        }

    }
}

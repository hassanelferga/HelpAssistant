using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace HelpAssistant.Api.Web.Utils
{
    public static class EmailFormatter
    {
        public static string FormatNewUser(string userName, string code)
        {
            try
            {
                string activationUrl = ConfigurationManager.AppSettings["ActiveUrl"] + code;
                string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplates") + "/NewUser.html";
                string htmlStr = File.ReadAllText(filePath);
                string htmlMessage = htmlStr.Replace("__UserName__", userName)
                    .Replace("__link__", activationUrl);
                return htmlMessage;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
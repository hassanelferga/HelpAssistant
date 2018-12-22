using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HelpAssistant.Api.Web
{
    public static class AppSettings
    {
        public static string SmtpServer
        {
            get
            {
                return ConfigurationManager.AppSettings["SmptServer"].ToString();
            }
        }

        public static int Port
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            }
        }

        public static string FromEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["FromEmail"].ToString();
            }
        }

        public static string FromEmailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            }
        }
    }
}
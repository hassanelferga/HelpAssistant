using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAssistant.Api.DAL
{
    public static class AppSetings
    {
        public static string DbConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["HelpAssistantCon"].ToString();
            }
        }
    }
}

﻿using System.Web;
using System.Web.Mvc;

namespace HelpAssistant.Api.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

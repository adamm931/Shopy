﻿using Shopy.Admin.Filters;
using System.Web.Mvc;

namespace Shopy.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionFilter());
        }
    }
}

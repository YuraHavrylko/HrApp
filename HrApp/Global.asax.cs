﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HrApp
{
    using HrApp.App_Start;
    using HrApp.Infrastructure;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Implement dependency injection
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

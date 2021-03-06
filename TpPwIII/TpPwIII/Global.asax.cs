﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TpPwIII
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["ID"] = String.Empty;
            Session["Email"] = String.Empty;
            Session["Contrasenia"] = String.Empty;
            Session["Controller"] = String.Empty;
            Session["Action"] = String.Empty;
            Session["IdCarpeta"] = String.Empty;
            Session["IdTarea"] = String.Empty;
        }
    }
}

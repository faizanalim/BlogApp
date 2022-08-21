using BlogApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogApp
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

        //void Session_Start(object sender, EventArgs e)
        //{
        //    string myself = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //    string me = User.Identity.Name;

        //}
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "LoggedUserName")
            {
                HttpContext current = HttpContext.Current;
                if (current != null && current.Session != null && current.Session.Count > 0 && Session["Id"] != null)
                {
                    return context.Session["Id"].ToString();
                }
                return null;
            }
            return base.GetVaryByCustomString(context, custom);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // Session is Available here
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null && context.Session.Count>0 && Session["Id"] != null)
            {
                context.Session["Id"] = context.Session["Id"].ToString();
            }

            //HttpContext context = HttpContext.Current;
            //string test = context.Session["foo"].ToString();
        }

    }
}

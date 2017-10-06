using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AplicacaoLoteria
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("{*allsefaz}", new { allsefaz = @".*/sefaz\.axd(\?.*)?" });
            //routes.MapRoute(
            //    "Default", // Route name
            //    "{Controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Loteria", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}

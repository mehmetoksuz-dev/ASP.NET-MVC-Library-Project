using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
                // In normally, here i set controller = "Category" and same action.
            );

            routes.MapRoute( // localhost:asdasd/asdasdasd/asdasd/asdasd gibi olursa
                name: "PageNotFound",
                url: "{*url}",
                new { controller = "Error", action = "PageNotFound" }
            );

        }
    }
}

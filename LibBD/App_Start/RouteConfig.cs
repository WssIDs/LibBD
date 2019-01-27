using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibBD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //  name: "Authors",
            //  url: "{controller}",
            //  defaults: new
            //  {
            //      controller = "Author",
            //      action = "Index",
            //      page = 1,
            //      group = (string)null
            //  });
            routes.MapRoute(
            name: "AuthorsPage",
            url: "Author/page{page}",
            defaults: new
            {
                controller = "Author",
                action = "Index",
                group = (string)null
            },
            constraints: new { page = @"\d+" });
            routes.MapRoute(
            name: "AuthorsGroup",
            url: "Author/{group}",
            defaults: new
            {
                controller = "Author",
                action = "Index",
                page = 1
            });

            routes.MapRoute(
            name: "AuthorsGroupPage",
            url: "Author/{group}/page{page}",
            defaults: new
            {
                controller = "Author",
                action = "Index"
            },
            constraints: new
            {
                page = @"\d+"
            });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

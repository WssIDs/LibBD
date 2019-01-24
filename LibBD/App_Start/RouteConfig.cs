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

            routes.MapRoute(
              name: "Heritage",
              url: "Authors",
              defaults: new
              {
                  controller = "Author",
                  action = "Index",
                  page = 1,
                  group = (string)null
              });
            routes.MapRoute(
            name: "HeritagePage",
            url: "Authors/page{page}",
            defaults: new
            {
                controller = "Author",
                action = "Index",
                group = (string)null
            },
            constraints: new { page = @"\d+" });
            routes.MapRoute(
            name: "HeritageGroup",
            url: "Authors/{group}",
            defaults: new
            {
                controller = "Author",
                action = "Index",
                page = 1
            });

            routes.MapRoute(
            name: "HeritageGroupPage",
            url: "Authors/{group}/page{page}",
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

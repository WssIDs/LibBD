using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibDB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            name: "",
            url: "Cards",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                maingroup = (string)null,
                group = (string)null,
                page = 1,
            });

            routes.MapRoute(
            name: "",
            url: "Cards/{action}/{mbase}",
            defaults: new
            {
                controller = "TestCards",
                action = "Create"
            });

            routes.MapRoute(
            name: "",
            url: "Cards/page{page}",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                maingroup = (string)null,
                group = (string)null
            },
            constraints: new { page = @"\d+" });

            routes.MapRoute(
            name: "",
            url: "Cards/year{group}",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                maingroup = (string)null,
                page = 1
            });

            routes.MapRoute(
            name: "",
            url: "Cards/year{group}/page{page}",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                maingroup = (string)null
            },
            constraints: new
            {
                page = @"\d+"
            });

            routes.MapRoute(
            name: "",
            url: "Cards/base{maingroup}",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                group = (string)null,
                page = 1
            });

            routes.MapRoute(
            name: "",
            url: "Cards/base{maingroup}/page{page}",
            defaults: new
            {
                controller = "TestCards",
                group = (string)null,
                action = "List"
            },
            constraints: new
            {
                page = @"\d+"
            });

            routes.MapRoute(
            name: "",
            url: "Cards/base{maingroup}/year{group}",
            defaults: new
            {
                controller = "TestCards",
                action = "List",
                page = 1
            });

            routes.MapRoute(
            name: "",
            url: "Cards/base{maingroup}/year{group}/page{page}",
            defaults: new
            {
                controller = "TestCards",
                action = "List"
            },
            constraints: new
            {
                page = @"\d+"
            });

            ///////////////////////
            routes.MapRoute(
              name: "",
              url: "Catalog",
              defaults: new
              {
                  controller = "Author",
                  action = "List",
                  page = 1,
                  group = (string)null
              });

            routes.MapRoute(
            name: "",
            url: "Catalog/page{page}",
            defaults: new
            {
                controller = "Author",
                action = "List",
                group = (string)null
            },
            constraints: new { page = @"\d+" });

            routes.MapRoute(
            name: "",
            url: "Catalog/{group}",
            defaults: new
            {
                controller = "Author",
                action = "List",
                page = 1
            });

            routes.MapRoute(
            name: "",
            url: "Catalog/{group}/page{page}",
            defaults: new
            {
                controller = "Author",
                action = "List"
            },
            constraints: new
            {
                page = @"\d+"
            });

            routes.MapRoute(
                name: "",
                url: "Cards/{action}/{id}",
                defaults: new { controller = "TestCards", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace S3C_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "ProductsList",
            //    url: "Admin2/Products/{pageIndex}",
            //    defaults: new { controller = "Products", action = "Index" },
            //    namespaces: new string[] { "S3C_MVC.Areas.Admin.Controllers" }
            //);

            //routes.MapRoute(
            //    name: "ProductDetails",
            //    url: "Pro/{title}/{id}",
            //    defaults: new { controller = "Products", action = "Details" },
            //    namespaces: new string[] { "S3C_MVC.Controllers" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

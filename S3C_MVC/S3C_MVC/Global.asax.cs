﻿using AutoMapper;
using S3C_MVC.App_Start;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using static S3C_MVC.MvcApplication;

namespace S3C_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Config);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(config =>
            {
                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();

                config.CreateMap<Group, SimpleGroup>();
                config.CreateMap<SimpleGroup, Group>();

                config.CreateMap<ProductImage, SimpleImage>();
                config.CreateMap<SimpleImage, ProductImage>();

                config.CreateMap<Models.Public.ProductDTO, Product>();
                config.CreateMap<Product, Models.Public.ProductDTO>();
            });
        }
    }
}

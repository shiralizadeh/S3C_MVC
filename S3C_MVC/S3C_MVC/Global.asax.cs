using AutoMapper;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
using S3C_MVC.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            var container = new Container(config =>
            {
                //config.Scan(scan =>
                //{
                //    //scan.TheCallingAssembly();
                //    scan.WithDefaultConventions();
                //});

                config.For<IProductsServices>().Use<ProductsServices>();
            });

        }
    }

    //public class StructureMapControllerFactory : DefaultControllerFactory
    //{
    //    protected override IController
    //        GetControllerInstance(RequestContext requestContext,
    //        Type controllerType)
    //    {
    //        try
    //        {
    //            if ((requestContext == null) || (controllerType == null))
    //                return null;

    //            return (Controller).GetInstance(controllerType);
    //        }
    //        catch (StructureMapException)
    //        {
    //            System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
    //            throw new Exception(ObjectFactory.WhatDoIHave());
    //        }
    //    }
    //}

    //public static class Bootstrapper
    //{
    //    public static void Run()
    //    {
    //        ControllerBuilder.Current
    //            .SetControllerFactory(new StructureMapControllerFactory());

    //        ObjectFactory.Initialize(x =>
    //        {

    //        });
    //    }
    //}
}

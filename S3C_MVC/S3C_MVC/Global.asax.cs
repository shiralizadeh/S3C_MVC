using AutoMapper;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
            });
        }
    }
}

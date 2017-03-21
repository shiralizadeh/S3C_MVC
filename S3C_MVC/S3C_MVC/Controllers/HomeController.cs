using AutoMapper;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Public;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IProductsServices productsServices,
            IProductImagesServices productImagesServices)
        {
            this.productsServices = productsServices;
            this.productImagesServices = productImagesServices;
        }

        private IProductsServices productsServices;
        //private ProductsServices productsServices = new ProductsServices();
        private IProductImagesServices productImagesServices;
        //private ProductImagesServices productImagesServices = new ProductImagesServices();

        // GET: Home
        public ActionResult Index()
        {
            productsServices.SearchByTitle("فون");
            productsServices.Count = 10;

            var list = productsServices.GetDTO();

            var homeDTO = new HomeDTO();

            homeDTO.Products = list;

            foreach (var item in homeDTO.Products)
            {
                item.Image = productImagesServices.GetFirstImage(item.ID);

                if (!System.IO.File.Exists(Server.MapPath("/Uploads/" + item.Image)))
                {
                    item.Image = @"default.jpg";
                }
            }

            ViewBag.Title = "فروشگاه اینترنتی ما";

            return View(homeDTO);
        }

        public ActionResult TestJavascript()
        {
            System.Threading.Thread.Sleep(10000);

            return Content("dfdsfdsfsdf");
        }
    }
}
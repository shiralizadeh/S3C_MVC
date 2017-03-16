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
        public HomeController(IProductsServices productsServices)
        {
            this.productsServices = productsServices;
        }

        private IProductsServices productsServices;
        private ProductImagesServices productImagesServices = new ProductImagesServices();

        // GET: Home
        public ActionResult Index()
        {
            productsServices.SearchByTitle("فون");

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
    }
}
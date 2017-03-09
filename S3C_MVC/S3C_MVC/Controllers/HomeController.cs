using AutoMapper;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new EntityContext();

            var list = db.Products.ToList();

            var homeDTO = new HomeDTO();

            homeDTO.Products = Mapper.Map<List<ProductDTO>>(list);

            foreach (var item in homeDTO.Products)
            {
                item.Image = db.ProductImages.Where(img => img.ProductID == item.ID).FirstOrDefault()?.Image ?? @"default.jpg";

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
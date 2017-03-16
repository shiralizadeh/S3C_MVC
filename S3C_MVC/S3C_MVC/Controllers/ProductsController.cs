using S3C_MVC.Models.Public;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class ProductsController : Controller
    {
        ProductsServices productsServices = new ProductsServices();

        [Route("محصول/S3C-{id:int}/{title}")]
        public ActionResult Details(int id)
        {
            var productDTO = productsServices.GetDTOByID(id);

            return View(productDTO);
        }
    }
}
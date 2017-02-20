using S3C_MVC.DataLayer;
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

            ViewBag.Title = "فروشگاه اینترنتی ما";

            return View();
        }
    }
}
using S3C_MVC.Models;
using S3C_MVC.Models.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        [Route("درباره-ما")]
        public ActionResult Index()
        {
            ViewBag.Title = "درباره ما";

            var pageSettings = new PageSettings();

            pageSettings.Title = "دربارهههههه";
            pageSettings.Text = $"اطلاعاتی درباره ما در ساعت <b>{DateTime.Now.ToShortTimeString()}</b>";

            return View(model: pageSettings);
        }

        [NonAction]
        public string GetTitle()
        {
            return "My Title";
        }
    }
}
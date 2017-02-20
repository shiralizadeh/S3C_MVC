using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                var rnd = new Random();

                var db = new EntityContext();

                db.Products.Add(product);

                db.SaveChanges();

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var image = Request.Files["Image_" + i];

                    var path = Server.MapPath("~/Uploads/");
                    var filename = rnd.Next(1000, 9999) + ".jpg";
                    image.SaveAs(path + filename);

                    var productImage = new ProductImage();

                    productImage.ProductID = product.ID;
                    productImage.Image = filename;

                    db.ProductImages.Add(productImage);

                    db.SaveChanges();
                }

                
            }

            return View();
        }
    }
}
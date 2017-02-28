using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
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
        public ActionResult Add(int? id)
        {
            using (var db = new EntityContext())
            {
                Product model = null;

                if (id.HasValue)
                {
                    model = db.Products.Single(item => item.ID == id);
                }
                else
                {
                    model = new Product();
                }

                model.Groups = db.Groups.ToList();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Add(int? id, Product product)
        {
            using (var db = new EntityContext())
            {
                if (ModelState.IsValid)
                {

                    var rnd = new Random();

                    if (id.HasValue)
                    {
                        var p = db.Products.Single(item => item.ID == id);

                        p.Title = product.Title;
                        p.Count = product.Count;
                    }
                    else
                    {
                        db.Products.Add(product);
                    }

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

                product.Groups = db.Groups.ToList();

                return View(product);
            }
        }

        public ActionResult Index()
        {
            using (var db = new EntityContext())
            {
                List<Product> model = db.Products.ToList();

                return View(model);
            }
        }
    }
}
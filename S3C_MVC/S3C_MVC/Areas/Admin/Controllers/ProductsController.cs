using AutoMapper;
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
        public ActionResult Edit(int? id)
        {
            using (var db = new EntityContext())
            {
                ProductDTO productDTO = null;

                if (id.HasValue)
                {
                    var product = db.Products.Single(item => item.ID == id);

                    productDTO = Mapper.Map<ProductDTO>(product);

                    productDTO.Images = Mapper.Map<List<SimpleImage>>(db.ProductImages.Where(a => a.ProductID == id).ToList());
                    //productDTO.Images = product.Images;
                }
                else
                {
                    productDTO = new ProductDTO();
                }

                productDTO.Groups = Mapper.Map<List<SimpleGroup>>(db.Groups.ToList());

                return View(productDTO);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ProductDTO productDTO)
        {
            using (var db = new EntityContext())
            {
                if (ModelState.IsValid)
                {
                    var rnd = new Random();

                    if (id.HasValue)
                    {
                        var p = db.Products.Single(item => item.ID == id);

                        p.Title = productDTO.Title;
                        p.Count = productDTO.Count;
                    }
                    else
                    {
                        db.Products.Add(Mapper.Map<Product>(productDTO));
                    }
                    
                    db.SaveChanges();

                    foreach (string fileuploadname in Request.Files)
                    {
                        var image = Request.Files[fileuploadname];

                        var imageId = int.Parse(fileuploadname.Replace("Image_", ""));

                        if (image.ContentLength == 0)
                            continue;

                        var path = Server.MapPath("~/Uploads/");
                        var filename = rnd.Next(1000, 9999) + ".jpg";
                        image.SaveAs(path + filename);

                        if (imageId > 0)
                        {
                            var productImage = db.ProductImages.Where(a => a.ID == imageId).Single();

                            System.IO.File.Delete(path + productImage.Image);

                            productImage.Image = filename;

                            db.SaveChanges();
                        }
                        else
                        {
                            var productImage = new ProductImage();

                            productImage.ProductID = id.Value;
                            productImage.Image = filename;

                            db.ProductImages.Add(productImage);

                            db.SaveChanges();
                        }
                        
                    }
                }

                productDTO.Groups = Mapper.Map<List<SimpleGroup>>(db.Groups.ToList());
                productDTO.Images = Mapper.Map<List<SimpleImage>>(db.ProductImages.Where(a => a.ProductID == id.Value).ToList());

                return View(productDTO);
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
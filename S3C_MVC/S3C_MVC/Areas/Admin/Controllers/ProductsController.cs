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

                    if (productDTO.Images.Count == 0)
                        productDTO.Images.Add(new SimpleImage());
                    //productDTO.Images = product.Images;
                }
                else
                {
                    productDTO = new ProductDTO();
                    productDTO.Images = new List<SimpleImage>() { new SimpleImage() };
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

                    Product pro = null;
                    if (id.HasValue)
                    {
                        pro = db.Products.Single(item => item.ID == id);

                        pro.Title = productDTO.Title;
                        pro.Count = productDTO.Count;
                    }
                    else
                    {
                        pro = Mapper.Map<Product>(productDTO);

                        db.Products.Add(pro);
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

                            productImage.ProductID = pro.ID;
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

        public ActionResult Delete(int id)
        {
            using (var db = new EntityContext())
            {
                try
                {
                    var product = db.Products.Where(item => item.ID == id).Single();
                    var productImages = db.ProductImages.Where(item => item.ProductID == id).ToList();

                    foreach (var item in productImages)
                    {
                        System.IO.File.Delete(Server.MapPath("/Uploads/" + item.Image));
                    }

                    db.Products.Remove(product);

                    db.SaveChanges();

                    return Redirect("/Admin/Products?success=true");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
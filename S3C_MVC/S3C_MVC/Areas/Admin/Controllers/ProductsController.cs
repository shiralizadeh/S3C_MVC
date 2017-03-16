using AutoMapper;
using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ProductsServices productsServices = new ProductsServices();
        private ProductImagesServices productImagesServices = new ProductImagesServices();
        private GroupsServices groupsServices = new GroupsServices();

        // GET: Admin/Products
        public ActionResult Edit(int? id)
        {
            ProductDTO productDTO = null;

            if (id.HasValue)
            {
                var product = productsServices.GetByID(id.Value);

                productDTO = Mapper.Map<ProductDTO>(product);

                productDTO.Images = Mapper.Map<List<SimpleImage>>(productImagesServices.GetByProductID(id.Value));

                if (productDTO.Images.Count == 0)
                    productDTO.Images.Add(new SimpleImage());
                //productDTO.Images = product.Images;
            }
            else
            {
                productDTO = new ProductDTO();
                productDTO.Images = new List<SimpleImage>() { new SimpleImage() };
            }

            productDTO.Groups = groupsServices.GetForDropdown();

            return View(productDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var rnd = new Random();

                if (id.HasValue)
                {
                    productsServices.Update(id.Value, productDTO);
                }
                else
                {
                    var pro = Mapper.Map<Product>(productDTO);

                    productsServices.Insert(pro);

                    id = pro.ID;
                }

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
                        var productImage = productImagesServices.GetByID(imageId);
                        System.IO.File.Delete(path + productImage.Image);

                        productImagesServices.UpdateImage(imageId, filename);
                    }
                    else
                    {
                        var productImage = new ProductImage();

                        productImage.ProductID = id.Value;
                        productImage.Image = filename;

                        productImagesServices.Insert(productImage);
                    }
                }
            }

            productDTO.Groups = groupsServices.GetForDropdown();
            productDTO.Images = productImagesServices.GetSimpleGroup(id.Value);

            return View(productDTO);
        }

        //[Route("Admin/Products/{pageIndex}")]
        public ActionResult Index(int pageIndex = 0, int pageSize = 10)
        {
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;

            using (var db = new EntityContext())
            {
                List<Product> model = db.Products.OrderBy(item => item.ID).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                ViewBag.PageCount = db.Products.Count();

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
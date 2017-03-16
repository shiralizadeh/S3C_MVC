using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3C_MVC.Models.Admin;

namespace S3C_MVC.Services
{
    public class ProductImagesServices
    {
        public List<ProductImage> GetByProductID(int productID)
        {
            using (var db = new EntityContext())
            {
                var productImages = db.ProductImages.Where(a => a.ProductID == productID).ToList();

                return productImages;
            }
        }

        public string GetFirstImage(int id)
        {
            using (var db = new EntityContext())
            {
                var productImages = db.ProductImages.Where(img => img.ProductID == id).FirstOrDefault()?.Image ?? @"default.jpg";

                return productImages;
            }
        }

        public ProductImage GetByID(int id)
        {
            using (var db = new EntityContext())
            {
                var productImage = db.ProductImages.Where(img => img.ID == id).Single();

                return productImage;
            }
        }

        public void UpdateImage(int id, string filename)
        {
            using (var db = new EntityContext())
            {
                var productImage = db.ProductImages.Where(img => img.ID == id).Single();

                productImage.Image = filename;

                db.SaveChanges();
            }
        }

        public void Insert(ProductImage productImage)
        {
            using (var db = new EntityContext())
            {
                db.ProductImages.Add(productImage);

                db.SaveChanges();
            }
        }

        public List<SimpleImage> GetSimpleGroup(int id)
        {
            using (var db = new EntityContext())
            {
                var query = from item in db.ProductImages
                            where item.ProductID == id
                            select new SimpleImage()
                            {
                                ID = item.ID,
                                Image = item.Image
                            };

                return query.ToList();
            }
        }
    }
}

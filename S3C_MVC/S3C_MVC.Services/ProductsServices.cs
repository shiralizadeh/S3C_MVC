using S3C_MVC.DataLayer;
using S3C_MVC.Models.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3C_MVC.Models.Admin;
using System.Data.SqlClient;

namespace S3C_MVC.Services
{
    public interface IProductsServices
    {
        int Count { get; set; }
        List<Product> Get();
        List<Product> SearchByTitle(string title);
        List<Models.Public.ProductDTO> GetDTO();
        Product GetByID(int id);
        Models.Public.ProductDTO GetDTOByID(int id);
        void Insert(Product pro);
        void Update(int id, Models.Admin.ProductDTO productDTO);
    }

    public class ProductsServices : IProductsServices
    {
        public int Count { get; set; }

        public List<Product> Get()
        {
            using (var db = new EntityContext())
            {
                var list = db.Products.ToList();

                return list;
            }
        }

        public List<Product> GetByTitle(string title)
        {
            using (var db = new EntityContext())
            {
                var list = db.Products.Where(item => item.Title.Contains(title)).ToList();

                return list;
            }
        }

        public List<Product> SearchByTitle(string title)
        {
            using (var db = new EntityContext())
            {
                var titleParam = new SqlParameter()
                {
                    ParameterName = "@Title",
                    Value = title
                };

                var list = db.Database.SqlQuery<Product>("exec SearchByTitle @Title", titleParam).ToList();

                return list;
            }
        }

        public List<Models.Public.ProductDTO> GetDTO()
        {
            using (var db = new EntityContext())
            {
                var result = from item in db.Products
                             select new Models.Public.ProductDTO()
                             {
                                 ID = item.ID,
                                 Title = item.Title,
                                 Count = item.Count,
                                 Price = item.Price
                             };

                return result.ToList();
            }
        }

        public Product GetByID(int id)
        {
            using (var db = new EntityContext())
            {
                var product = db.Products.Single(item => item.ID == id);

                return product;
            }
        }

        public Models.Public.ProductDTO GetDTOByID(int id)
        {
            using (var db = new EntityContext())
            {
                var query = from item in db.Products
                            where item.ID == id
                            select new Models.Public.ProductDTO()
                            {
                                ID = item.ID,
                                Count = item.Count,
                                Title = item.Title,
                                Price = item.Price,
                            };

                return query.Single();
            }
        }

        public void Insert(Product pro)
        {
            using (var db = new EntityContext())
            {
                db.Products.Add(pro);

                db.SaveChanges();
            }
        }

        public void Update(int id, Models.Admin.ProductDTO productDTO)
        {
            using (var db = new EntityContext())
            {
                var pro = db.Products.Single(item => item.ID == id);

                pro.Title = productDTO.Title;
                pro.Count = productDTO.Count;

                db.SaveChanges();
            }
        }
    }
}

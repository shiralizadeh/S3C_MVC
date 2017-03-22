using S3C_MVC.DataLayer;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S3C_MVC.WebApiControllers
{
    public class ProductsController : ApiController
    {
        ProductsServices productsServices = new ProductsServices();

        public List<Product> Get()
        {
            return productsServices.Get();
        }

        public Product Get(int id)
        {
            return productsServices.GetByID(id);
        }

        public void Post([FromBody]Product product)
        {
            productsServices.Insert(product);
        }

        public void Delete(int id)
        {
            productsServices.Delete(id);
        }
    }
}

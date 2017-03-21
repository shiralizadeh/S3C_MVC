using S3C_MVC.Models.Public;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace S3C_MVC.DataLayerDapper
{
    public class Products
    {
        public static List<ProductDTO> Get()
        {
            var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EntityConnectionString"].ConnectionString);

            var result = con.Query<ProductDTO>("Select * from Products").ToList();

            return result;
        }
    }
}

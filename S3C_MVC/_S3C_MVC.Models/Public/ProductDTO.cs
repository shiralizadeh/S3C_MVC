using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Models.Public
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

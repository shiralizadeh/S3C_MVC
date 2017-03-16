using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class ProductImage : EntityBase
    {
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Image { get; set; }
    }
}

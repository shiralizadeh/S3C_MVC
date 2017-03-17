using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class CartItem : EntityBase
    {
        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public Cart Cart { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}

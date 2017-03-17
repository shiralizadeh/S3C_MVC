using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Services
{
    public class CartsServices
    {
        public void Insert(Cart cart)
        {
            using (var db = new EntityContext())
            {
                db.Carts.Add(cart);

                db.SaveChanges();
            }
        }

        public Cart GetByGuid(Guid guid)
        {
            using (var db = new EntityContext())
            {
                var cart = db.Carts.Where(item => item.CartGuid == guid).Single();

                return cart;
            }
        }
    }
}

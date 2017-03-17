using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Services
{
    public class CartItemsServices
    {
        public void Insert(CartItem cartItem)
        {
            using (var db = new EntityContext())
            {
                db.CartItems.Add(cartItem);

                db.SaveChanges();
            }
        }

        public List<CartItem> GetItemsByCartGuid(Guid cartGuid)
        {
            using (var db = new EntityContext())
            {
                var items = db.CartItems.Where(item => item.Cart.CartGuid == cartGuid).ToList();

                return items;
            }
        }

        public bool IsExists(Guid cartGuid, int productID)
        {
            using (var db = new EntityContext())
            {
                return db.CartItems.Any(item => item.Cart.CartGuid == cartGuid && item.ProductID == productID);
            }
        }

        public int UpdateCount(Guid cartGuid, int productID)
        {
            using (var db = new EntityContext())
            {
                var cartItem = db.CartItems.Single(item => item.Cart.CartGuid == cartGuid && item.ProductID == productID);

                cartItem.Count++;

                db.SaveChanges();

                return cartItem.Count;
            }
        }

        public void DeleteByCartGuidProductID(Guid cartGuid, int productID)
        {
            using (var db = new EntityContext())
            {
                var cartItem = db.CartItems.Single(item => item.Cart.CartGuid == cartGuid && item.ProductID == productID);

                db.CartItems.Remove(cartItem);

                db.SaveChanges();
            }
        }
    }
}

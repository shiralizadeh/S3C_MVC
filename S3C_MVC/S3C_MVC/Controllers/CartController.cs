using S3C_MVC.DataLayer;
using S3C_MVC.Models.Public;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3C_MVC.Controllers
{
    public class CartController : Controller
    {
        public CartsServices cartsServices => new CartsServices();
        public CartItemsServices cartItemsServices => new CartItemsServices();
        public ProductsServices productsServices => new ProductsServices();
        public ProductImagesServices productImagesServices => new ProductImagesServices();

        [HttpPost]
        public JsonResult AddToCart(int productID)
        {
            try
            {
                var cartCookie = Request.Cookies["CartGuid"];
                int count = -1;

                if (cartCookie == null)
                {
                    var guid = Guid.NewGuid();
                    cartCookie = new HttpCookie("CartGuid", guid.ToString());

                    //cartCookie.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(cartCookie);

                    // insert cart & insert cartitem
                    var cart = new Cart()
                    {
                        CartGuid = guid
                    };
                    cartsServices.Insert(cart);

                    var cartItem = new CartItem()
                    {
                        CartID = cart.ID,
                        ProductID = productID,
                        Count = 1
                    };

                    count = 1;
                    cartItemsServices.Insert(cartItem);
                }
                else
                {
                    // insert cartitem
                    var cart = cartsServices.GetByGuid(Guid.Parse(cartCookie.Value));

                    if (cartItemsServices.IsExists(cart.CartGuid, productID))
                    {
                        count = cartItemsServices.UpdateCount(cart.CartGuid, productID);
                    }
                    else
                    {
                        var cartItem = new CartItem()
                        {
                            CartID = cart.ID,
                            ProductID = productID,
                            Count = 1
                        };

                        count = 1;
                        cartItemsServices.Insert(cartItem);
                    }
                }

                var product = productsServices.GetByID(productID);
                var productImage = productImagesServices.GetByProductID(productID).First();
                var jsonCartProduct = new JsonCartProduct();

                jsonCartProduct.ID = product.ID;
                jsonCartProduct.Title = product.Title;
                jsonCartProduct.Price = product.Price;
                jsonCartProduct.Count = count;
                jsonCartProduct.Image = productImage.Image;

                return Json(jsonCartProduct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool RemoveFromCart(int productID)
        {
            try
            {
                var cartCookie = Request.Cookies["CartGuid"];

                if (cartCookie == null)
                {
                    return false;
                }
                else
                {
                    cartItemsServices.DeleteByCartGuidProductID(Guid.Parse(cartCookie.Value), productID);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
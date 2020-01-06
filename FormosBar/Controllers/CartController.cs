using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormosBar.Controllers
{
    public class CartController : Controller
    {
        //GET Cart
        public ActionResult GetCart()
        {
            return PartialView("_PartialCart");
        }


        //Add Item to Cart
        public ActionResult AddToCart(int id)
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.AddProduct(id);
            return PartialView("_PartialCart");
        }

        //Remove Item From Cart
        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.RemoveProduct(id);
            return PartialView("_PartialCart");
        }

        //Clear All Item From Cart
        public ActionResult ClearCart()
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.ClearCart();
            return PartialView("_PartialCart");
        }
    }
}
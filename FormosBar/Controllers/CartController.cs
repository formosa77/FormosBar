using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormosBar.Controllers
{
    public class CartController : Controller
    {
        public ActionResult GetCart()
        {
            return PartialView("_PartialCart");
        }

        public ActionResult AddToCart(int id)
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.AddProduct(id);
            return PartialView("_PartialCart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.RemoveProduct(id);
            return PartialView("_PartialCart");
        }

        public ActionResult ClearCart()
        {
            var currentCart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            currentCart.ClearCart();
            return PartialView("_PartialCart");
        }
    }
}
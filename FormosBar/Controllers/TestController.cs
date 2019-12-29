using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormosBar.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetCart()
        {
            var cart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
            cart.AddProduct(1);

            return Content(string.Format("Total Amount in Shopping Cart: £{0}", cart.TotalAmount));
        }
    }
}
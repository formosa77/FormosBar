using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FormosBar.Models.ShoppingCart
{
    public static class CartActions
    {
        [WebMethod(EnableSession = true)]

        public static Models.ShoppingCart.Cart CurrentShoppingCart() {
            if (System.Web.HttpContext.Current != null)
            {
                if (System.Web.HttpContext.Current.Session["Cart"] == null)
                {
                    var order = new Cart();
                    System.Web.HttpContext.Current.Session["Cart"] = order;
                }
                return (Cart)System.Web.HttpContext.Current.Session["Cart"];
            }
            else {
                throw new InvalidOperationException("System.Web.HttpContext.Current is Empty");
            }
        }
    }
}
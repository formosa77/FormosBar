using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FormosBar.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Customer")]
        [HttpPost]
        public ActionResult Index(Models.OrderLocation postback)
        {
            if (this.ModelState.IsValid)
            {   
                var currentcart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
                var userId = HttpContext.User.Identity.GetUserId();
                var userName = HttpContext.User.Identity.GetUserName();

                using (DAL.BarContext db = new DAL.BarContext())
                {

                    var order = new Models.Order()
                    {
                        UserId = userId,
                        UserName = userName,
                        TableNumber = postback.TableNumber,
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    var orderDetails = currentcart.ToOrderDetailList(order.Id);

                    db.OrderDetails.AddRange(orderDetails);
                    db.SaveChanges();

                }

                return View("~/Views/Home/Index.cshtml");
            }

            return View();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult YourOrder()
        {
            var userId = HttpContext.User.Identity.GetUserId();

            using (DAL.BarContext db = new DAL.BarContext())
            {
                var result = (from s in db.Orders
                              where s.UserId == userId
                              select s).ToList();

                return View(result);
            }
        }

        [Authorize(Roles = "Customer")]
        public ActionResult YourOrderDetail(int id)
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {
                var result = (from s in db.OrderDetails
                              where s.OrderId == id
                              select s).ToList();

                if (result.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }
            }
        }
    }
}
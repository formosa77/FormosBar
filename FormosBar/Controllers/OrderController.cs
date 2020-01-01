using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FormosBar.Models;
using FormosBar.Migrations.ContextB;
using Microsoft.AspNet.Identity;
using Order = FormosBar.Models.Order;
using OrderDetail = FormosBar.Models.OrderDetail;
using System.Data.Entity;

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

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Index(Models.OrderLocation postback, Nullable <int> OrderId)
        {
            if (OrderId == null)
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
            }
            else {

                if (this.ModelState.IsValid)
                {
                    var currentcart = Models.ShoppingCart.CartActions.CurrentShoppingCart();
                    //var userId = HttpContext.User.Identity.GetUserId();
                    //var userName = HttpContext.User.Identity.GetUserName();

                    using (DAL.BarContext db = new DAL.BarContext())
                    {
                        //var order = new Models.Order()
                        //{
                        //    Id = OrderId.GetValueOrDefault();
                        //};
                        
                        //var order = new Models.Order()
                        //{
                        //    UserId = userId,
                        //    UserName = userName,
                        //    TableNumber = postback.TableNumber,
                        //};

                        //db.Orders.Add(order);
                        //db.SaveChanges();

                        var orderDetails = currentcart.ToOrderDetailList(OrderId.GetValueOrDefault());

                        db.OrderDetails.AddRange(orderDetails);
                        db.SaveChanges();

                    }

                    return View("~/Views/Home/Index.cshtml");
                }

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

        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> Delete(int? id)
        {
            using (DAL.BarContext db = new DAL.BarContext()) { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
            }
        }

        [Authorize(Roles = "Customer")]
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {

                Order order = await db.Orders.FindAsync(id);
                db.Orders.Remove(order);
                await db.SaveChangesAsync();
                return RedirectToAction("YourOrder");
            }
        }




















        public ActionResult Add()
        {
            return View();
        }

        //Create Item Page - Data Post Back
        [HttpPost]
        public ActionResult Add(Models.OrderDetail postback)
        {
            if (this.ModelState.IsValid)
            {
                using (DAL.BarContext db = new DAL.BarContext())
                {
                    //Post back data and add to Item table
                    db.OrderDetails.Add(postback);

                    //Save Change
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Message = "The data entry is not correct.";
                return View(postback);
            }

        }









        public async Task<ActionResult> Edit(int? id)
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OrderDetail orderdetail = await db.OrderDetails.FindAsync(id);
                if (orderdetail == null)
                {
                    return HttpNotFound();
                }
                return View(orderdetail);
            }
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrderDetail orderdetail)
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(orderdetail).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(orderdetail);
            }
        }

    }
}
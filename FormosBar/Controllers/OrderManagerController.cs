using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FormosBar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        // GET: OrderManager
        public ActionResult Index()
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {
                var result = (from s in db.Orders
                              select s).ToList();

                return View(result);
            }
        }

        //Admin View Order Details
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
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

        //Admin View Order Details by Searching Function
        public ActionResult SerachByUserName(string UserName)
        {
            //string searchUserId = null;

            var userName = UserName;


            using (DAL.BarContext db = new DAL.BarContext())
            {
                var userId = HttpContext.User.Identity.GetUserId();

                //searchUserId = (from s in db.AspNetUsers
                //                where s.UserName == UserName
                //                select s.Id).FirstOrDefault();
            }
            if (!String.IsNullOrEmpty(userName))
            {
                using (DAL.BarContext db = new DAL.BarContext())
                {
                    var result = (from s in db.Orders
                                  where s.UserName == userName
                                  select s).ToList();

                    return View("Index", result);
                }
            }
            else
            {  
                return View("Index", new List<Models.Order>());
            }

        }
    }
}
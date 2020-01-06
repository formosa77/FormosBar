using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormosBar.Controllers
{
    public class HomeController : Controller
    {
        //Index Page
        public ActionResult Index()
        {
            return View();
        }

        //About Us Page
        public ActionResult About()
        {

            return View();
        }

        //Menu Page
        public ActionResult Menu()
        {
            using (DAL.BarContext db = new DAL.BarContext()) {
                var result = (from s in db.Items select s).ToList();
                return View(result);
            }
        }

    }
}
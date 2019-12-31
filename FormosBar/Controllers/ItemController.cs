using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormosBar.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //echo the Item List
            List<Models.Item> result = new List<Models.Item>();

            //handle the message
            ViewBag.Message = TempData["Message"];

            using (DAL.BarContext db = new DAL.BarContext())
            {
                result = (from s in db.Items select s).ToList();
                return View(result);
            }
        }

        //Create Item
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //Create Item Page - Data Post Back
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Models.Item postback)
        {
            if (this.ModelState.IsValid)
            {
                using (DAL.BarContext db = new DAL.BarContext())
                {
                    //Post back data and add to Item table
                    db.Items.Add(postback);

                    //Save Change
                    db.SaveChanges();

                    //Item Create Sucessfully 
                    TempData["Message"] = String.Format("Item[{0}] is created", postback.Name);

                    return RedirectToAction("Index");
                }
            }
            else {
                ViewBag.Message = "The data entry is not correct.";
                return View(postback);
            }
            
        }

        //Edit Item Page
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using (DAL.BarContext db = new DAL.BarContext())
            {
                //Catch Item.Id as Entry
                var result = (from s in db.Items where s.Id == id select s).FirstOrDefault();
                //verify the id
                if (result != default(Models.Item)) 
                {
                    return View(result); 
                }
                else
                {   //If no data is found, direct to Index
                    TempData["Message"] = "Please Input Again";
                    return RedirectToAction("Index");
                }
            }
        }

        //Edit Item Page
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Models.Item postback)
        {
            //verify the user input
            if (this.ModelState.IsValid) 
            {
                using (DAL.BarContext db = new DAL.BarContext())
                {
                    //catch Item.Id and postback the data of Id
                    var result = (from s in db.Items where s.Id == postback.Id select s).FirstOrDefault();

                    //Save the change into Database
                    result.Name = postback.Name; result.Price = postback.Price;
                    result.Description = postback.Description; result.OnShelf = postback.OnShelf;
                    result.DefaultImageURL = postback.DefaultImageURL; result.Category = postback.Category;
                    result.ImageAlt = postback.ImageAlt;

                    //Save the change
                    db.SaveChanges();

                    //Pop-up "edit successfully" msg and direct to Index
                    TempData["Message"] = String.Format("Item [{0}] is edited ", postback.Name);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(postback);
            }
        }
    }
}
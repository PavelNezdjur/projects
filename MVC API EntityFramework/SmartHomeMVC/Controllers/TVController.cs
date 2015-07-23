using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class TVController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult TVSH()
        {
            IEnumerable<TV> TVs = db.TVs;
            ViewBag.TVs = TVs;
            return View();
        }

        [HttpGet]
        public ActionResult TVCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TVCreate(TV tv)
        {
            db.TVs.Add(tv);
            db.SaveChanges();
            return RedirectToAction("TVSH");
        }

        [HttpGet]
        public ActionResult TVEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TV tv = db.TVs.Find(id);

            if (tv == null)
            {
                return HttpNotFound();
            }
            return PartialView(tv);
        }

        [HttpPost]
        public ActionResult TVEditPartial(TV tv)
        {
            db.Entry(tv).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TVSH");
        }

        [HttpGet]
        public ActionResult TVDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TV tv = db.TVs.Find(id);
            if (tv == null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }

        [HttpPost, ActionName("TVDelete")]
        public ActionResult TVDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TV tv = db.TVs.Find(id);
            if (tv == null)
            {
                return HttpNotFound();
            }
            db.TVs.Remove(tv);
            db.SaveChanges();
            return RedirectToAction("TVSH");
        }

        public ActionResult TVAPI()
        {
            return View();
        }
    }
}
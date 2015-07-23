using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class WindowController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult WindowSH()
        {
            IEnumerable<Window> Windows = db.Windows;
            ViewBag.Windows = Windows;
            return View();
        }

        [HttpGet]
        public ActionResult WindowCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WindowCreate(Window wnd)
        {
            db.Windows.Add(wnd);
            db.SaveChanges();
            return RedirectToAction("WindowSH");
        }

        [HttpGet]
        public ActionResult WindowEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Window wnd = db.Windows.Find(id);

            if (wnd == null)
            {
                return HttpNotFound();
            }
            return PartialView(wnd);
        }

        [HttpPost]
        public ActionResult WindowEditPartial(Window wnd)
        {
            db.Entry(wnd).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("WindowSH");
        }

        [HttpGet]
        public ActionResult WindowDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Window wnd = db.Windows.Find(id);
            if (wnd == null)
            {
                return HttpNotFound();
            }
            return View(wnd);
        }

        [HttpPost, ActionName("WindowDelete")]
        public ActionResult WindowDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Window wnd = db.Windows.Find(id);
            if (wnd == null)
            {
                return HttpNotFound();
            }
            db.Windows.Remove(wnd);
            db.SaveChanges();
            return RedirectToAction("WindowSH");
        }

        public ActionResult WindowAPI()
        {
            return View();
        }
    }
}
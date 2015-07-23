using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class LampController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult LampSH()
        {
            IEnumerable<Lamp> Lamps = db.Lamps;
            ViewBag.Lamps = Lamps;
            return View();
        }

        [HttpGet]
        public ActionResult LampCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LampCreate(Lamp lmp)
        {
            db.Lamps.Add(lmp);
            db.SaveChanges();
            return RedirectToAction("LampSH");
        }

        [HttpGet]
        public ActionResult LampEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Lamp lmp = db.Lamps.Find(id);

            if (lmp == null)
            {
                return HttpNotFound();
            }
            return PartialView(lmp);
        }

        [HttpPost]
        public ActionResult LampEditPartial(Lamp lmp)
        {
            db.Entry(lmp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("LampSH");
        }

        [HttpGet]
        public ActionResult LampDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Lamp lmp = db.Lamps.Find(id);
            if (lmp == null)
            {
                return HttpNotFound();
            }
            return View(lmp);
        }

        [HttpPost, ActionName("LampDelete")]
        public ActionResult LampDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Lamp lmp = db.Lamps.Find(id);
            if (lmp == null)
            {
                return HttpNotFound();
            }
            db.Lamps.Remove(lmp);
            db.SaveChanges();
            return RedirectToAction("LampSH");
        }
    }
}
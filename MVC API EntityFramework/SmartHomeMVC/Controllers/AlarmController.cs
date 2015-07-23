using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class AlarmController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult AlarmSH()
        {    
            IEnumerable<Alarm> Alarms = db.Alarms;
            ViewBag.Alarms = Alarms;
            return View();
        }

        [HttpGet]
        public ActionResult AlarmCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlarmCreate(Alarm al)
        {
            db.Alarms.Add(al);
            db.SaveChanges();
            return RedirectToAction("AlarmSH");
        }

        [HttpGet]
        public ActionResult AlarmEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Alarm al = db.Alarms.Find(id);

            if (al == null)
            {
                return HttpNotFound();
            }
            return PartialView(al);
        }

        [HttpPost]
        public ActionResult AlarmEditPartial(Alarm al)
        {
            db.Entry(al).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AlarmSH");
        }

        [HttpGet]
        public ActionResult AlarmDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Alarm al = db.Alarms.Find(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

        [HttpPost, ActionName("AlarmDelete")]
        public ActionResult AlarmDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Alarm al = db.Alarms.Find(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            db.Alarms.Remove(al);
            db.SaveChanges();
            return RedirectToAction("AlarmSH");
        }
    }
}
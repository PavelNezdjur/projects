using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class ClimateController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult ClimateSH()
        {
            IEnumerable<Climate> Climates = db.Climates;
            ViewBag.Climates = Climates;
            return View();
        }

        [HttpGet]
        public ActionResult ClimateCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClimateCreate(Climate clm)
        {
            db.Climates.Add(clm);
            db.SaveChanges();
            return RedirectToAction("ClimateSH");
        }

        [HttpGet]
        public ActionResult ClimateEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Climate clm = db.Climates.Find(id);

            if (clm == null)
            {
                return HttpNotFound();
            }
            return PartialView(clm);
        }

        [HttpPost]
        public ActionResult ClimateEditPartial(Climate clm)
        {
            db.Entry(clm).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ClimateSH");
        }

        [HttpGet]
        public ActionResult ClimateDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Climate clm = db.Climates.Find(id);
            if (clm == null)
            {
                return HttpNotFound();
            }
            return View(clm);
        }

        [HttpPost, ActionName("ClimateDelete")]
        public ActionResult ClimateDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Climate clm = db.Climates.Find(id);
            if (clm == null)
            {
                return HttpNotFound();
            }
            db.Climates.Remove(clm);
            db.SaveChanges();
            return RedirectToAction("ClimateSH");
        }
    }
}
using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class FreedgeController : Controller
    {
        SmartHomeContext db = new SmartHomeContext();

        public ActionResult FreedgeSH()
        {
            IEnumerable<Freedge> Freedges = db.Freedges;
            ViewBag.Freedges = Freedges;
            return View();
        }

        [HttpGet]
        public ActionResult FreedgeCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FreedgeCreate(Freedge clm)
        {
            db.Freedges.Add(clm);
            db.SaveChanges();
            return RedirectToAction("FreedgeSH");
        }

        [HttpGet]
        public ActionResult FreedgeEditPartial(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Freedge clm = db.Freedges.Find(id);

            if (clm == null)
            {
                return HttpNotFound();
            }
            return PartialView(clm);
        }

        [HttpPost]
        public ActionResult FreedgeEditPartial(Freedge clm)
        {
            db.Entry(clm).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("FreedgeSH");
        }

        [HttpGet]
        public ActionResult FreedgeDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Freedge clm = db.Freedges.Find(id);
            if (clm == null)
            {
                return HttpNotFound();
            }
            return View(clm);
        }

        [HttpPost, ActionName("FreedgeDelete")]
        public ActionResult FreedgeDeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Freedge clm = db.Freedges.Find(id);
            if (clm == null)
            {
                return HttpNotFound();
            }
            db.Freedges.Remove(clm);
            db.SaveChanges();
            return RedirectToAction("FreedgeSH");
        }
    }
}
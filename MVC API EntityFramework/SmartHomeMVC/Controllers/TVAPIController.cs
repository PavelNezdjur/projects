using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SmartHomeMVC.Controllers
{
    public class TVAPIController : ApiController
    {
        SmartHomeContext db = new SmartHomeContext();

        public IEnumerable<TV> GetAllTVs()
        {
            return db.TVs;
        }

        public TV GetTV(int id)
        {
            TV tv = db.TVs.Find(id);
            return tv;
        }

        [HttpPost]
        public void CreateTV([FromBody]TV tv)
        {
            db.TVs.Add(tv);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditTV(int id, [FromBody]TV tv)
        {
            if (id == tv.Id)
            {
                db.Entry(tv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteTV(int id)
        {
            TV tv = db.TVs.Find(id);
            if (tv != null)
            {
                db.TVs.Remove(tv);
                db.SaveChanges();
            }
        }
    }
}

using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHomeMVC.Controllers
{
    public class WindowAPIController : ApiController
    {
        SmartHomeContext db = new SmartHomeContext();

        public IEnumerable<Window> GetAllWindows()
        {
            return db.Windows;
        }

        public Window GetWindow(int id)
        {
            Window Window = db.Windows.Find(id);
            return Window;
        }

        [HttpPost]
        public void CreateWindow([FromBody]Window Window)
        {
            db.Windows.Add(Window);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditWindow(int id, [FromBody]Window Window)
        {
            if (id == Window.Id)
            {
                db.Entry(Window).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteWindow(int id)
        {
            Window Window = db.Windows.Find(id);
            if (Window != null)
            {
                db.Windows.Remove(Window);
                db.SaveChanges();
            }
        }
    }
}

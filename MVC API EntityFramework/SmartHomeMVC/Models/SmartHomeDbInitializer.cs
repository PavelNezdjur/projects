using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class SmartHomeDbInitializer : DropCreateDatabaseAlways<SmartHomeContext>
    {
        protected override void Seed(SmartHomeContext db)
        {
            db.Alarms.Add(new Alarm("Alarm1"));
            base.Seed(db);
            db.Climates.Add(new Climate("Climate1"));
            base.Seed(db);
            db.Freedges.Add(new Freedge("Freedge1"));
            base.Seed(db);
            db.Lamps.Add(new Lamp("Lamp1"));
            base.Seed(db);
            db.TVs.Add(new TV("tv1"));
            base.Seed(db);
            db.Windows.Add(new Window("Window1"));
            base.Seed(db);
        }
    }
}
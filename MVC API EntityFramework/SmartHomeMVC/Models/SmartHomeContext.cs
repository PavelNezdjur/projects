using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class SmartHomeContext : DbContext
    {
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Climate> Climates { get; set; }
        public DbSet<Freedge> Freedges { get; set; }
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<TV> TVs { get; set; }
        public DbSet<Window> Windows { get; set; }

        static SmartHomeContext()
        {
            Database.SetInitializer(new SmartHomeDbInitializer());
        }
    }
}
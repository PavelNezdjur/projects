using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public abstract class Gadget
    {
        private string title;
        private bool condition;
        public Gadget(string title)
        {
            this.title = title;
        }
        public abstract bool CurrentCondition();
        public abstract string GadgetTitle();
    }
}
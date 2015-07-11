using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    class Window : Gadget
    {
        private string title;
        private bool condition = false;

        public Window(string title)
            : base(title)
        {
            this.title = title;
        }

        public override bool CurrentCondition()
        {
            return condition;
        }
        public override string GadgetTitle()
        {
            return title;
        }
        public bool Open()
        {
            return condition = true;
        }
        public bool Close()
        {
            return condition = false;
        }
    }
}
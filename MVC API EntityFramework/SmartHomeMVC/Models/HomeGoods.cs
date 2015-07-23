using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class HomeGoods : Gadget
    {
        private string title;
        private bool condition;
        public HomeGoods()
        {

        }
        public HomeGoods(string title)
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
    }
}
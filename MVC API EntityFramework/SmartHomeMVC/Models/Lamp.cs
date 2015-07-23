using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class Lamp : Gadget
    {
        public int Id { get; set; }
        public string title { get; set; }
        private bool condition;
        public bool Condition
        {
            get { return condition; }
            set
            {
                condition = value;
            }
        }
        public Lamp(string title)
            : base(title)
        {
            this.title = title;
        }
        public Lamp()
        {

        }
        public override bool CurrentCondition()
        {
            return condition;
        }
        public override string GadgetTitle()
        {
            return title;
        }
        public bool PowerOn()
        {
            return condition = true;
        }
        public bool PowerOff()
        {
            return condition = false;
        }
        public override string ToString()
        {
            string condition;
            if (this.condition)
            {
                condition = "Включен";
            }
            else
            {
                condition = "Выключен";
            }
            return condition;
        }
    }
}
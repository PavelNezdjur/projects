using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class Window : Gadget
    {
        public int Id { get; set; }
        public string title { get; set; }
        private bool condition = false;
        public bool Condition
        {
            get { return condition; }
            set
            {
                condition = value;
            }
        }
        public Window(string title)
            : base(title)
        {
            this.title = title;
        }
        public Window()
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
        public bool Open()
        {
            return condition = true;
        }
        public bool Close()
        {
            return condition = false;
        }
        public override string ToString()
        {
            string condition;
            if (this.condition)
            {
                condition = "Открыто";
            }
            else
            {
                condition = "Закрыто";
            }
            return condition;
        }
    }
}

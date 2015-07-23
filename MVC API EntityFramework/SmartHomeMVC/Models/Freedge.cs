using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class Freedge : HomeGoods
    {
        public int Id { get; set; }
        public string title { get; set; }
        private bool condition;
        public int temperature {get; set; }
        public bool Condition
        {
            get { return condition; }
            set
            {
                condition = value;
            }
        }
        public Freedge(string title)
            : base(title)
        {
            this.title = title;
        }
        public Freedge()
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
        public int TemperatureValue()
        {
            return temperature;
        }
        public bool PowerOn()
        {
            return condition = true;
        }
        public bool PowerOff()
        {
            return condition = false;
        }
        public bool Open()
        {
            return condition = true;
        }
        public bool Close()
        {
            return condition = false;
        }
        public void TemperatureUp()
        {
            if (-1 < temperature && temperature < 4)
            {
                temperature += 1;
            }
        }
        public void TemperatureDown()
        {
            if (0 < temperature && temperature < 5)
            {
                temperature -= 1;
            }
        }
        public void TemperatureSet(int value)
        {
            if (-2 < value && value < 6)
            {
                temperature = value;
            }
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
            return condition + ", " + "Температура внутри установлена на: " + temperature.ToString() + "град.";
        }
    }
}
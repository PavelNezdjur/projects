using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class Climate : Gadget
    {
        public int Id { get; set; }
        public string title { get; set; }
        private bool condition = false;
        public int temperature { get; set; }
        public bool Condition
        {
            get { return condition; }
            set
            {
                condition = value;
            }
        }
        public Climate(string title)
            : base(title)
        {
            this.title = title;
        }
        public Climate()
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
        public void TemperatureUp()
        {
            if (15 < temperature && temperature < 29)
            {
                temperature += 1;
            }
        }
        public void TemperatureDown()
        {
            if (17 < temperature && temperature < 31)
            {
                temperature -= 1;
            }
        }
        public void TemperatureSet(int value)
        {
            if (15 < value && value < 31)
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
            return condition +", "+ "Температура установлена на: " + temperature.ToString() + "град.";
        }
    }
}
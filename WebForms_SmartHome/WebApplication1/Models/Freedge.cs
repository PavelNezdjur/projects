using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    class Freedge : HomeGoods
    {
        private string title;
        private bool condition;
        private int temperatureInSide;
        public bool Condition
        {
            get { return condition; }
        }

        public Freedge(string title)
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
        public int TemperatureValue()
        {
            return temperatureInSide;
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
            if (-1 < temperatureInSide && temperatureInSide < 4)
            {
                temperatureInSide += 1;
            }
        }
        public void TemperatureDown()
        {
            if (0 < temperatureInSide && temperatureInSide < 5)
            {
                temperatureInSide -= 1;
            }
        }
        public void TemperatureSet(int value)
        {
            if (-2 < value && value < 6)
            {
                temperatureInSide = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Climate : Gadget
    {
        private string title;
        private bool condition = false;
        private int temperature;

        public Climate(string title) : base (title)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    class TV : HomeGoods
    {
        private string title;
        private bool condition;
        private int channel = 3;
        private int volume = 5;
        public bool Condition 
        { 
            get 
            { 
                return condition; 
            } 
        }

        public TV(string title)
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
        
        public void ChannelUp()
        {
            if (0 <= channel && channel < 99)
            {
                channel += 1;
            }
        }
        public void ChannelDown()
        {
            if (1 <= channel && channel < 99)
            {
                channel -= 1;
            }
        }
        public int CurrentChannel()
        {
            return channel;
        }
        public void VolumeUp()
        {
            if (0 <= volume && volume < 99)
            {
                volume += 1;
            }
        }
        public void VolumeDown()
        {
            if (1 <= volume && volume < 99)
            {
                volume -= 1;
            }
        }
        public void Mute()
        {
            volume = 0;
        }
        public int CurrentVolume()
        {
            return volume;
        }
        public bool PowerOn()
        {
            return condition = true;
        }
        public bool PowerOff()
        {
            return condition = false;
        }

    }
}
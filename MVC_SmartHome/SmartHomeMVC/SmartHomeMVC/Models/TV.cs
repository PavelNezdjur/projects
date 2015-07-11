using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models
{
    public class TV : HomeGoods
    {
        private string title;
        private bool condition;
        private int channel;
        private int volume;
        public bool Condition
        {
            get { return condition; }
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
        public void ChangeChannel(int userChannel)
        {
            if (0 < userChannel && userChannel < 101)
            {
                channel = userChannel;
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
            return condition + ", " + "Установлен канал: " + channel.ToString() +", "+ "Громкость установлена на: " + volume.ToString();
        }
    }
}
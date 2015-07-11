using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TV : HomeGoods
    {
        private string title;
        private bool condition;
        private int channel;
        private int volume;

        public TV(string title) : base (title)
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
            do
            {
                volume -= 1;
            }
            while (volume > 0);
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

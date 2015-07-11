using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class TestAttributeClass
    {
        private string title;
        private string mark;
        private int power;

        [ColorProperty("red")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        [ColorProperty("blue")]
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }

        public TestAttributeClass(string title, string mark, int engine)
        {
            this.Mark = mark;
            this.Title = title;
            this.Power = engine;
        }
    }
}

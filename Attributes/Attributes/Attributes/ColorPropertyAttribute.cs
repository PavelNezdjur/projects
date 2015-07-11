using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColorPropertyAttribute : System.Attribute
    {
        public string color;
        public ColorPropertyAttribute() { }
        public ColorPropertyAttribute(string color)
        {
            this.color = color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Printer
    {
        public void ColorPrint(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] arr = objectType.GetProperties();
            foreach (PropertyInfo each in arr)
            {
                object[] prop = each.GetCustomAttributes(false);
                if (System.Attribute.IsDefined(each,typeof(ColorPropertyAttribute)))
                {
                   var atr = System.Attribute.GetCustomAttribute(each, typeof(ColorPropertyAttribute)) as ColorPropertyAttribute;
                   if (atr.color == "blue")
                   {
                       Console.ForegroundColor = ConsoleColor.DarkBlue;
                   }
                   if (atr.color == "red")
                   {
                       Console.ForegroundColor = ConsoleColor.Red;
                   }
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(each.GetValue(obj).ToString());
            }

        }
    }
}

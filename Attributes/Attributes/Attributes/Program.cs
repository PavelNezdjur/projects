using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAttributeClass testObject = new TestAttributeClass("BMW", "X5M", 510);
            Printer printer = new Printer();
            printer.ColorPrint(testObject);
        }
    }
}

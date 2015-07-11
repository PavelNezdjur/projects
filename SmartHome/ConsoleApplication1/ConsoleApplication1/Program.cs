using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            for (int i = 1; i > 0; i++)
            {
                menu.ShowStartMenu();
            }
        }
    }
}

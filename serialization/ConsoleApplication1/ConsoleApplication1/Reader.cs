using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Reader
    {
        private static string readPath = "option.ini";
        public static void Readpath()
        {
            try
            {
                string text;
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd().ToLower().Trim();
                }
                if (text == "bin")
                {
                    Bin bs = new Bin();
                    Menu menu = new Menu(bs);
                    menu.ShowMenu();
                }
                else if (text == "xml")
                {
                    Xml xs = new Xml();
                    Menu menu = new Menu(xs);
                    menu.ShowMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}

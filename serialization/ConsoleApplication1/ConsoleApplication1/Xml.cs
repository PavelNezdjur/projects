using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    class Xml : IOperation
    {
        protected static string path = "xmlBase.xml";
        static XmlSerializer xml_serial = new XmlSerializer(typeof(List<Employee>));

        public void Serialize(object obj)
        {
            using (var fs = new StreamWriter(path, false, Encoding.Default))
            {
                xml_serial.Serialize(fs, obj);
            }
        }
        public List<Employee> Deserialize()
        {
            List<Employee> xml_ds;
            using (FileStream fs = File.OpenRead(path))
            {
                if (!File.Exists(path) || fs.Length == 0)
                {
                    return new List<Employee>();
                }
                else
                {
                    return xml_ds = (List<Employee>)xml_serial.Deserialize(fs);
                }
            }
        }
    }
}

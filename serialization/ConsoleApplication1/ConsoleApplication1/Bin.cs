using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bin : IOperation
    {
        protected static string path = "binBase.dat";
        static BinaryFormatter bf = new BinaryFormatter();

        public void Serialize(object obj)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, obj);
            }
        }
        public List<Employee> Deserialize()
        {
            using (FileStream fs = File.OpenRead(path))
            {
                if (!File.Exists(path) || fs.Length == 0)
                {
                    return new List<Employee>();
                }
                else
                {
                    return (List<Employee>)bf.Deserialize(fs);
                }
            }
        }
    }
}

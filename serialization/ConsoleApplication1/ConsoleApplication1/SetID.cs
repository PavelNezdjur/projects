using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public abstract class SetID
    {
        private int id;
        public static int currentID;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        static int NextId()
        {
            return ++currentID;
        }
        static SetID()
        {
            currentID = 0;
        }
        public SetID()
        {
            this.Id = NextId();
        }
    }
}


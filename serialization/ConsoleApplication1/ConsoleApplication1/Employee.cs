using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public class Employee : SetID
    {
        private string name;
        private string surname;
        private string vocation;
        private int salary;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Vocation
        {
            get { return vocation; }
            set { vocation = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
                
        public Employee() { }
        public Employee(string name, string surname, string vocation, int salary, int age) : base()
        {
            ++Id;
            this.Name = name;
            this.Surname = surname;
            this.Vocation = vocation;
            this.Salary = salary;
            this.Age = age;
        }
        public override string ToString()
        {
            return "№"+Id+"."+"Имя/Фамилия сотрудника: "+Name+" "+Surname+",\n Должность: "+Vocation+",\n Оклад: "+Salary+" грн,\n Возраст: "+Age+" лет";
        }
    }
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Menu
    {
        private IOperation serialize;
        public IOperation Serialize
        {
            get { return serialize; }
            set { serialize = value; }
        }
        private List<Employee> users;
        public List<Employee> Users
        {
            get { return users; }
            set { users = value; }
        }
        public Menu() { }
        public Menu(IOperation serialize)
        {
            this.Serialize = serialize;
            this.Users = Serialize.Deserialize();
        }
        
        public void ShowMenu()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Создать запись сотрудника\n" +
                                      "2. Удалить запись сотрудника\n" +
                                      "3. Просмотреть все записи сотрудников\n" +
                                      "4. Просмотреть запись конкретного сотрудника\n" +
                                      "5. Выйти и сохранить");

                    int choose = Int32.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Users.Add(AddEmployee());
                            Console.WriteLine("Запись сотрудника добавлена");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            DeleteEmployee();
                            Console.WriteLine("Запись сотрудника удалена");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            ShowAllEmployees();
                            break;
                        case 4:
                            try
                            {
                                ShowEmployee();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка: " + ex.Message);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            Serialize.Serialize(Users);
                            Environment.Exit(0);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Выбрано неправильное действие.");
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
            }
    }
        public void ShowAllEmployees()
        {
            Console.WriteLine("Найдены следующие сотрудники: ");
            Console.WriteLine();
            foreach (Employee e in Users)
            {
               Console.WriteLine(e.ToString());
               Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowEmployee()
        {
            Console.WriteLine("Введите ID сотрудника: ");
            int searchId = Int32.Parse(Console.ReadLine());

            if (Users.Exists(i => i.Id == searchId))
            {
                Employee e = Users.Find(i => i.Id == searchId);
                Console.WriteLine(e.ToString());
            }
            else
            {
                throw new Exception("Ошибка: ID сотрудника не найднен.");
            }
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Введите ID сотрудника: ");
            int searchId = Int32.Parse(Console.ReadLine());

            if (Users.Exists(i => i.Id == searchId))

            {
                Employee e = Users.Find(i => i.Id == searchId);
                Users.Remove(e);
            }
            else
            {
                Console.WriteLine("Ошибка: ID сотрудника не найднен.");
                Console.ReadKey();
                ShowMenu();
            }
        }
        public Employee AddEmployee()
        {
            //private string name;
            //private string surname;
            //private string vocation;
            //private int salary;
            //private int age;    
            Console.WriteLine("Для создания нового сотрудника введите данные: ");
            Console.WriteLine("Имя: ");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Фамилия: ");
            string employeeSurName = Console.ReadLine();
            Console.WriteLine("Занимаемая должность: ");
            string employeeVocation = Console.ReadLine();
            Console.WriteLine("Оклад: ");
            int employeeSalary = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Возраст: ");
            int employeeAge = Int32.Parse(Console.ReadLine());
            
            Employee obj = new Employee();
            obj.Name = employeeName;
            obj.Surname = employeeSurName;
            obj.Vocation = employeeVocation;
            obj.Salary = employeeSalary;
            obj.Age = employeeAge;
            return obj;
        }
    }
}
        
      

        
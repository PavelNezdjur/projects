using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Menu
    {
        IDictionary<string, Lamp> Lamps = new Dictionary<string, Lamp>();
        IDictionary<string, Window> Windows = new Dictionary<string, Window>();
        IDictionary<string, Alarm> Alarms = new Dictionary<string, Alarm>();
        IDictionary<string, Climate> Climats = new Dictionary<string, Climate>();
        IDictionary<string, Freedge> Freedges = new Dictionary<string, Freedge>();
        IDictionary<string, TV> TVs = new Dictionary<string, TV>();

        public void ShowStartMenu()
        {
            Console.WriteLine("Вас приветствует Smart Home!");
            Console.WriteLine();
            Console.WriteLine("Для вызова справки введите 'Help'");
            Console.WriteLine("Для начала программы введите 'Start'");
            Console.WriteLine("Для выхода из программы введите 'Exit'");
            string command = Console.ReadLine();
            command = command.ToLower();
            switch (command)
            {
                case "start":
                    Console.Clear();
                    ShowMenu();
                    break;
                case "help":
                    Console.Clear();
                    Help();
                    break;
                case "exit":
                    Console.Clear();
                    Exit();
                    break;
                default:
                    Console.WriteLine("Команда не существует, попробуйте еще раз!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        public void ShowMenu()
        {
            do
            {
                ShowAllConditions();
                Console.WriteLine("Введите команду: ");
                string userString = Console.ReadLine();
                userString = userString.ToLower();
                string[] userCommand = userString.Split(new[] { ' ', ',', ':', '?', '!', '-', '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
                               

  /*Add*/       if (userCommand[1] == "add") 
                {
                    string typeGadget = userCommand[0];
                    typeGadget = new string(typeGadget.Where(ch => !char.IsDigit(ch)).ToArray()); // определяем класс
                    string addName = userCommand[0]; // определяем имя нового объекта класса
                   
                    switch (typeGadget)
                    {
                        case "lamp":
                            Lamps.Add(addName, new Lamp(addName));
                            Console.WriteLine("Добавлен объект класса 'Лампа': " + addName);
                            break;
                        case "window":
                            Windows.Add(addName, new Window(addName));
                            Console.WriteLine("Добавлен объект класса 'Окно': " + addName);
                            break;
                        case "alarm":
                            Alarms.Add(addName, new Alarm(addName));
                            Console.WriteLine("Добавлен объект класса 'Сигнализация': " + addName);
                            break;
                        case "climate":
                            Climats.Add(addName, new Climate(addName));
                            Console.WriteLine("Добавлен объект класса 'Климат-контроль': " + addName);
                            break;
                        case "freedge":
                            Freedges.Add(addName, new Freedge(addName));
                            Console.WriteLine("Добавлен объект класса 'Холодильник': " + addName);
                            break;
                        case "tv":
                            TVs.Add(addName, new TV(addName));
                            Console.WriteLine("Добавлен объект класса 'Телевизор': " + addName);
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    ShowAllConditions();
                }
 /*Remove*/     else if (userCommand[1] == "remove")
                {
                    string typeGadget = userCommand[0];
                    typeGadget = new string(typeGadget.Where(ch => !char.IsDigit(ch)).ToArray()); // определяем класс
                    string deleteName = userCommand[0]; // определяем имя объекта класса, который нужно удалить
                    switch (typeGadget)
                    {
                        case "lamp":
                            Lamps.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Лампа': " + deleteName + " удален из системы.");
                            break;
                        case "window":
                            Windows.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Окно': " + deleteName + " удален из системы.");
                            break;
                        case "alarm":
                            Alarms.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Сигнализация': " + deleteName + " удален из системы.");
                            break;
                        case "climate":
                            Alarms.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Климат-контроль': " + deleteName + " удален из системы.");
                            break;
                        case "freedge":
                            Freedges.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Холодильник': " + deleteName + " удален из системы.");
                            break;
                        case "tv":
                            TVs.Remove(deleteName);
                            Console.WriteLine("Объект класса 'Телевизор': " + deleteName + " удален из системы.");
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    ShowAllConditions();
                }
  /*Lamp*/      else if (Lamps.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Лампа': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "on":
                            Lamps[userCommand[0]].PowerOn();
                            Console.WriteLine("Текущее состояние: " + Lamps[userCommand[0]].CurrentCondition());
                            break;
                        case "off":
                            Lamps[userCommand[0]].PowerOff();
                            Console.WriteLine("Текущее состояние: " + Lamps[userCommand[0]].CurrentCondition());
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    ShowAllConditions();
                }
  /*Window*/    else if (Windows.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Окно': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "open":
                            Windows[userCommand[0]].Open();
                            Console.WriteLine("Текущее состояние: " + Windows[userCommand[0]].CurrentCondition());
                            break;
                        case "close":
                            Windows[userCommand[0]].Close();
                            Console.WriteLine("Текущее состояние: " + Windows[userCommand[0]].CurrentCondition());
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    ShowAllConditions();
                }
  /*Alarm*/     else if (Alarms.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Сигнализация': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "on":
                            Alarms[userCommand[0]].PowerOn();
                            Console.WriteLine("Текущее состояние: " + Alarms[userCommand[0]].CurrentCondition());
                            break;
                        case "off":
                            Alarms[userCommand[0]].PowerOff();
                            Console.WriteLine("Текущее состояние: " + Alarms[userCommand[0]].CurrentCondition());
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
  /*Climate*/   else if (Climats.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Климат-контроль': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "on":
                            Climats[userCommand[0]].PowerOn();
                            Console.WriteLine("Текущее состояние: " + Climats[userCommand[0]].CurrentCondition());
                            break;
                        case "off":
                            Climats[userCommand[0]].PowerOff();
                            Console.WriteLine("Текущее состояние: " + Climats[userCommand[0]].CurrentCondition());
                            break;
                        case "tup":
                            if (Climats[userCommand[0]].CurrentCondition() == true)
                            {
                                Climats[userCommand[0]].TemperatureUp();
                                Console.WriteLine("Текущая температура: " + Climats[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Климат-контроль"); }
                            break;
                        case "tdown":
                            if (Climats[userCommand[0]].CurrentCondition() == true)
                            {
                                Climats[userCommand[0]].TemperatureDown();
                                Console.WriteLine("Текущая температура: " + Climats[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Климат-контроль"); }
                            break;
                        case "tset":
                            if (Climats[userCommand[0]].CurrentCondition() == true)
                            {
                                int value = Int32.Parse(userCommand[2]);
                                Climats[userCommand[0]].TemperatureSet(value);
                                Console.WriteLine("Текущая температура: " + Climats[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Климат-контроль"); }
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
  /*Freedge*/   else if (Freedges.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Холодильник': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "on":
                            Freedges[userCommand[0]].PowerOn();
                            Console.WriteLine("Текущее состояние: " + Freedges[userCommand[0]].CurrentCondition());
                            break;
                        case "off":
                            Freedges[userCommand[0]].PowerOff();
                            Console.WriteLine("Текущее состояние: " + Freedges[userCommand[0]].CurrentCondition());
                            break;
                        case "open":
                            Freedges[userCommand[0]].Open();
                            Console.WriteLine("Текущее состояние: " + Freedges[userCommand[0]].CurrentCondition());
                            break;
                        case "close":
                            Freedges[userCommand[0]].Close();
                            Console.WriteLine("Текущее состояние: " + Freedges[userCommand[0]].CurrentCondition());
                            break;
                        case "tup":
                            if (Freedges[userCommand[0]].CurrentCondition() == true)
                            {
                                Freedges[userCommand[0]].TemperatureUp();
                                Console.WriteLine("Текущая температура: " + Freedges[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Холодильник"); }
                            break;
                        case "tdown":
                            if (Freedges[userCommand[0]].CurrentCondition() == true)
                            {
                                Freedges[userCommand[0]].TemperatureDown();
                                Console.WriteLine("Текущая температура: " + Freedges[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Холодильник"); }
                            break;
                        case "tset":
                            if (Freedges[userCommand[0]].CurrentCondition() == true)
                            {
                                int value = Int32.Parse(userCommand[2]);
                                Freedges[userCommand[0]].TemperatureSet(value);
                                Console.WriteLine("Текущая температура: " + Freedges[userCommand[0]].TemperatureValue());
                            }
                            else { Console.WriteLine("Необходимо сначала включить Холодильник"); }
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
  /*TV*/        else if (TVs.ContainsKey(userCommand[0]))
                {
                    Console.WriteLine("Найден объект типа 'Телевизор': " + userCommand[0]);
                    switch (userCommand[1])
                    {
                        case "on":
                            TVs[userCommand[0]].PowerOn();
                            Console.WriteLine("Телевизор включен: " + TVs[userCommand[0]].CurrentCondition());
                            break;
                        case "off":
                            TVs[userCommand[0]].PowerOff();
                            Console.WriteLine("Телевизор включен: " + TVs[userCommand[0]].CurrentCondition());
                            break;
                        case "vup":
                            if (TVs[userCommand[0]].CurrentCondition() == true)
                            {
                                TVs[userCommand[0]].VolumeUp();
                                Console.WriteLine("Текущая громкость: " + TVs[userCommand[0]].CurrentVolume());
                            }
                            else { Console.WriteLine("Необходимо сначала включить ТВ"); }
                            break;
                        case "vdown":
                            if (TVs[userCommand[0]].CurrentCondition() == true)
                            {
                                TVs[userCommand[0]].VolumeDown();
                                Console.WriteLine("Текущая громкость: " + TVs[userCommand[0]].CurrentVolume());
                            }
                            else { Console.WriteLine("Необходимо сначала включить ТВ"); }
                            break;
                        case "mute":
                            if (TVs[userCommand[0]].CurrentCondition() == true)
                            {
                                TVs[userCommand[0]].Mute();
                                Console.WriteLine("Текущая громкость: " + TVs[userCommand[0]].CurrentVolume());
                            }
                            else { Console.WriteLine("Необходимо сначала включить ТВ"); }
                            break;
                        case "changechannel":
                            if (TVs[userCommand[0]].CurrentCondition() == true)
                            {
                                int value = Int32.Parse(userCommand[2]);
                                TVs[userCommand[0]].ChangeChannel(value);
                                Console.WriteLine("Текущий канал: " + TVs[userCommand[0]].CurrentChannel());
                            }
                            else { Console.WriteLine("Необходимо сначала включить ТВ"); }
                            break;
                        default:
                            Console.WriteLine("Команда не существует, попробуйте еще раз!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                else { Console.WriteLine("Объект не найден"); }
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        public void Help()
        {
            Console.WriteLine("Поддерживаемые функции: \n" +
            "Add/Remove - добавить/удалить устройство;\n" +
            "On/Off - включить/выключить;\n" +
            "Open/Close - открыть/закрыть;\n" +
            "VUp/VDown/VSet/Mute - увеличить/снизить/установить/выключить громкость;\n" +
            "changechannel 10 - установить 10 кананал на тв;\n" +
            "TUp/TDown/TSet - увеличить/снизить/установить температуру;\n");
            Console.WriteLine();
            Console.WriteLine("Порядок ввода функций:\n" + 
            "Укажите: Имя_Порядковый_номер_устройства Введите_функцию;\n" + 
            "Пример: Window1 Add\n" + 
            "Чтобы изменить температуру: \n" +
            "Пример: Climate1 TUp\n" +
            "Пример: Climate1 TSet 22");
            Console.ReadKey();
            Console.Clear();
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        public void ShowAllConditions()
        {
            foreach (KeyValuePair<string, Lamp> findObject in Lamps)
            {
                Console.WriteLine("'Лампа': Название: {0}, состояние: {1}", findObject.Key, Lamps[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, Window> findObject in Windows)
            {
                Console.WriteLine("'Окно': Название: {0}, состояние: {1}", findObject.Key, Windows[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, Alarm> findObject in Alarms)
            {
                Console.WriteLine("'Сигнализация': Название: {0}, состояние: {1}", findObject.Key, Alarms[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, Climate> findObject in Climats)
            {
                Console.WriteLine("'Климат-контроль': Название: {0}, состояние: {1}, температура: {2}град.", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
            }
            foreach (KeyValuePair<string,Freedge> findObject in Freedges)
            {
                Console.WriteLine("'Холодильник': Название: {0}, состояние: {1}, температура: {2}град.", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
            }
            foreach (KeyValuePair<string, TV> findObject in TVs)
            {
                Console.WriteLine("'Телевизор': Название: {0}, состояние: {1}, громкость: {2}, канал: {3}", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentVolume(), TVs[findObject.Key].CurrentChannel());
            }
            Console.ReadKey();
            Console.Clear();
            
        }
    }       
}


            


    

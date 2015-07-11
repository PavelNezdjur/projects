using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class AlarmController : Controller
    {
        public ActionResult AlarmSH(string command = "", string gadgetName = "")
        {
            if (Session["Alarm"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, Alarm> Alarms = new Dictionary<string, Alarm>();
                // Записываем объекты в состояние сеанса
                Session["Alarm"] = Alarms;
                ViewBag.AllGadgets = Alarms;
            }
            else
            {
                IDictionary<string, Alarm> Alarms = (Dictionary<string, Alarm>)Session["Alarm"];
                switch (command)
                {
                    case "Add":
                        if (!Alarms.ContainsKey(gadgetName))
                        {
                            Alarms.Add(gadgetName, new Alarm(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Alarms;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = Alarms;
                        break;
                    case "Delete":
                        if (Alarms.ContainsKey(gadgetName))
                        {
                            Alarms.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Alarms;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = Alarms;
                        break;
                    case "On":
                        if (Alarms.ContainsKey(gadgetName) && Alarms[gadgetName].Condition == false)
                        {
                            Alarms[gadgetName].PowerOn();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Alarms;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                        ViewBag.AllGadgets = Alarms;
                        break;
                    case "Off":
                        if (Alarms.ContainsKey(gadgetName) && Alarms[gadgetName].Condition == true)
                        {
                            Alarms[gadgetName].PowerOff();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Alarms;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо выключено"; }
                        ViewBag.AllGadgets = Alarms;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["Alarm"] = Alarms;
                ViewBag.AllGadgets = Session["Alarm"];
            }
            return View();
        }
    }
}
using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class LampController : Controller
    {
        // GET: Lamp
        public ActionResult LampSH(string command = "", string gadgetName = "")
        {
            if (Session["Lamps"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, Lamp> Lamps = new Dictionary<string, Lamp>();
                // Записываем объекты в состояние сеанса
                Session["Lamps"] = Lamps;
                ViewBag.AllGadgets = Lamps;

            }
            else
            {
                IDictionary<string, Lamp> Lamps = (Dictionary<string, Lamp>)Session["Lamps"];
                switch (command)
                {
                    case "Add":
                        if (!Lamps.ContainsKey(gadgetName))
                        {
                            Lamps.Add(gadgetName, new Lamp(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Lamps;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = Lamps;
                        break;
                    case "Delete":
                        if (Lamps.ContainsKey(gadgetName))
                        {
                            Lamps.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Lamps;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = Lamps;
                        break;
                    case "On":
                        if (Lamps.ContainsKey(gadgetName) && Lamps[gadgetName].Condition == false)
                        {
                            Lamps[gadgetName].PowerOn();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Lamps;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                        ViewBag.AllGadgets = Lamps;
                        break;
                    case "Off":
                        if (Lamps.ContainsKey(gadgetName) && Lamps[gadgetName].Condition == true)
                        {
                            Lamps[gadgetName].PowerOff();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Lamps;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо выключено"; }
                        ViewBag.AllGadgets = Lamps;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["Lamps"] = Lamps;
                ViewBag.AllGadgets = Session["Lamps"];
            }
            return View();
        }
    }
}
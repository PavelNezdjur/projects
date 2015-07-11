using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class ClimateController : Controller
    {
        // GET: Climate
        public ActionResult ClimateSH(string command = "", string gadgetName = "")
        {
            if (Session["Climate"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, Climate> Climates = new Dictionary<string, Climate>();
                // Записываем объекты в состояние сеанса
                Session["Climate"] = Climates;
                ViewBag.AllGadgets = Climates;

            }
            else
            {
                IDictionary<string, Climate> Climates = (Dictionary<string, Climate>)Session["Climate"];
                switch (command)
                {
                    case "Add":
                        if (!Climates.ContainsKey(gadgetName))
                        {
                            Climates.Add(gadgetName, new Climate(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = Climates;
                        break;
                    case "Delete":
                        if (Climates.ContainsKey(gadgetName))
                        {
                            Climates.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = Climates;
                        break;
                    case "On":
                        if (Climates.ContainsKey(gadgetName) && Climates[gadgetName].Condition == false)
                        {
                            Climates[gadgetName].PowerOn();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                        ViewBag.AllGadgets = Climates;
                        break;
                    case "Off":
                        if (Climates.ContainsKey(gadgetName) && Climates[gadgetName].Condition == true)
                        {
                            Climates[gadgetName].PowerOff();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Climates;
                        break;

                    case "TemperatureUp":
                        if (Climates.ContainsKey(gadgetName) && Climates[gadgetName].Condition == true)
                        {
                            Climates[gadgetName].TemperatureUp();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Climates;
                        break;
                    case "TemperatureDown":
                        if (Climates.ContainsKey(gadgetName) && Climates[gadgetName].Condition == true)
                        {
                            Climates[gadgetName].TemperatureDown();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Climates;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Climates;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["Climate"] = Climates;
                ViewBag.AllGadgets = Session["Climate"];
            }
            return View();
        }
    }
}
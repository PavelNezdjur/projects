using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class FreedgeController : Controller
    {
        // GET: Freedge
        public ActionResult FreedgeSH(string command = "", string gadgetName = "")
        {
            if (Session["Freedge"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, Freedge> Freedges = new Dictionary<string, Freedge>();
                // Записываем объекты в состояние сеанса
                Session["Freedge"] = Freedges;
                ViewBag.AllGadgets = Freedges;

            }
            else
            {
                IDictionary<string, Freedge> Freedges = (Dictionary<string, Freedge>)Session["Freedge"];
                switch (command)
                {
                    case "Add":
                        if (!Freedges.ContainsKey(gadgetName))
                        {
                            Freedges.Add(gadgetName, new Freedge(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                    case "Delete":
                        if (Freedges.ContainsKey(gadgetName))
                        {
                            Freedges.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                    case "On":
                        if (Freedges.ContainsKey(gadgetName) && Freedges[gadgetName].Condition == false)
                        {
                            Freedges[gadgetName].PowerOn();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                    case "Off":
                        if (Freedges.ContainsKey(gadgetName) && Freedges[gadgetName].Condition == true)
                        {
                            Freedges[gadgetName].PowerOff();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                    
                    case "TemperatureUp":
                        if (Freedges.ContainsKey(gadgetName) && Freedges[gadgetName].Condition == true)
                        {
                            Freedges[gadgetName].TemperatureUp();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                    case "TemperatureDown":
                        if (Freedges.ContainsKey(gadgetName) && Freedges[gadgetName].Condition == true)
                        {
                            Freedges[gadgetName].TemperatureDown();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Freedges;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = Freedges;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["Freedge"] = Freedges;
                ViewBag.AllGadgets = Session["Freedge"];
            }
            return View();
        }
    }
}
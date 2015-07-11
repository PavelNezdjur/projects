using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class WindowController : Controller
    {
        public ActionResult WindowSH(string command = "", string gadgetName = "")
        {
            if (Session["Window"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, Window> Windows = new Dictionary<string, Window>();
                // Записываем объекты в состояние сеанса
                Session["Window"] = Windows;
                ViewBag.AllGadgets = Windows;

            }
            else
            {
                IDictionary<string, Window> Windows = (Dictionary<string, Window>)Session["Window"];
                switch (command)
                {
                    case "Add":
                        if (!Windows.ContainsKey(gadgetName))
                        {
                            Windows.Add(gadgetName, new Window(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Windows;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = Windows;
                        break;
                    case "Delete":
                        if (Windows.ContainsKey(gadgetName))
                        {
                            Windows.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Windows;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = Windows;
                        break;
                    case "Open":
                        if (Windows.ContainsKey(gadgetName) && Windows[gadgetName].Condition == false)
                        {
                            Windows[gadgetName].Open();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Windows;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже открыто"; }
                        ViewBag.AllGadgets = Windows;
                        break;
                    case "Close":
                        if (Windows.ContainsKey(gadgetName) && Windows[gadgetName].Condition == true)
                        {
                            Windows[gadgetName].Close();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = Windows;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо закрыто"; }
                        ViewBag.AllGadgets = Windows;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["Window"] = Windows;
                ViewBag.AllGadgets = Session["Window"];
            }
            return View();
        }
    }
}
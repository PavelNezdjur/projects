using SmartHomeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class TVController : Controller
    {
        // GET: TV
        public ActionResult TVSH(string command = "", string gadgetName = "")
        {
            if (Session["TV"] == null)
            {
                // Создаем коллекцию объектов
                IDictionary<string, TV> TVs = new Dictionary<string, TV>();
                // Записываем объекты в состояние сеанса
                Session["TV"] = TVs;
                ViewBag.AllGadgets = TVs;

            }
            else
            {
                IDictionary<string, TV> TVs = (Dictionary<string, TV>)Session["TV"];
                switch (command)
                {
                    case "Add":
                        if (!TVs.ContainsKey(gadgetName))
                        {
                            TVs.Add(gadgetName, new TV(gadgetName));
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем уже существует в Доме"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "Delete":
                        if (TVs.ContainsKey(gadgetName))
                        {
                            TVs.Remove(gadgetName);
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "On":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == false)
                        {
                            TVs[gadgetName].PowerOn();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "Off":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].PowerOff();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    
                    case "VolumeUp":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].VolumeUp();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "VolumeDown":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].VolumeDown();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "Mute":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].Mute();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "ChannelDown":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].ChannelDown();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                    case "ChannelUp":
                        if (TVs.ContainsKey(gadgetName) && TVs[gadgetName].Condition == true)
                        {
                            TVs[gadgetName].ChannelUp();
                            ViewBag.AllGadgets = "";
                            ViewBag.AllGadgets = TVs;
                        }
                        else { ViewBag.Error = "Устройство с таким именем не найдено в Доме либо не включено"; }
                        ViewBag.AllGadgets = TVs;
                        break;
                }
                // Записываем объект в состояние сеанса
                Session["TV"] = TVs;
                ViewBag.AllGadgets = Session["TV"];
            }
            return View();
        }
    }
}
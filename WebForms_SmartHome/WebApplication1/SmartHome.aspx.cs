using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class SmartHome : System.Web.UI.Page
    {
        string gadgetToChange;
        int tempSet;
       
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Add.Click += OnClick;
                Delete.Click += OnClick;
                On.Click += OnClick;
                Off.Click += OnClick;
                Open.Click += OnClick;
                Close.Click += OnClick;
                TempUp.Click += OnClick;
                TempDown.Click += OnClick;
                OkTempSet.Click += OnClick;
                VolUp.Click += OnClick;
                VolDown.Click += OnClick;
                Mute.Click += OnClick;
                ChannelUp.Click += OnClick;
                ChannelDown.Click += OnClick;
               
                errorLabel.Text = "";
            }
            else
            {
                IDictionary<string, Lamp> Lamps = new Dictionary<string, Lamp>();
                IDictionary<string, Window> Windows = new Dictionary<string, Window>();
                IDictionary<string, Alarm> Alarms = new Dictionary<string, Alarm>();
                IDictionary<string, Climate> Climats = new Dictionary<string, Climate>();
                IDictionary<string, Freedge> Freedges = new Dictionary<string, Freedge>();
                IDictionary<string, TV> TVs = new Dictionary<string, TV>();
                
                // Записываем объекты в состояние сеанса
                Session["Lamp"] = Lamps;
                Session["Window"] = Windows;
                Session["Alarm"] = Alarms;
                Session["Climate"] = Climats;
                Session["Freedge"] = Freedges;
                Session["TV"] = TVs;
                
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            // Получаем объекты из состояния сеанса
            IDictionary<string, Lamp> Lamps = (IDictionary<string, Lamp>)Session["Lamp"];
            IDictionary<string, Window> Windows = (IDictionary<string, Window>)Session["Window"];
            IDictionary<string, Alarm> Alarms = (IDictionary<string, Alarm>)Session["Alarm"];
            IDictionary<string, Climate> Climats = (IDictionary<string, Climate>)Session["Climate"];
            IDictionary<string, Freedge> Freedges = (Dictionary<string, Freedge>)Session["Freedge"];
            IDictionary<string, TV> TVs = (Dictionary<string, TV>)Session["TV"];

            

            //Скрываем все кнопки управления
            On.Visible = false;
            Off.Visible = false;
            Open.Visible = false;
            Close.Visible = false;
            TempUp.Visible = false;
            TempDown.Visible = false;
            SetTemp.Visible = false;
            VolUp.Visible = false;
            VolDown.Visible = false;
            Mute.Visible = false;
            ChannelUp.Visible = false;
            ChannelDown.Visible = false;
            OkTempSet.Visible = false;
            
            switch (choosed.Text)
            {
/*Сигнализ*/   case "Сигнализация":
                    On.Visible = true;
                    Off.Visible = true;
                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!Alarms.ContainsKey(gadgetName.Text))
                            {
                                Alarms.Add(gadgetName.Text, new Alarm(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, Alarm> findObject in Alarms)
                                {
                                    usedGadget.Text += string.Format("'Сигнализация': Название: {0}, состояние: {1} <br />", findObject.Key, Alarms[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (Alarms.ContainsKey(gadgetName.Text))
                            {
                                Alarms.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Alarm> findObject in Alarms)
                                {
                                    usedGadget.Text += string.Format("'Сигнализация': Название: {0}, состояние: {1} <br />", findObject.Key, Alarms[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "On":
                            if (Alarms.ContainsKey(gadgetName.Text))
                            {
                                Alarms[gadgetName.Text].PowerOn();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Alarm> findObject in Alarms)
                                {
                                    usedGadget.Text += string.Format("'Сигнализация': Название: {0}, состояние: {1} <br />", findObject.Key, Alarms[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "Off":
                            if (Alarms.ContainsKey(gadgetName.Text))
                            {
                                Alarms[gadgetName.Text].PowerOff();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Alarm> findObject in Alarms)
                                {
                                    usedGadget.Text += string.Format("'Сигнализация': Название: {0}, состояние: {1} <br />", findObject.Key, Alarms[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                    }
                    break;
/*Лампы*/       case "Лампы":
                    On.Visible = true;
                    Off.Visible = true;
                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!Lamps.ContainsKey(gadgetName.Text))
                            {
                                Lamps.Add(gadgetName.Text, new Lamp(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, Lamp> findObject in Lamps)
                                {
                                    usedGadget.Text += string.Format("'Лампа': Название: {0}, состояние: {1} <br />", findObject.Key, Lamps[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (Lamps.ContainsKey(gadgetName.Text))
                            {
                                Lamps.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Lamp> findObject in Lamps)
                                {
                                    usedGadget.Text += string.Format("'Лампа': Название: {0}, состояние: {1} <br />", findObject.Key, Lamps[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "On":
                            if (Lamps.ContainsKey(gadgetName.Text))
                            {
                                Lamps[gadgetName.Text].PowerOn();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Lamp> findObject in Lamps)
                                {
                                    usedGadget.Text += string.Format("'Лампа': Название: {0}, состояние: {1} <br />", findObject.Key, Lamps[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "Off":
                            if (Lamps.ContainsKey(gadgetName.Text))
                            {
                                Lamps[gadgetName.Text].PowerOff();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Lamp> findObject in Lamps)
                                {
                                    usedGadget.Text += string.Format("'Лампа': Название: {0}, состояние: {1} <br />", findObject.Key, Lamps[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                    }
                    break;
/*Окна*/        case "Окна":
                    Open.Visible = true;
                    Close.Visible = true;
                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!Windows.ContainsKey(gadgetName.Text))
                            {
                                Windows.Add(gadgetName.Text, new Window(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, Window> findObject in Windows)
                                {
                                    usedGadget.Text += string.Format("'Окно': Название: {0}, состояние: {1} <br />", findObject.Key, Windows[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (Windows.ContainsKey(gadgetName.Text))
                            {
                                Windows.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Window> findObject in Windows)
                                {
                                    usedGadget.Text += string.Format("'Окно': Название: {0}, состояние: {1} <br />", findObject.Key, Windows[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "Open":
                            if (Windows.ContainsKey(gadgetName.Text))
                            {
                                Windows[gadgetName.Text].Open();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Window> findObject in Windows)
                                {
                                    usedGadget.Text += string.Format("'Окно': Название: {0}, состояние: {1} <br />", findObject.Key, Windows[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "Close":
                            if (Windows.ContainsKey(gadgetName.Text))
                            {
                                Windows[gadgetName.Text].Close();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Window> findObject in Windows)
                                {
                                    usedGadget.Text += string.Format("'Окно': Название: {0}, состояние: {1} <br />", findObject.Key, Windows[findObject.Key].CurrentCondition());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                    }
                    break;
/*TV*/          case "Телевизор":
                    On.Visible = true;
                    Off.Visible = true;
                    VolUp.Visible = true;
                    VolDown.Visible = true;
                    Mute.Visible = true;
                    ChannelUp.Visible = true;
                    ChannelDown.Visible = true;
                    
                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!TVs.ContainsKey(gadgetName.Text))
                            {
                                TVs.Add(gadgetName.Text, new TV(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (TVs.ContainsKey(gadgetName.Text))
                            {
                                TVs.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "On":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == false)
                            {
                                TVs[gadgetName.Text].PowerOn();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br />уже включено"; }
                            break;
                        case "Off":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].PowerOff();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br />уже выключено"; }
                            break;
                        case "VolUp":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].VolumeUp();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br /> телевизор выключен"; }
                            break;
                        case "VolDown":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].VolumeDown();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br /> телевизор выключен"; }
                            break;
                        case "Mute":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].Mute();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br /> телевизор выключен"; }
                            break;
                        case "ChannelUp":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].ChannelUp();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br /> телевизор выключен"; }
                            break;
                        case "ChannelDown":
                            if (TVs.ContainsKey(gadgetName.Text) && TVs[gadgetName.Text].Condition == true)
                            {
                                TVs[gadgetName.Text].ChannelDown();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, TV> findObject in TVs)
                                {
                                    usedGadget.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме <br /> или <br /> телевизор выключен"; }
                            break;
                        
                    }
                    break;
/*Кондиционер*/
            case "Кондиционер":
                    On.Visible = true;
                    Off.Visible = true;
                    TempUp.Visible = true;
                    TempDown.Visible = true;
                    OkTempSet.Visible = true;
                    SetTemp.Visible = true;


                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!Climats.ContainsKey(gadgetName.Text))
                            {
                                Climats.Add(gadgetName.Text, new Climate(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (Climats.ContainsKey(gadgetName.Text))
                            {
                                Climats.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "On":
                            if (Climats.ContainsKey(gadgetName.Text) && Climats[gadgetName.Text].Condition == false)
                            {
                                Climats[gadgetName.Text].PowerOn();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме либо уже включено"; }
                            break;
                        case "Off":
                            if (Climats.ContainsKey(gadgetName.Text) && Climats[gadgetName.Text].Condition == true)
                            {
                                Climats[gadgetName.Text].PowerOff();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме либо уже выклчено"; }
                            break;
                        case "TempUp":
                            if (Climats.ContainsKey(gadgetName.Text) && Climats[gadgetName.Text].Condition == true)
                            {
                                Climats[gadgetName.Text].TemperatureUp();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме либо нужно включить кондиционер"; }
                            break;
                        case "TempDown":
                            if (Climats.ContainsKey(gadgetName.Text) && Climats[gadgetName.Text].Condition == true)
                            {
                                Climats[gadgetName.Text].TemperatureDown();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме либо нужно включить кондиционер"; }
                            break;
                        case "OkTempSet":

                            tempSet = (int)Session["TempToSet"];
                            if (Climats.ContainsKey(gadgetName.Text) && Climats[gadgetName.Text].Condition == true)
                            {
                                Climats[gadgetName.Text].TemperatureSet(tempSet);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Climate> findObject in Climats)
                                {
                                    usedGadget.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме либо нужно включить кондиционер"; }
                            break;
                    }
                    break;
/*Холодильник*/
            case "Холодильник":
                    On.Visible = true;
                    Off.Visible = true;
                    TempUp.Visible = true;
                    TempDown.Visible = true;
                    OkTempSet.Visible = true;
                    SetTemp.Visible = true;

                    switch (((Button)sender).ID)
                    {
                        case "Add":
                            if (!Freedges.ContainsKey(gadgetName.Text))
                            {
                                Freedges.Add(gadgetName.Text, new Freedge(gadgetName.Text));
                                usedGadget.Text = null;
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем уже существует в Доме"; }
                            break;
                        case "Delete":
                            if (Freedges.ContainsKey(gadgetName.Text))
                            {
                                Freedges.Remove(gadgetName.Text);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме"; }
                            break;
                        case "On":
                            if (Freedges.ContainsKey(gadgetName.Text) && Freedges[gadgetName.Text].Condition == false)
                            {
                                Freedges[gadgetName.Text].PowerOn();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме или холодильник уже влючен"; }
                            break;
                        case "Off":
                            if (Freedges.ContainsKey(gadgetName.Text) && Freedges[gadgetName.Text].Condition == true)
                            {
                                Freedges[gadgetName.Text].PowerOff();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме или холодильник не включен"; }
                            break;
                        case "TempUp":
                            if (Freedges.ContainsKey(gadgetName.Text) && Freedges[gadgetName.Text].Condition == true)
                            {
                                Freedges[gadgetName.Text].TemperatureUp();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме или холодильник не включен"; }
                            break;
                        case "TempDown":
                            if (Freedges.ContainsKey(gadgetName.Text) && Freedges[gadgetName.Text].Condition == true)
                            {
                                Freedges[gadgetName.Text].TemperatureDown();
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме или холодильник не включен"; }
                            break;
                        case "OkTempSet":
                            tempSet = (int)Session["TempToSet"];
                            if (Freedges.ContainsKey(gadgetName.Text) && Freedges[gadgetName.Text].Condition == true)
                            {
                                Freedges[gadgetName.Text].TemperatureSet(tempSet);
                                usedGadget.Text = "";
                                foreach (KeyValuePair<string, Freedge> findObject in Freedges)
                                {
                                    usedGadget.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
                                }
                            }
                            else { errorLabel.Text = "Устройство с таким именем не найдено в Доме или холодильник не включен"; }
                            break;
                    }
                    break;
            }

            allGadgetsLabel.Text = "";

            foreach (KeyValuePair<string, Alarm> findObject in Alarms)
            {
                allGadgetsLabel.Text += string.Format("'Сигнализация': Название: {0}, состояние: {1} <br />", findObject.Key, Alarms[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, Lamp> findObject in Lamps)
            {
                allGadgetsLabel.Text += string.Format("'Лампа': Название: {0}, состояние: {1} <br />", findObject.Key, Lamps[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, Window> findObject in Windows)
            {
                allGadgetsLabel.Text += string.Format("'Окно': Название: {0}, состояние: {1} <br />", findObject.Key, Windows[findObject.Key].CurrentCondition());
            }
            foreach (KeyValuePair<string, TV> findObject in TVs)
            {
                allGadgetsLabel.Text += string.Format("'TV': Название: {0}, состояние: {1}, канал: {2}, громкость: {3} <br />", findObject.Key, TVs[findObject.Key].CurrentCondition(), TVs[findObject.Key].CurrentChannel(), TVs[findObject.Key].CurrentVolume());
            }
            foreach (KeyValuePair<string, Climate> findObject in Climats)
            {
                allGadgetsLabel.Text += string.Format("'Кондиционер': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Climats[findObject.Key].CurrentCondition(), Climats[findObject.Key].TemperatureValue());
            }
            foreach (KeyValuePair<string, Freedge> findObject in Freedges)
            {
                allGadgetsLabel.Text += string.Format("'Холодильник': Название: {0}, состояние: {1}, Температура: {2} <br />", findObject.Key, Freedges[findObject.Key].CurrentCondition(), Freedges[findObject.Key].TemperatureValue());
            }

            Session["Lamp"] = Lamps;
            Session["Window"] = Windows;
            Session["Alarm"] = Alarms;
            Session["Climate"] = Climats;
            Session["Freedge"] = Freedges;
            Session["TV"] = TVs;
        }
        protected void gadgetName_TextChanged(object sender, EventArgs e)
        {
            gadgetToChange = string.Format(gadgetName.ToString());
        }
        protected void gadgetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            choosed.Text = gadgetType.SelectedItem.ToString();
        }
        protected void SetTemp_TextChanged(object sender, EventArgs e)
        {
            tempSet = Int32.Parse(SetTemp.Text.ToString());
            Session["TempToSet"] = tempSet;
        }
    }
}
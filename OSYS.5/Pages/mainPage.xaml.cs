using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Threading;
using System.Windows.Controls.Theming;
using Microsoft.Expression.Shapes;
using OSYS.Classes;
using System.Diagnostics;
using System.Xml.Linq;
using System.Windows.Browser;
using OSYS.Classes.interfaces;
using OSYS.Controls;
using OSYS.Web;

namespace OSYS.Pages
{
    public partial class mainPage : Page
    {
        int menuOpenTime = 0;
        public int serviceID;
        public mainPage()
        {
            InitializeComponent();
            txtUserName.Text = "";
            btnMenuEffect.Opacity = 0;
            spTrayMessage.Opacity = 0;
            MenuControl();

            Loaded += new RoutedEventHandler(mainPage_Loaded);
        }

        private void mainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            HtmlPage.Plugin.Focus();
            Focus();
            uiDriver = new UIDriver(this, gridMain);
            uiDriver.PageLoading += new PageEventHandler(uiDriver_PageLoading);
            uiDriver.PageLoaded += new PageEventHandler(uiDriver_PageLoaded);
            uiDriver.PageUnLoading += new PageEventHandler(uiDriver_PageUnLoading);
            uiDriver.AuthenticationSucceded += new AuthenticatedHandler(uiDriver_AuthenticationSucceded);
            uiDriver.LogOff += new EventHandler(uiDriver_LogOff);

            if (Security.CurrentUser == null) uiDriver.Activate(EPages.Logon);

            DispatcherTimer clockTimer = new DispatcherTimer();
            clockTimer.Interval = TimeSpan.FromSeconds(1);
            clockTimer.Tick += new EventHandler(clockTimer_Tick);
            clockTimer.Start();

            timerMessage.Tick += new EventHandler(timerMessage_Tick);
            sbMenuOpen.Completed += new EventHandler(sbMenuOpen_Completed);
            sbMenuClose.Completed += new EventHandler(sbMenuClose_Completed);

            CTimer trayClock = new CTimer();
            trayClock.SetTimeout(trayClock, Clock, 1);
            trayClock.Start();


            foreach (var item in stackPanelMainMenu.Children)
            {
                try
                {
                    //(item as Button).MouseMove += (s, ea) =>
                    //        {
                    //            menuOpenTime = 0;
                    //        };
                }
                catch
                {


                }
            }


            try
            {
                Dispatcher.BeginInvoke(() =>
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    AssemblyName name = new AssemblyName(assembly.FullName);
                    txtFooter.Text = string.Format(txtFooter.Text, name.Version.ToString());
                });
            }
            catch (Exception x)
            {
#if DEBUG
                MessageBox.Show(x.Message);
#endif
            }



        }

        Key pressedKey = Key.None;
        bool isSHIFTPressed = false;
        bool isALTPressed = false;
        bool isCTRLPressed = false;

        public Key PressedKey { get { return pressedKey; } }
        public bool IsSHIFTPressed { get { return isSHIFTPressed; } }
        public bool IsALTPressed { get { return isALTPressed; } }
        public bool IsCTRLPressed { get { return isCTRLPressed; } }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            pressedKey = e.Key;
            isCTRLPressed = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
            isSHIFTPressed = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
            isALTPressed = (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;
        }




        void Clock(object o)
        {

            Dispatcher.BeginInvoke(() =>
            {
                txtClock.Text = UIDriver.GetFormattedDateTime(UIDriver.GetTime());
                if (UIDriver.GetTime().Second == 30) sbHeaderChange.Begin();
                if (IsMenuOpened && menuOpenTime++ == 4)
                {
                    CloseMenu();
                }
                (o as CTimer).SetTimeout(o, Clock, 1);
            });
        }



        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            pressedKey = Key.None;
            isCTRLPressed = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
            isSHIFTPressed = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
            isALTPressed = (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;
        }

        #region MESSAGE BOX

        public void MsgBox(string msg, int showPeriod)
        {
            cMessageBox1.Show(msg, showPeriod);
        }
        public void MsgBox(string msg, DialogResultHandler r)
        {
            cMessageBox1.Show(msg, r);
        }
        public void MsgBox(string msg, EIcon icon)
        {
            cMessageBox1.Show(msg, icon);
        }
        public void MsgBox(string msg, EIcon icon, DialogResultHandler r)
        {
            cMessageBox1.Show(msg, icon, r);
        }
        public void MsgBox(string msg, EIcon icon, int showPeriod)
        {
            cMessageBox1.Show(msg, icon, showPeriod);
        }
        public void MsgBox(string msg, EButtons b, DialogResultHandler r)
        {
            cMessageBox1.Show(msg, b, r);
        }

        public void MsgBox(Control control, EButtons b, DialogResultHandler r)
        {
            cMessageBox1.Show(control, b, r);
        }

        public void MsgBox(IMsgBoxControl control, EButtons b, DialogResultHandler r)
        {
            cMessageBox1.Show(control, b, r);
        }

        public void MsgBox(string msg, EButtons b, EIcon icon)
        {
            cMessageBox1.Show(msg, b, icon);
        }
        public void MsgBox(string msg, EButtons b, EIcon icon, DialogResultHandler r)
        {
            cMessageBox1.Show(msg, b, icon, r);
        }

        public void BusyStart(string msg)
        {
            cMessageBox1.BusyStart(msg);
        }

        public void SetBusyText(string msg)
        {
            cMessageBox1.SetBusyText(msg);
        }

        public void BusyEnd()
        {
            cMessageBox1.BusyEnd();
        }

        #endregion

        #region TRAY MESSAGE


        DispatcherTimer timerMessage = new DispatcherTimer();
        //DateTime dt=DateTime.Now;
        Brush redBrush = new SolidColorBrush(Colors.Red);
        Brush yellowBrush = new SolidColorBrush(Colors.Yellow);
        Brush whiteBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x91, 0x91, 0x91));

        public void TrayMsgShow(string Message, int second, int severity)
        {
            Dispatcher.BeginInvoke(() =>
            {
                timerMessage.Stop();
                sbMessageOpen.Stop();

                if (severity == 0)
                {
                    txtMessage.Foreground = whiteBrush;
                    imageTrayMessage.Source = (Resources["li"] as ImageBrush).ImageSource;
                }
                else if (severity == 1)
                {
                    txtMessage.Foreground = yellowBrush;
                    imageTrayMessage.Source = (Resources["lw"] as ImageBrush).ImageSource;
                }
                else if (severity == 2)
                {
                    txtMessage.Foreground = redBrush;
                    imageTrayMessage.Source = (Resources["le"] as ImageBrush).ImageSource;
                }
                txtMessage.Text = Message;
                spTrayMessage.Opacity = 1;
                timerMessage.Interval = TimeSpan.FromSeconds(second);
                timerMessage.Start();
            });
        }

        void timerMessage_Tick(object sender, EventArgs e)
        {
            timerMessage.Stop();
            sbMessageOpen.Begin();

        }

        public void AddTrayIcon(UserControl uc)
        {
            if (!spTrayIcons.Children.Contains(uc))
                spTrayIcons.Children.Add(uc);
        }

        public void RemoveTrayIcon(UserControl uc)
        {
            spTrayIcons.Children.Remove(uc);
        }

        public void ClearTray()
        {
            spTrayIcons.Children.Clear();
        }

        #endregion

        void uiDriver_LogOff(object sender, EventArgs e)
        {
            LogoffUser();

        }

        void uiDriver_AuthenticationSucceded(object sender, AuthenticationEventArgs e)
        {
            Security.CurrentUser = e.AuthenticatedUser as CUser;
            SetUserProfile();
            AuthorizeUser();
        }

        void SetUserProfile()
        {
            //SetBrightness ((double) Security.CurrentUser.GetProfileItem("Brightness"));
            //SetContrast((double)Security.CurrentUser.GetProfileItem("Contrast"));
        }

        void AuthorizeUser()
        {
            txtUserName.Text = UserSession.PersonelName;
            uiDriver.Activate(EPages.Initial);

            OpenMenu();

        }

        void LogoffUser()
        {

            txtUserName.Text = "";
            //btnVessels.Visibility = btnOperations.Visibility =
            //   btnSettings.Visibility = btnUserProfile.Visibility =
            //   btnReports.Visibility = btnLogoff.Visibility = Visibility.Collapsed;
            //btnLogon.Visibility = Visibility.Visible;
        }

        void uiDriver_PageUnLoading(BasePage page)
        {
            ClearTray();
        }

        void uiDriver_PageLoaded(BasePage page)
        {
            txtPageName.Text = page.Title;
        }

        void uiDriver_PageLoading(BasePage page)
        {

        }

        UIDriver uiDriver = null;


        void sbMenuClose_Completed(object sender, EventArgs e)
        {
            btnMenuEffect.Opacity = 0;
        }

        void sbMenuOpen_Completed(object sender, EventArgs e)
        {
            btnMenuEffect.Opacity = 0;
        }

        void clockTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                //if (UI.IsClockUTC)
                //    txtClock.Text = UIDriver.GetTime().ToString("dd MMMM yyyy HH:mm:ss UTC");
                //else
                txtClock.Text = UIDriver.GetTime().ToLocalTime().ToString("dd MMMM yyyy HH:mm:ss");
                // txtClock.Text = UIDriver.GetFormattedDateTime(UIDriver.GetTime());
                if (UIDriver.GetTime().Second == 30) sbHeaderChange.Begin();
            });
        }

        //private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (comboBox1.SelectedIndex != -1)
        //    {
        //        var theme = ThemeFactory.GetTheme((AvailableThemes)comboBox1.SelectedItem);
        //        ThemeFactory.ApplyTheme(gridMain, theme);

        //    }
        //}

        #region MENU CONTROL

        public void MenuControl()
        {
            switch (UserSession.Role)
            {
                case "Fizyoterapist": this.MenuFizyoterapist(); break;
                case "Resepsiyonsit": this.MenuResepsiyonist(); break;
                default:
                    break;
            }
        }

        public void MenuFizyoterapist()
        {
            #region FizyoterapistGosterilecekMenuler

            c1AccordionItem2.IsExpanded = true;
            c1AccordionItem2.IsExpandable = true;
            c1AccordionItem2.IsEnabled = true;
            btnFizyoterapistRe.IsEnabled = true;

            #endregion

            #region FizyoterapistGösterilmeyecekMenuler

            c1AccordionItem1.IsExpanded = false;
            c1AccordionItem1.IsExpandable = false;
            btnGroup.Visibility = System.Windows.Visibility.Collapsed;   //Servisler
            btnCustomer.Visibility = System.Windows.Visibility.Collapsed;//ServisTanımlama
            btnPaket.Visibility = System.Windows.Visibility.Collapsed; //Paketler
            btnFizyoterapist.Visibility = System.Windows.Visibility.Collapsed;
            btnRezervasyon.Visibility = System.Windows.Visibility.Collapsed;
            btnAyarlar.Visibility = System.Windows.Visibility.Collapsed;
            btnOdeme.Visibility = System.Windows.Visibility.Collapsed;
            c1AccordionItem3.IsExpandable = false;
            c1AccordionItem3.IsExpanded = false;

            #endregion
        }

        public void MenuResepsiyonist()
        {
            #region ResepsiyonGosterilecekMenuler

            c1AccordionItem2.IsExpanded = true;
            c1AccordionItem2.IsExpandable = true;
            c1AccordionItem2.IsEnabled = true;
            btnRezervasyon.IsEnabled = true;

            #endregion

            #region ResepsiyonGosterilmeyecekMenuler

            c1AccordionItem1.IsEnabled = false;
            c1AccordionItem1.IsExpandable = false;
            c1AccordionItem1.IsExpanded = false;
            c1AccordionItem3.IsEnabled = false;
            c1AccordionItem3.IsExpandable = false;
            c1AccordionItem3.IsExpanded = false;
            #endregion
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Test);
            CloseMenu();
        }

        private void btnLogon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Logon);
            CloseMenu();
        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("Çıkmak istiyormusunuz.?", EButtons.YesNo, EIcon.Question, (r) =>
            {
                if (r == EButton.Yes)
                {
                    uiDriver.Activate(EPages.Logon);
                    CloseMenu();
                }
            });
        }

        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
            CloseMenu();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Settings);
            CloseMenu();
        }

        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Profile);
            CloseMenu();
        }

        private void btnSystem_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.System);
            CloseMenu();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Reports);
            CloseMenu();
        }

        private void btnVesselMap_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Vessels);
            CloseMenu();
        }

        private void btnTest2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Test2);
            CloseMenu();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Help);
            CloseMenu();
        }

        private void btnOpenMenu_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsMenuOpened) CloseMenu(); else OpenMenu();
        }

        private void btnOpenMenu_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnMenuEffect.Opacity = .4f;
        }

        private void btnOpenMenu_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnMenuEffect.Opacity = 0;
        }

        void OpenMenu()
        {
            if (!IsMenuOpened)
            {
                sbMenuOpen.Begin();
                IsMenuOpened = true;
                menuOpenTime = 0;
            }
        }

        void CloseMenu()
        {
            if (IsMenuOpened)
            {
                sbMenuClose.Begin();
                IsMenuOpened = false;
                DSCapriceOfis context = new DSCapriceOfis();

            }
        }

        bool IsMenuOpened = false;




        #endregion

        public void NotImplemented()
        {
            MsgBox("Yapım aşamasında", EButtons.Ok, EIcon.Warning);
        }


        internal void SetBrightness(double p)
        {
            //DEFAULT VALUE 0 (-1:1)
            // ContrastBrightness.Brightness = p / 100f;
        }

        internal void SetContrast(double p)
        {
            //DEFAULT VALUE 1 (0:2)
            // ContrastBrightness.Contrast = p / 100f;
        }
        CPictureViewer pictureViewer = new CPictureViewer();


        internal void ShowPicture(ImageSource bmp)
        {
            if (!LayoutRoot.Children.Contains(pictureViewer))
                LayoutRoot.Children.Add(pictureViewer);

            pictureViewer.ShowPicture(bmp);
        }

        private void btnOperations44_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {

            //uiDriver.Activate(EPages.CustomerGroup);
            uiDriver.Activate(EPages.CustomerGroup);
            CloseMenu();


        }

        private void btnRezervasyon_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Rezervasyon);
            CloseMenu();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {

            uiDriver.Activate(EPages.ServiceDefinition);
            CloseMenu();

        }

        private void btnMeter_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Meter);
            CloseMenu();
        }

        private void btnPrice_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Price);
            CloseMenu();

        }

        private void btnTariff_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Tariff);
            CloseMenu();

        }

        private void btnShowMeter_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.MeterMonth);
            CloseMenu();
        }

        private int _serviceID;
        public int ServiceID { get { return _serviceID; } set { _serviceID = value; } }

        private void btnCustomerMeter_Click(object sender, RoutedEventArgs e)
        {
            ServiceListControl serviceListModel = new ServiceListControl();
            MsgBox((IMsgBoxControl)serviceListModel, EButtons.OkCancel, (r) =>
            {
                if (r == EButton.Ok)
                {

                    uiDriver.Activate(EPages.CustomerMeter);
                    txtPageName.Text = ServiceListControl.ServisAdi;
                    CloseMenu();
                }

            });


        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Invoice);
            CloseMenu();
        }

        private void btnInvoiceReport_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.InvoiceReport);
            CloseMenu();

        }

        private void btnPayInvoice_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.PayInvoice);
            CloseMenu();
        }

        private void btnShowInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMeterParameter_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.MeterParameter);
            CloseMenu();

        }

        private void btnlogOut_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("Çıkmak istiyormusunuz ?", EButtons.YesNo, EIcon.Question, (r) =>
            {
                if (r == EButton.Yes)
                {
                    uiDriver.Activate(EPages.Logon);
                    CloseMenu();
                }
            });

        }

        private void btnReports_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void c1AccordionItem4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MsgBox("Çıkmak istiyormusunuz.?", EButtons.YesNo, EIcon.Question, (r) =>
            {
                if (r == EButton.Yes)
                {
                    uiDriver.Activate(EPages.Logon);
                    CloseMenu();
                }
            });
        }

        private void c1AccordionItem4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MsgBox("Çıkmak istiyormusunuz.?", EButtons.YesNo, EIcon.Question, (r) =>
            {
                if (r == EButton.Yes)
                {
                    uiDriver.Activate(EPages.Logon);
                    //c1Accordion1.Visibility = System.Windows.Visibility.Collapsed;
                    CloseMenu();
                }
            });

        }

        private void c1AccordionItem4_IsExpandedChanged(object sender, C1.Silverlight.PropertyChangedEventArgs<bool> e)
        {

            if (e.NewValue)
            {
                MsgBox("Çıkmak istiyormusunuz.?", EButtons.YesNo, EIcon.Question, (r) =>
                {
                    if (r == EButton.Yes)
                    {
                        uiDriver.Activate(EPages.Logon);
                        //c1Accordion1.Visibility = System.Windows.Visibility.Collapsed;
                        CloseMenu();
                    }
                });
            }
        }

        private void gridMenu_MouseMove(object sender, MouseEventArgs e)
        {
            menuOpenTime = 0;
        }

        private void btnFizyoterapistRe_Click(object sender, RoutedEventArgs e)
        {
            uiDriver.Activate(EPages.Fizyoterapist);
            CloseMenu();
        }


    }


}

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
using System.Windows.Threading;
using OSYS.Classes;
using OSYS.Web;
using System.ServiceModel.DomainServices.Client;

namespace OSYS.Pages
{



    public partial class pageLogon : BasePage
    {

        public event AuthenticatedHandler AuthenticationSucceded;
        public event EventHandler AuthenticationFailed;
        public CUser AuthenticatedUser { get; set; }

        DispatcherTimer timer = new DispatcherTimer();

        DSCapriceOfis ds = new DSCapriceOfis();
        DSAtoz context = new DSAtoz();
        LoadOperation<OSYS.Web.DTO.DbLogin> DLoginLoadOp;

        UIDriver uiDriver = null;


        public pageLogon()
        {
            InitializeComponent();

            Security.CurrentUser = null;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += (s, e) =>
            {
                borderMessage.Visibility = label.Visibility = Visibility.Collapsed;
                timer.Stop();
            };

            Loaded += (s, ex) =>
            {
                borderMessage.Visibility = label.Visibility = Visibility.Collapsed;
                Focus();
                SetFocus();
                //   txtUserName.Text = CService.LoadData("Username");
                if (txtUserName.Text != "")
                {
                    txtPassword.Focus();
                }
            };
        }

        public void LoadData()
        {
            DLoginLoadOp = ds.Load(ds.GetLoginQuery(txtUserName.Text, txtPassword.Password), false);

            DLoginLoadOp.Completed += new EventHandler(DLoginLoadOp_Completed);
        }

        void DLoginLoadOp_Completed(object sender, EventArgs e)
        {
            //MessageBox.Show(context.con().ToString());

            foreach (var item in DLoginLoadOp.Entities)
            {
                UserSession.PersonelName = item.PersonelName;
                UserSession.UserID = item.PersonelID;
            }

            if (DLoginLoadOp.Entities.Count<OSYS.Web.DTO.DbLogin>() > 0)
            {
                this.Content = new mainPage();
                Authenticate();
            }
        }

        public void SetFocus()
        {
            container.Focus();
            this.Focus();
            txtUserName.Focus();

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadData();
            }
        }

        void AuthenticateUser(string userName, string password)
        {
            container.BusyStart("Checking security...");

            CUser AuthenticatedUser = new CUser();
            AuthenticatedUser.ID = 1;
            AuthenticatedUser.Name = UserSession.PersonelName;
            AuthenticatedUser.Password = "123";
            AuthenticatedUser.UserName = "demo";
            CProfile cp = new CProfile();
            cp.ProfileItems.Add("UTC", new object());
            AuthenticatedUser.Profile = new CProfile();




            //  AuthenticatedUser = AuthenticatedUser as CUser;
            AuthenticationSucceded(this, new AuthenticationEventArgs(AuthenticatedUser));
            container.BusyEnd();

        }

        void Authenticate()
        {
            timer.Stop();
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                borderMessage.Visibility = label.Visibility = Visibility.Visible;
                label.Content = "Kullanıcı adını giriniz";
                txtUserName.Focus();
                timer.Start();
                // btnEnter.IsEnabled = true;
                return;
            }
            if (txtPassword.Password.Trim() == "")
            {
                borderMessage.Visibility = label.Visibility = Visibility.Visible;
                label.Content = "Şifreyi giriniz";
                txtPassword.Focus();
                timer.Start();
                // btnEnter.IsEnabled = true;
                //container.BusyEnd();
                return;
            }
            borderMessage.Visibility = label.Visibility = Visibility.Collapsed;

            AuthenticateUser(txtUserName.Text, txtPassword.Password);
        }

        private void btnEnter_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Authenticate();
        }

        //Forgotten user name password
        private void btnOk_Copy_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Image).Opacity = 1;
        }

        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Image).Opacity = .3;
        }

        private void btnForgottenPassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            container.NotImplemented();
        }

        private void txtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUserName.SelectAll();
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.SelectAll();
        }
    }
}

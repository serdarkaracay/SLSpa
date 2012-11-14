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
using System.Windows.Threading;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;
using System.Resources;
using iDeal.silverlight.classes;

namespace iDeal.silverlight.controls
{
    public partial class LogonControl : UserControl
    {
        public event AuthenticatedHandler AuthenticationSucceded;
        public event EventHandler AuthenticationFailed;
        public CUser AuthenticatedUser { get; set; }

        DispatcherTimer timer = new DispatcherTimer();
        public LogonControl()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += (s, e) =>
            {
                label.Visibility = Visibility.Collapsed;
                timer.Stop();
            };

            Loaded += (s, ex) =>
            {
               //System.Windows.Browser.HtmlPage.Plugin.Focus();
             //DataContext = App.Current .Resources ["languageSupport"];
                label.Visibility = Visibility.Collapsed;
                StopAuthenticationProgress();
                Focus();
                //SetFocus();
                txtUserName.Text = CService.LoadData("Username");
                if (txtUserName.Text != "")
                {
                    txtPassword.Focus();
                   
                }
               
                
            };
        }


        public void SetFocus()
        {
            this.Focus();

            txtUserName.SelectAll();
            txtUserName.Focus();

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

            label.Visibility = Visibility.Collapsed;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Authenticate();
            }
        }

        void AuthenticateUser(string userName, string password, AuthenticatedHandler authenticated, EventHandler failed)
        {
            //CService.GetDataWithParameters(string.Format("Polar..GetUser '@p1','@p2'"),
            //    false,
            //    (xml) =>
            //    {

                   
            //        XElement xm = xml.DescendantsAndSelf("row").SingleOrDefault();
                    if (userName.ToLower()=="demo" && password.Equals ("12345"))
                    {
                        AuthenticatedUser = new CUser();
                        AuthenticatedUser.Name = "Demo User";
                        CService.SaveData(AuthenticatedUser.UserName, "Username");
                        if (authenticated != null) authenticated(this, new AuthenticationEventArgs(AuthenticatedUser));


                    }
                    else
                    {
                        if (failed != null) failed(this, null);
                        timer.Start();
                        label.Content = "Authentication error";
                        txtPassword.Password = "";
                        label.Visibility = Visibility.Visible;
                        txtPassword.Focus();
                        StopAuthenticationProgress();
                    }


             //   },
             //   (obj, ex) =>
             //   {
             //       MessageBox.Show(ex.Message, obj.ToString(), MessageBoxButton.OK);
             //   },
             //   userName,
             //   password
             //);


            //if (userName.Equals("ertan", StringComparison.InvariantCultureIgnoreCase) &&
            //   password.Equals("Ertan", StringComparison.InvariantCulture))
            //{
            //    return new AuthenticationEventArgs(new Classes.CUser() { UserID = 1, UserName = "ertan", Password = "Ertan", Name = "Ertan Köseler", Role = role }, true);
            //}
            //else return new AuthenticationEventArgs (null,false);
        }

        private void NormalButton_Click(object sender, System.EventArgs e)
        {
        }

        public void StartAuthenticationProgress()
        {
            btnEnter.IsEnabled = false;
            //btnEnter.IsChecked = true;
            progressBar1.Visibility = Visibility.Visible;
        }

        public void StopAuthenticationProgress()
        {
            btnEnter.IsEnabled = true;
            //btnEnter.IsChecked = false;
            progressBar1.Visibility = Visibility.Collapsed;
        }

        private void btnEnter_Loaded(object sender, RoutedEventArgs e)
        {
            Authenticate();
        }

        void Authenticate()
        {
            timer.Stop();
            if (string.IsNullOrEmpty (txtUserName.Text.Trim() ))
            {
                label.Visibility = Visibility.Visible;
                label.Content = "Enter the username";
                txtUserName.Focus();
                timer.Start();
                btnEnter.IsEnabled = true;
                //btnEnter.IsChecked = false;
                return;
            }
            if (txtPassword.Password.Trim() == "")
            {
                label.Visibility = Visibility.Visible;
                label.Content = "Enter the password";
                txtPassword.Focus();
                timer.Start();
                btnEnter.IsEnabled = true;
                //btnEnter.IsChecked = false;
                return;
            }
            label.Visibility = Visibility.Collapsed;
            StartAuthenticationProgress();
            AuthenticateUser(txtUserName.Text, txtPassword.Password, AuthenticationSucceded, AuthenticationFailed);


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            //if (LanguageSupport.Culture.TwoLetterISOLanguageName == "tr")
            //    LanguageSupport.Culture = new CultureInfo("en");
            //else LanguageSupport.Culture = new CultureInfo("tr");
            //DataContext = App.Current.Resources["languageSupport"];
        }
    }
}

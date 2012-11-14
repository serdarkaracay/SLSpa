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
using System.Reflection;

namespace iDeal.silverlight.controls
{
    public partial class AboutWindow : ChildWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName name = new AssemblyName(assembly.FullName);

            label1.Content = "iDeal Map Control Library v." + name.Version.ToString(3) + "\nCopyright © iDeal Teknoloji 2011";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
           
        }
    }
}


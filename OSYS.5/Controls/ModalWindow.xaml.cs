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
using System.ComponentModel;

namespace MovingShip
{
    public partial class ModalWindow : ChildWindow
    {

        string message = string.Empty;
        public string Message { get { return message; } set { message = value;  } }
        public ModalWindow()
        {
            InitializeComponent();
        }
        

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }




        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            messageBlock.Text = Message;
        }
    }
}


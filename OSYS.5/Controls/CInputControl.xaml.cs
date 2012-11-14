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

namespace OSYS.Controls
{
    public partial class CInputControl : UserControl
    {
        public CInputControl(string text)
        {
            InitializeComponent();
           textBlock1 .Text = text;
           Loaded += new RoutedEventHandler(CInputControl_Loaded);
         
        }

        void CInputControl_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
            textBox1.Focus();
        }
        public string Text { get { return textBox1.Text; } }
        
    }
}

﻿using System;
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
    public partial class CFilterControl : UserControl
    {
        public CFilterControl()
        {
            InitializeComponent();
        }

        #region AISType
        List<string> resultList=new List<string>();
        public List<string> AISTypeFilter { get { return resultList; } }
        //All
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

           if(checkBox6 ==null)return;
                checkBox2.IsChecked =
                        checkBox3.IsChecked =
                        checkBox4.IsChecked =
                        checkBox5.IsChecked =
                        checkBox6.IsChecked = false;
        }
        //Class A
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            resultList.Add("A");
        }
        //Class B
        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            resultList.Add("B");
        }
        //AtoN
        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            resultList.Add("AN");
        }
        //BaseStation
        private void checkBox5_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            resultList.Add("BS");
        }
        //Undefined
        private void checkBox6_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
        }
        //All
        private void checkBox1_UnChecked(object sender, RoutedEventArgs e)
        {

        }
        //Class A
        private void checkBox2_UnChecked(object sender, RoutedEventArgs e)
        {
            resultList.Remove("A");
        }
        //Class B
        private void checkBox3_UnChecked(object sender, RoutedEventArgs e)
        {
            resultList.Remove("B");
        }
        //AtoN
        private void checkBox4_UnChecked(object sender, RoutedEventArgs e)
        {
            resultList.Remove("AN");
        }
        //BaseStation
        private void checkBox5_UnChecked(object sender, RoutedEventArgs e)
        {
            resultList.Remove("BS");
        }
        //Undefined
        private void checkBox6_UnChecked(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        public string NameFilter { get { return textBox1.Text; } }
    }
}

﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace OSYS.Pages
{
    public class BasePage:Page 
    {

        public UIDriver uiDriver { get; set; }
        public mainPage container { get; set; }
        public BasePage()
        {

        }
        public virtual void Dispose()
        {
           
        }

       


    }
}

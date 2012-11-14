using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.ComponentModel;

namespace OSYS.Model
{
    public class ServisModel 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private int _ServiceID;
        //public static int ServiceID
        //{
        //    get { return _ServiceID; }
        //    set
        //    {
        //        if (ServiceID == value)
        //        {
        //            return;
        //        }
        //        _ServiceID = value;
        //        this.NotifyPropertyChanged("ServiceID");
        //    }
        //}
    }
}

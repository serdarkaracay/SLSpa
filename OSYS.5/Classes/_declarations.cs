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
using System.Xml.Linq;
using System.Collections.Generic;
using C1.Silverlight;
using OSYS.Controls;
using OSYS.Classes.interfaces;


namespace OSYS.Classes
{
    public delegate void AuthenticatedHandler(object sender, AuthenticationEventArgs e);
    public delegate void CGroupButtonsClickEventHandler(CButton sender);

    public class AuthenticationEventArgs : EventArgs
    {
        public IUser AuthenticatedUser { get; set; }


        public AuthenticationEventArgs(IUser user)
        {
            AuthenticatedUser = user;
        }
    }

    
    public enum EMessageType
    {
        Info,
        Warning,
        Error
    }
   
    public class Locks
    {
        public static object MapItemCollectionLock=new object();
    }

    public class MapItemDataTemplateSelector : C1DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            //if (element != null && item != null && item is CMapItem)
            //{
            //    CMapItem mapItem = item as CMapItem;
                
            //    if (mapItem.Selected)
            //        return element.FindName("selectedMapItemTemplate") as DataTemplate;
            //    else
            //        return element.FindName("mapItemTemplate") as DataTemplate;
           
            //}

            return null;
        }
    }

    public class CListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public static void LoadList(string xmlPath, DataDownloadedHandler received, ExceptionHandler exception)
        //{

        //}
    }
}

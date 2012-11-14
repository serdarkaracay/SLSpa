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
using System.Xml.Linq;
using System.Collections.Generic;
using iDeal.silverlight.classes;
using iDeal.silverlight.controls;

namespace iDeal.silverlight
{
    public delegate void DataDownloadedHandler(object sender, XElement xml);
    public delegate void ExecutionCompletedHandler(object sender, int affectedRecordCount);
    public delegate void ExceptionHandler(object sender, Exception x);
    public delegate void ServiceExceptionHandler(object sender, ServiceException x);
    public delegate void MessageReceivedHandler(object sender, string msg);
    public delegate void ObjectDataDownloaded<T>(object sender, IEnumerable<T> s);
    public delegate void ItemChangedHandler(object sender, object item);
    public delegate void AuthenticatedHandler(object sender, AuthenticationEventArgs e);
    public delegate void ProfileReceivedHandler(object sender, ProfileEventArgs e);

    public class AuthenticationEventArgs : EventArgs
    {
        public IUser AuthenticatedUser { get; set; }


        public AuthenticationEventArgs(IUser user)
        {
            AuthenticatedUser = user;
        }
    }

    public class ProfileEventArgs : EventArgs
    {
        public IProfile Profile { get; set; }


        public ProfileEventArgs(IProfile profile)
        {
            Profile = profile;
        }
    }
    public enum EMapSource
    {
         RTS,
       iDeal,
        GoogleSat,
        GoogleMap,
        VirtualEarth,
        OpenStreetMap,
        None
    }


    public enum ECoordinatesView
    {
        DegMinSec,
        DegMin,
        Deg
    }

    public enum EServiceStatus
    {
        Close,
        Open
    }
}

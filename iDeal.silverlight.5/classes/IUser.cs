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

namespace iDeal.silverlight.classes
{
    public interface IUser
    {
        int ID { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string eMail { get; set; }
        string Phone { get; set; }
        string LastLoginDate { get; set; }

       
    }
}

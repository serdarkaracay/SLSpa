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
    public class CUser:IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string LastLoginDate { get; set; }
        public int ScopeID { get; set; }
        public string ScopeName { get; set; }
        public int ScopeParentID { get; set; }

        public CUser()
        {

        }

        public CUser(XElement xml)
        {
            ID = CService.GetInt32(xml, "ID");
            Name = CService.GetString(xml, "Name");
            UserName = CService.GetString(xml, "UserName");
            Password = CService.GetString(xml, "Password");
            eMail = CService.GetString(xml, "eMail");
            Address = CService.GetString(xml, "Address");
            Town = CService.GetString(xml, "Town");
            City = CService.GetString(xml, "City");
            Phone = CService.GetString(xml, "Phone");
            LastLoginDate = CService.GetString(xml, "LastLoginDate");
            ScopeID = CService.GetInt32(xml, "ScopeID");
            ScopeName = CService.GetString(xml, "ScopeName");
            ScopeParentID = CService.GetInt32(xml, "ScopeParentID");
        }



        public static IEnumerable<CUser> GetUsers(XElement xml)
        {
            var users=new List<CUser>();
            foreach (XElement x in xml.DescendantsAndSelf("row"))
                users.Add(new CUser(x));
            return users;
        }


    }
}

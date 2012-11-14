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
using OSYS.Classes.interfaces;


namespace OSYS.Classes
{
    public class CUser : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
        public string Phone { get; set; }
        public string LastLoginDate { get; set; }
        public Dictionary<int, bool> Permissions { get; set; }
        public CProfile Profile { get; set; }

        public CUser()
            : base()
        {

        }

        public CUser(XElement xml)
           
        {
            //ID = CService.GetInt32(xml, "ID");
            //Name = CService.GetString(xml, "name");
            //UserName = CService.GetString(xml, "username");
            //Password = CService.GetString(xml, "password");
            //eMail = CService.GetString(xml, "email");
            //Phone = CService.GetString(xml, "phone");
            //LastLoginDate = CService.GetString(xml, "LastLoginDate");
        }

        //public static void Authenticate(object sender, string userName, string password, AuthenticatedHandler ah, MessageReceivedHandler mh, ExceptionHandler eh)
        //{
        //    return "";

        //}

        //public void GetProfile(object sender, ProfileReceivedHandler ph, MessageReceivedHandler mh, ExceptionHandler eh)
        //{
        //    (new CService()).GetData(sender, string.Format("CheckUserProfile {0}", ID),
        //        (s, xml) =>
        //        {
        //            Profile = new CProfile(xml);
        //            if (sender is DependencyObject)
        //            {
        //                (sender as DependencyObject).Dispatcher.BeginInvoke(() =>
        //                {
        //                    ph(s, new ProfileEventArgs(Profile));

        //                });
        //            }
        //            else
        //            {
        //                ph(s, new ProfileEventArgs(Profile));

        //            }
        //        },
        //        (s, ex) =>
        //        {
        //            if (sender is DependencyObject)
        //            {
        //                (sender as DependencyObject).Dispatcher.BeginInvoke(() =>
        //                {
        //                    switch (ex.ErrorType)
        //                    {
        //                        case EErrorType.REQUEST:
        //                        case EErrorType.SERVER:
        //                        case EErrorType.READER:
        //                        case EErrorType.DECOMPRESSION:
        //                        case EErrorType.UNKNOWN:
        //                        default:
        //                            eh(s, ex);
        //                            break;
        //                        case EErrorType.NODATA:
        //                            mh(s, "No profile data.");
        //                            break;
        //                    }
        //                });
        //            }
        //            else
        //            {
        //                switch (ex.ErrorType)
        //                {
        //                    case EErrorType.REQUEST:
        //                    case EErrorType.SERVER:
        //                    case EErrorType.READER:
        //                    case EErrorType.DECOMPRESSION:
        //                    case EErrorType.UNKNOWN:
        //                    default:
        //                        eh(s, ex);
        //                        break;
        //                    case EErrorType.NODATA:
        //                        mh(s, "No profile data.");
        //                        break;
        //                }
        //            }
        //        });

        //}

        public static List<CUser> GetUsers(XElement xml)
        {
            var users=new List<CUser>();
            foreach (XElement x in xml.DescendantsAndSelf("row"))
                users.Add(new CUser(x));
            return users;
        }



        internal object GetProfileItem(string p)
        {
            return Profile.GetItem(p);
        }

        //internal void SetProfileItem(string itemName, object itemValue, EventHandler success, ExceptionHandler exception)
        //{
           

        //    (new CService()).GetData(this, string.Format("SetProfileItem {0},{1},'{2}'", ID, itemName, CService.GetStrValue( itemValue)),
        //        (s, x) =>
        //        {
        //            Profile.SetItem(itemName, itemValue);
        //            if (success != null) success(this, null);

        //        },
        //        (s, e) =>
        //        {
        //            switch (e.ErrorType)
        //            {
        //                case EErrorType.NODATA:
        //                    Profile.SetItem(itemName, itemValue);
        //                    if (success != null) success(this, null);
        //                    break;
        //                case EErrorType.REQUEST:
        //                case EErrorType.SERVER:
        //                case EErrorType.READER:
        //                case EErrorType.DECOMPRESSION:
        //                case EErrorType.UNKNOWN:
        //                default:
        //                    if (exception != null) exception(this, e);
        //                    break;
        //            }

        //        }
        //    );
        //}

        }
}

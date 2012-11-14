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
using OSYS.Classes.interfaces;


namespace OSYS.Classes
{
    public class CProfile:IProfile
    {
        private Dictionary<string,object> profileItems=new Dictionary<string,object> ();

        public Dictionary<string,object> ProfileItems
        {
            get { return profileItems ; }
            
        }
        
        
        public CProfile():base()
        {

        }

        public CProfile(XElement xml)
        {
            foreach (XElement item in xml.DescendantsAndSelf ("row"))
            {
             //   ProfileItems.Add(CService.GetString(item, "profileItem"), CService.GetObject(item, "value", CService.GetString(item, "type")));    
            }
        }

        internal object GetItem(string p)
        {
            try
            {
                return ProfileItems[p];
            }
            catch (KeyNotFoundException )
            {
                return null;
            }
        }

      

        internal void SetItem(string itemName, object itemValue)
        {
            ProfileItems[itemName] = itemValue;
        }

       

    }
}

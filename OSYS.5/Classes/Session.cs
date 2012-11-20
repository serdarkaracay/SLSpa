using System;
using System.Collections.Generic;

namespace OSYS.Classes
{
    public class Session
    {
       
        public static int SelectedVesselIndex { get; set; }
        public static bool IsUserAuthenticated { get; set; }
    }

    public static class UserSession
    {
       
         public static string UserName { get; set; }
        public static Guid UserID { get; set; }
        public static string PersonelName { get; set; }
        public static string Role { get; set; }
        public static string Phone { get; set; }
        public static string Email { get; set; }
        
    }
}

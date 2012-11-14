using System;
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
using System.Windows.Navigation;
using System.Windows.Threading;
using OSYS.Classes;



namespace OSYS
{
    public class UI
    {
        public static bool IsClockUTC                         = true;
        public static int SERVICE_PERIOD_SECOND               = 5;
        public static int[] SERVICE_PERIOD_ARRAY              = { 1,2,3,4,5, 10, 30, 60, 180, 600, 3600 };
        public static int[] SECOND_TIME_ARRAY                 = {2,5,10,30,60,120,180,360,420,600,900,1800,3600 };
        public static int[] MIN_TIME_ARRAY                    = {15, 30, 60, 120, 180 };
        public static TimeSpan TIME_DIFF                      = TimeSpan.FromSeconds (0);
         public static string[] DATE_FORMAT_ARRAY              = { "d.M.yy","d.M.yyyy","d M yyyy",  "d MMMM yyyy","M/d/yyyy","MMMM d,yyyy" };
        public static string[] TIME_FORMAT_ARRAY              = {"HH:mm:ss","HH:mm"};
        public static string[] TIME_ZONE_ARRAY                = { "UTC", "Local" };
    }

    public class Security
    {
        public static CUser CurrentUser=null;
    }
}
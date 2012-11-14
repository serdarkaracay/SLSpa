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

namespace iDeal.silverlight.classes
{
    public class CMercator
    {
        int PARCELSIZE;

        double R_MAJOR = 6378137.0;
        double R_MINOR = 6356752.3142;
        double M_PI_2 = 1.57079632679489661922;
        double RATIO, ECCENT, COM;

        public CMercator()
        {
            RATIO = (R_MINOR / R_MAJOR);
            ECCENT = (Math.Sqrt(1.0 - (RATIO * RATIO)));
            COM = (0.5 * ECCENT);
        }


        public double x(double lon)
        {
            return (R_MAJOR * lon * M_PI_2 / 90.0);
        }

        public double y(double lat)
        {
            lat = Math.Min(89.5, Math.Max(lat, -89.5));
            double con = Math.Pow(((1.0 - ECCENT * Math.Sin(deg_rad(lat))) / (1.0 + ECCENT * Math.Sin(deg_rad(lat)))), COM);
            return (0 - R_MAJOR * Math.Log(Math.Tan(0.5 * ((M_PI_2) - deg_rad(lat))) / con));
        }



        public double lon(double x)
        {
            return (rad_deg(x) / R_MAJOR);
        }

        public double lat(double y)
        {
            double ts = Math.Exp(-y / R_MAJOR);
            double phi = M_PI_2 - 2 * Math.Atan(ts);
            double dphi = 1.0;
            int i = 0;
            while ((Math.Abs(dphi) > 0.00000001) && (i < 15))
            {
                dphi = M_PI_2 - 2 * Math.Atan(ts * Math.Pow((1.0 - ECCENT * Math.Sin(phi)) / (1.0 + ECCENT * Math.Sin(phi)), COM)) - phi;
                phi += dphi;
                i++;
            }
            return rad_deg(phi);
        }

        double deg_rad(double ang)
        {
            return (ang * M_PI_2 / 90.0);
        }

        double rad_deg(double ang)
        {
            return (ang * 90.0 / M_PI_2);
        }

    }



}

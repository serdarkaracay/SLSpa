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
    public class CGeography
    {

        public static string FormatCoordinates(Point p)
        {
            string yonX = "E";
            if (p.X < 0) { yonX = "W"; p.X *= -1; }
            int dereceX = (int)p.X;
            double dakikaX = ((p.X - dereceX) * 60);

            string yonY = "N";
            if (p.Y < 0) { yonY = "S"; p.Y *= -1; }
            int dereceY = (int)p.Y;
            double dakikaY = ((p.Y - dereceY) * 60);

            return
                dereceY.ToString("00") + "° " + ((int)dakikaY).ToString("00") + "'" + (dakikaY - (int)dakikaY).ToString(".000") + " " + yonY + "  " +
                dereceX.ToString("00") + "° " + ((int)dakikaX).ToString("00") + "'" + (dakikaX - (int)dakikaX).ToString(".000") + " " + yonX;
        }
    }
}

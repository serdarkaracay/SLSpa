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

namespace SilverlightApplication4
{
    public static class Utility
    {
        static Utility()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }
        public static double Randomise(double lower, double higher)
        {
            return (lower + (_random.NextDouble() * (higher - lower)));
        }
        static Random _random;
    }
}

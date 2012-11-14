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
using System.Windows.Data;
using System.Diagnostics;
using System.Collections.Generic;
using OSYS.Pages;

namespace OSYS.Classes
{

    public class ConverterShipAndCargo : IValueConverter
    {

        #region IValueConverter Members
        Dictionary<string,string> ShipAndCargo = new Dictionary<string, string>()
{
                                                        
                                                        {"20","WIG"},{"21","WIG carrying pollutant category X"},{"22","WIG carrying pollutant category Y"},{"23","WIG carrying pollutant category Z"},{"24","WIG carrying pollutant category OS"},{"30","Fishing"},{"31","Towing"},{"32","Towing and length of the tow exceeds 200 m or breadth exceeds 25 m"},{"33","Engaged in dredging or underwater operations"},{"34","Engaged in diving operations"},{"35","Engaged in Military operations"},{"36","Sailing"},{"37","Pleasure craft"},
                                                        {"40","HSC"},{"41","HSC carrying pollutant category X"},{"42","HSC carrying pollutant category Y"},{"43","HSC carrying pollutant category Z"},{"44","HSC carrying pollutant category OS"},
                                                        {"50","Pilot vessel"},{"51","Search and rescue vessel"},{"52","Tugs"},{"53","Port tenders"},{"54","Vessel with anti-pollution facilities or equipment"},{"55","Law enforcement vessel"},{"56","Local vessel"},{"57","Local vessel"},{"58","Medical transport"},{"59","Ship and aircraft of States not parties to an armed conflict"},
                                                        {"60","Passenger ship"},{"61","Passenger ship ,carrying pollutant category X"},{"62","Passenger ship ,carrying pollutant category Y"},{"63","Passenger ship ,carrying pollutant category Z"},{"64","Passenger ship ,carrying pollutant category OS"},
                                                        {"70","Cargo ship"},{"71","Cargo ship ,carrying pollutant category X"},{"72","Cargo ship ,carrying pollutant category Y"},{"73","Cargo ship ,carrying pollutant category Z"},{"74","Cargo ship, carrying pollutant category OS"},
                                                        {"80","Tanker"},{"81","Tanker, carrying pollutant category X"},{"82","Tanker, carrying pollutant category Y"},{"83","Tanker, carrying pollutant category Z"},{"84","Tanker, carrying pollutant category Z"},
                                                        {"90","Other type of ship"},{"91","Other Type of ship, carrying pollutant category X"},{"92","Other type of ship, carrying pollutant category Y"},{"93","Other type of ship, carrying pollutant category Z"},{"94","Other type of ship, carrying pollutant category OS"}
                                                      };


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (ShipAndCargo.ContainsKey(value.ToString()))
            {
             if(ShipAndCargo[value.ToString()].Length >15)
                return ShipAndCargo[value.ToString()].Substring(0, 15) + "...";
             else return ShipAndCargo[value.ToString()];
            }
            else return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterShipAndCargoForTooltip : IValueConverter
    {

        #region IValueConverter Members
        Dictionary<string,string> ShipAndCargo = new Dictionary<string, string>()
{
                                                        
                                                        {"20","WIG"},{"21","WIG carrying pollutant category X"},{"22","WIG carrying pollutant category Y"},{"23","WIG carrying pollutant category Z"},{"24","WIG carrying pollutant category OS"},{"30","Fishing"},{"31","Towing"},{"32","Towing and length of the tow exceeds 200 m or breadth exceeds 25 m"},{"33","Engaged in dredging or underwater operations"},{"34","Engaged in diving operations"},{"35","Engaged in Military operations"},{"36","Sailing"},{"37","Pleasure craft"},
                                                        {"40","HSC"},{"41","HSC carrying pollutant category X"},{"42","HSC carrying pollutant category Y"},{"43","HSC carrying pollutant category Z"},{"44","HSC carrying pollutant category OS"},
                                                        {"50","Pilot vessel"},{"51","Search and rescue vessel"},{"52","Tugs"},{"53","Port tenders"},{"54","Vessel with anti-pollution facilities or equipment"},{"55","Law enforcement vessel"},{"56","Local vessel"},{"57","Local vessel"},{"58","Medical transport"},{"59","Ship and aircraft of States not parties to an armed conflict"},
                                                        {"60","Passenger ship"},{"61","Passenger ship ,carrying pollutant category X"},{"62","Passenger ship ,carrying pollutant category Y"},{"63","Passenger ship ,carrying pollutant category Z"},{"64","Passenger ship ,carrying pollutant category OS"},
                                                        {"70","Cargo ship"},{"71","Cargo ship ,carrying pollutant category X"},{"72","Cargo ship ,carrying pollutant category Y"},{"73","Cargo ship ,carrying pollutant category Z"},{"74","Cargo ship, carrying pollutant category OS"},
                                                        {"80","Tanker"},{"81","Tanker, carrying pollutant category X"},{"82","Tanker, carrying pollutant category Y"},{"83","Tanker, carrying pollutant category Z"},{"84","Tanker, carrying pollutant category Z"},
                                                        {"90","Other type of ship"},{"91","Other Type of ship, carrying pollutant category X"},{"92","Other type of ship, carrying pollutant category Y"},{"93","Other type of ship, carrying pollutant category Z"},{"94","Other type of ship, carrying pollutant category OS"}
                                                      };


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (ShipAndCargo.ContainsKey(value.ToString())) return ShipAndCargo[value.ToString()];
            else return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterShipColor : IValueConverter
    {

        #region IValueConverter Members
        String[] ShipClr = {
                            "#FFF9E6B1", //0 
                            "#FFF9E6B1", //1 
                            "#FFF9E6B1", //2 
                            "#FFF9E6B1", //3 
                            "#FFFF82FF", //4 
                            "#FF08F8F4", //5 
                            "#FF08F8F4", //6 
                            "#FFFFDD00", //7 ?
                            "#FFFF3333", //8 
                            "#FFFF3333"  //9 
                           };
        //String[] ShipLineClr = { Color.FromArgb(0, Color.Gray), 
        //                                 Color.FromArgb(0xff, 0xaa, 0x00), 
        //                                 Color.FromArgb(0x55, 0x7f, 0xff) };


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            int ShipAndCargo = (int)value;
            int ShipFillColor = 0;
            if (ShipAndCargo < 10) ShipFillColor = ShipAndCargo;
            if (ShipAndCargo >= 10 && ShipAndCargo < 100) ShipFillColor = (int)Math.Floor(ShipAndCargo / 10F);
            if (ShipAndCargo == Int32.MinValue) ShipFillColor = 0;
            return ShipClr[ShipFillColor];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterAISType : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "A") return "#FFFDBA30";
            else if (value.ToString() == "B") return "#FF5988FF";
            else return "#FF5988FF";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterAISTypeVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter==null) return "Collapsed";
            if (string.IsNullOrEmpty(parameter.ToString())) return "Collapsed";
            string[] types=parameter.ToString().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in types)
            {
                if (item == value.ToString()) return "Visible";
            }
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterShipVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "A" || value.ToString() == "B") return "Visible";
            else return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterBaseStationVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "BS") return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterUnknownVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "") return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterSelectionVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value) return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterBoolVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value) return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterCOGVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((double)value) > 0) return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterSOGVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((double)value) > 0.15) return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterAtoNVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "AN")
                return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class ConverterViaMediaVisibility : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(value.ToString()) && value.ToString() == "SAT")
                return "Visible";
            else return "Collapsed";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class ConverterROTLeft : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((int)value) >= 1 && ((int)value) <= 128) return "Visible";
            else return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class ConverterROTRight : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((int)value) >= -127 && ((int)value) <= -1) return "Visible";
            else return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterSOG : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((double)value) > 0) return "#FF454545";
            else return "#00454545";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ConverterWidthLength : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((int)value) <= 0) return 1;
            else return (int)value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
   
    /**********************************************************************************************************************************/

  

    public class ConverterSubtract : IValueConverter
    {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double i=0,j=0;
            if (!string.IsNullOrEmpty(parameter.ToString()))
            {
                double.TryParse(parameter.ToString(), out i);
                double.TryParse(value.ToString(), out j);
                return j + i;
            }
            else return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

   }

    public class ConverterDoubleToInt : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double i=0;
            int result=0;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                double.TryParse(value.ToString(), out i);
            }
            result = (int)i;
            //Debug.WriteLine(i + " --> " + result);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #region FORMAT CONVERTER


    public class CConverterUtils
    {
        public static bool CheckValueIsInvalid(object val)
        {
            return val==null && string.IsNullOrEmpty(val.ToString());
        }
    }

    public class ConverterDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (CConverterUtils.CheckValueIsInvalid(value)) return "-";
            return UIDriver.GetFormattedDate((DateTime)value);
        }
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return "-";
        }
    }

    public class ConverterTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (CConverterUtils.CheckValueIsInvalid(value)) return "-";
            return UIDriver.GetFormattedTime((DateTime)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return "-";
        }
    }

    public class ConverterDateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (CConverterUtils.CheckValueIsInvalid(value)) return "-";
            return UIDriver.GetFormattedDateTime((DateTime)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return "-";
        }
    }

    public class ConverterLatLong : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (CConverterUtils.CheckValueIsInvalid(value)) return "-";
            return UIDriver.GetFormattedPosition((Point)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return "-";
        }
    }

    public class ConverterDouble : IValueConverter
    {

      
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double i=0; ;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                double.TryParse(value.ToString(), out i);
            }

            return i.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }

     }

    public class ConverterKdv : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double i = 0; ;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                double.TryParse(value.ToString(), out i);
                i = i * 100;
            }
           

            return i.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }

    }

    public class ConverterInt : IValueConverter
    {

     
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int i=0; ;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                int.TryParse(value.ToString(), out i);
            }

            return i.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }

     }

    #endregion


}

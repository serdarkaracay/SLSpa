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

namespace iDeal.silverlight.classes
{

   
 //   public class ConverterShipColor : IValueConverter
 //   {

 //       #region IValueConverter Members
 //       String[] ShipClr = {
 //                           "#FFF9E6B1", //0 
 //                           "#FFF9E6B1", //1 
 //                           "#FFF9E6B1", //2 
 //                           "#FFF9E6B1", //3 
 //                           "#FFFF82FF", //4 
 //                           "#FF08F8F4", //5 
 //                           "#FF08F8F4", //6 
 //                           "#FFFFDD00", //7 ?
 //                           "#FFFF3333", //8 
 //                           "#FFFF3333"  //9 
 //                          };
 //       //String[] ShipLineClr = { Color.FromArgb(0, Color.Gray), 
 //       //                                 Color.FromArgb(0xff, 0xaa, 0x00), 
 //       //                                 Color.FromArgb(0x55, 0x7f, 0xff) };
		
		
 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {

 //           int ShipAndCargo = (int)value;
 //           int ShipFillColor = 0;
 //           if (ShipAndCargo < 10) ShipFillColor = ShipAndCargo;
 //           if (ShipAndCargo >= 10 && ShipAndCargo < 100) ShipFillColor = (int)Math.Floor(ShipAndCargo / 10F);
 //           if (ShipAndCargo == Int32.MinValue) ShipFillColor = 0;
 //           return ShipClr[ShipFillColor];
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterAISType : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (value.ToString() == "A") return "#FFFDBA30";
 //           else if (value.ToString() == "B") return "#FF5988FF";
 //           else return "#FF5988FF";
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterShipVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (value.ToString() == "A" || value.ToString() == "B") return "Visible";
 //           else  return "Collapsed";
          
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }
	
 //    public class ConverterBaseStationVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (value.ToString() == "BS") return "Visible";
 //           else  return "Collapsed";
          
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterSelectionVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if ((bool)value) return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterBoolVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if ((bool)value) return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion

 //   }

 //   public class ConverterBoolColor : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if ((bool)value) return "#FFFF0000";
 //           else return "#FF00FF00";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion

 //   }

 //   public class ConverterCOGVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (((double)value)>0) return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterSOGVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (((double)value) > 0.15) return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterAtoNVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (!string.IsNullOrEmpty (value.ToString()) && value.ToString() == "AN")
 //               return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }
 //public class ConverterViaMediaVisibility : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (!string.IsNullOrEmpty (value.ToString()) && value.ToString() == "SAT")
 //               return "Visible";
 //           else return "Collapsed";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }
 //   public class ConverterROTLeft : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (((int)value) >= 1 && ((int)value) <= 128) return "#FF454545";
 //           else return "#00454545";
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }
 //   public class ConverterROTRight : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (((int)value) >= -127 && ((int)value) <= -1) return "#FF454545";
 //           else return "#00454545";
 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }

 //   public class ConverterSOG : IValueConverter
 //   {

 //       #region IValueConverter Members

 //       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           if (((double)value) > 0) return "#FF454545";
 //           else return "#00454545";

 //       }

 //       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       #endregion
 //   }
    /**********************************************************************************************************************************/
   

    
    //public class ConverterSubtract : IValueConverter
    //{

    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        double i=0,j=0;
    //        if (!string.IsNullOrEmpty(parameter.ToString()))
    //        {
    //            double.TryParse(parameter.ToString(), out i);
    //            double.TryParse(value.ToString(), out j);
    //            return j + i;
    //        }
    //        else return value;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}

    //public class ConverterDoubleToInt : IValueConverter
    //{

    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        double i=0;
    //        int result=0;
    //        if (!string.IsNullOrEmpty(value.ToString()))
    //        {
    //            double.TryParse(value.ToString(), out i);
    //        }
    //        result =(int) i;
         
    //        return result;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}

#region FORMAT CONVERTER
    //public class ConverterDateTime : IValueConverter
    //{

    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        DateTime i=DateTime.MinValue; ;
    //        if (!string.IsNullOrEmpty(value.ToString()))
    //        {
    //            DateTime.TryParse(value.ToString(), out i);
    //        }
    //        if (DateTime.MinValue == i) return "-";
    //        else return i.ToString(parameter.ToString());
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //throw new NotImplementedException();
    //        return null;
    //    }

    //    #endregion
    //}

    //public class ConverterDouble : IValueConverter
    //{

    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        double i=0; ;
    //        if (!string.IsNullOrEmpty(value.ToString()))
    //        {
    //            double.TryParse(value.ToString(), out i);
    //        }
          
    //         return i.ToString(parameter.ToString());
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //throw new NotImplementedException();
    //        return null;
    //    }

    //    #endregion
    //}

    //public class ConverterInt : IValueConverter
    //{

    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        int i=0; ;
    //        if (!string.IsNullOrEmpty(value.ToString()))
    //        {
    //            int.TryParse(value.ToString(), out i);
    //        }

    //        return i.ToString(parameter.ToString());
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //throw new NotImplementedException();
    //        return null;
    //    }

    //    #endregion
    //}

#endregion


}

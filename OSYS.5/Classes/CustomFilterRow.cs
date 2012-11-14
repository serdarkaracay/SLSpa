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
using C1.Silverlight.DataGrid.Filters;
using C1.Silverlight;

namespace OSYS.Classes
{
    public class CustomFilterRow : DataGridFilterRow
    {
        protected override System.Windows.FrameworkElement CreateCellContent(C1.Silverlight.DataGrid.DataGridColumn column)
        {
            var textbox = base.CreateCellContent(column) as C1TextBoxBase;
            textbox.Watermark = " ";
            return textbox;
        }
    }
}

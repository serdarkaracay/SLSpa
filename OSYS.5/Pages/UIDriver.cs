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
using System.Collections.Generic;
using System.Diagnostics;
using C1.Silverlight.DataGrid;
using System.Text;
using System.Reflection;
using System.IO;
using OSYS.Classes;

namespace OSYS.Pages
{
    public enum EPages
    {
        Logon,
        Initial,
        Vessels,
        Data,
        System,
        Settings,
        Reports,
        Profile,
        Help,
        Test,
        Test2,
        CustomerGroup,
        Customer,
        Meter,
        Tariff,
        Price,
        CustomerMeter,
        Invoice,
        InvoiceReport,
        PayInvoice,
        MeterMonth,
        MeterParameter,
        Rezervasyon,
        ServiceDefinition,
        Fizyoterapist

    }


    public delegate void PageEventHandler(BasePage page);

    public class UIDriver
    {


        public event PageEventHandler PageLoading;
        public event PageEventHandler PageLoaded;
        public event PageEventHandler PageUnLoading;

        public event AuthenticatedHandler AuthenticationSucceded;
        public event EventHandler LogOff;

        public UIDriver(mainPage MainPage, Grid Container)
        {
            container = Container;
            mainPage = MainPage;
            pages.Add(EPages.Logon, typeof(pageLogon));
            pages.Add(EPages.Initial, typeof(pageInitial));
            pages.Add(EPages.ServiceDefinition, typeof(ServiceDef));
            //   pages.Add(EPages.System, typeof(pageSystem));
            //  pages.Add(EPages.Settings, typeof(pageSettings));
            //   pages.Add(EPages.Reports, typeof(ReportPage));
            //    pages.Add(EPages.Profile, typeof(pageUserProfile));


            pages.Add(EPages.CustomerGroup, typeof(CustGroupPage));
            //pages.Add(EPages.Customer, typeof(CustPage));
            //pages.Add(EPages.MeterMonth, typeof(MeterGraphPage));
            pages.Add(EPages.CustomerMeter, typeof(CustMeterPage));
            pages.Add(EPages.Rezervasyon, typeof(Reception));
            pages.Add(EPages.Fizyoterapist, typeof(Fizyoterapist));

            //pages.Add(EPages.Tariff, typeof(TariffPage));
            //pages.Add(EPages.Price, typeof(PricePage));
            //pages.Add(EPages.Invoice, typeof(InvoicePage));
            //pages.Add(EPages.InvoiceReport, typeof(InvoiceReportPage));
            //pages.Add(EPages.Meter, typeof(MeterPage));
            //pages.Add(EPages.MeterParameter, typeof(MeterParameterPage));


            //pages.Add(EPages.Test, typeof(TestControl));
            //pages.Add(EPages.Test2, typeof(pageTest));
            //   pages.Add(EPages.Help, typeof(pageHelp));
        }

        Dictionary<EPages, Type> pages = new Dictionary<EPages, Type>();


        Grid container = null;
        mainPage mainPage = null;



        private static BasePage currentPage = null;

        public static BasePage CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        public void Activate(EPages page)
        {
            if (CurrentPage != null)
            {
                PageUnLoading(CurrentPage);
                container.Children.Clear();
                CurrentPage.Dispose();
            }
            CurrentPage = Activator.CreateInstance(pages[page]) as BasePage;
            CurrentPage.uiDriver = this;
            CurrentPage.container = mainPage;
            if (pages[page] == typeof(pageLogon))
            {
                LogOff(this, new EventArgs());
                (CurrentPage as pageLogon).AuthenticationSucceded += new AuthenticatedHandler(UIDriver_AuthenticationSucceded);
            }
           
            PageLoading(CurrentPage);
            if (CurrentPage is AuthenticatedPage)
            {
                AuthenticatedPage cp = CurrentPage as AuthenticatedPage;
                if (cp.Authenticate() && cp.Authorize())
                {
                    container.Children.Add(CurrentPage);
                    PageLoaded(CurrentPage);
                }
                else
                {
                    CurrentPage.Dispose();
                    Activate(EPages.Logon);
                }
            }
            else
            {
                container.Children.Add(CurrentPage);
                PageLoaded(CurrentPage);
            }
        }

        public void Activate(EPages page, int serviceID)
        {
            if (CurrentPage != null)
            {
                PageUnLoading(CurrentPage);
                container.Children.Clear();
                CurrentPage.Dispose();
            }

            mainPage.serviceID = serviceID;
            CurrentPage = Activator.CreateInstance(pages[page]) as BasePage;
            
            CurrentPage.uiDriver = this;
          

            CurrentPage.container = mainPage;

            if (pages[page] == typeof(pageLogon))
            {
                LogOff(this, new EventArgs());
                (CurrentPage as pageLogon).AuthenticationSucceded += new AuthenticatedHandler(UIDriver_AuthenticationSucceded);
            }
           
            PageLoading(CurrentPage);
            if (CurrentPage is AuthenticatedPage)
            {
                AuthenticatedPage cp = CurrentPage as AuthenticatedPage;
                if (cp.Authenticate() && cp.Authorize())
                {
                    container.Children.Add(CurrentPage);
                    PageLoaded(CurrentPage);
                }
                else
                {
                    CurrentPage.Dispose();
                    Activate(EPages.Logon);
                }
            }
            else
            {
                container.Children.Add(CurrentPage);
                PageLoaded(CurrentPage);
            }
            mainPage.serviceID = serviceID;
        }


        void UIDriver_AuthenticationSucceded(object sender, AuthenticationEventArgs e)
        {
            AuthenticationSucceded(sender, e);
        }

        internal static DateTime GetTime()
        {

            return DateTime.UtcNow.Add(UI.TIME_DIFF);
        }

        internal static string GetFormattedTime(DateTime dt)
        {
            if (Security.CurrentUser.GetProfileItem("TimeZone").ToString() == "UTC")
                return dt.ToString(Security.CurrentUser.GetProfileItem("TimeFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeZone").ToString());
            else
                return dt.ToLocalTime().ToString(Security.CurrentUser.GetProfileItem("TimeFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeZone").ToString());

        }

        internal static string GetFormattedDate(DateTime dt)
        {
            // return dt.ToString(Security.CurrentUser.GetProfileItem("DateFormat").ToString());
            return dt.ToString(UI.DATE_FORMAT_ARRAY[0] + " " + UI.TIME_FORMAT_ARRAY[0] + " " + UI.TIME_ZONE_ARRAY[0]);

        }

        internal static string GetFormattedDateTime(DateTime dt)
        {
            return dt.ToString(UI.DATE_FORMAT_ARRAY[0] + " " + UI.TIME_FORMAT_ARRAY[0] + " " + UI.TIME_ZONE_ARRAY[0]);
            /*
            if (Security.CurrentUser == null) return dt.ToString(UI.DATE_FORMAT_ARRAY[0] + " " + UI.TIME_FORMAT_ARRAY [0] + " " + UI.TIME_ZONE_ARRAY [0]);
            if (Security.CurrentUser.GetProfileItem("TimeZone").ToString()=="UTC")
                return dt.ToString(Security.CurrentUser.GetProfileItem("DateFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeZone").ToString());
            else
                return dt.ToLocalTime().ToString(Security.CurrentUser.GetProfileItem("DateFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeFormat").ToString() + " " +
                                        Security.CurrentUser.GetProfileItem("TimeZone").ToString());
             * */
        }

        internal static object GetFormattedPosition(Point point)
        {
            return "";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static void ExportToExcel(C1DataGrid dGrid, SaveFileDialog objSFD)
        {
            bool? s = objSFD.ShowDialog();
            if (s == true)
            {

                string strFormat =
                      objSFD.SafeFileName.Substring(objSFD.SafeFileName.IndexOf('.') + 1).ToUpper();
                StringBuilder strBuilder = new StringBuilder();
                if (dGrid.ItemsSource == null) return;
                List<string> lstFields = new List<string>();
                if (dGrid.HeadersVisibility == C1.Silverlight.DataGrid.DataGridHeadersVisibility.Column ||
                    dGrid.HeadersVisibility == C1.Silverlight.DataGrid.DataGridHeadersVisibility.All)
                {
                    foreach (C1.Silverlight.DataGrid.DataGridColumn dgcol in dGrid.Columns)
                        lstFields.Add(FormatField(dgcol.Header.ToString().ToUpper(), strFormat));
                    BuildStringOfRow(strBuilder, lstFields, strFormat);
                }

                foreach (object data in dGrid.ItemsSource)
                {
                    lstFields.Clear();
                    foreach (C1.Silverlight.DataGrid.DataGridColumn col in dGrid.Columns)
                    {
                        object strValue = null;
                        System.Windows.Data.Binding objBinding = null;
                        if (col is C1.Silverlight.DataGrid.DataGridBoundColumn)
                            objBinding = (col as C1.Silverlight.DataGrid.DataGridBoundColumn).Binding;
                        //if (col is DataGridTemplateColumn)
                        //{
                        //    //This is a template column...
                        //    //    let us see the underlying dependency object
                        //    DependencyObject objDO =
                        //      (col as DataGridTemplateColumn).CellTemplate.LoadContent();
                        //    FrameworkElement oFE = (FrameworkElement)objDO;
                        //    FieldInfo oFI = oFE.GetType().GetField("TextProperty");
                        //    if (oFI != null)
                        //    {
                        //        if (oFI.GetValue(null) != null)
                        //        {
                        //            if (oFE.GetBindingExpression(
                        //                   (DependencyProperty)oFI.GetValue(null)) != null)
                        //                objBinding =
                        //                  oFE.GetBindingExpression(
                        //                  (DependencyProperty)oFI.GetValue(null)).ParentBinding;
                        //        }
                        //    }
                        //}
                        if (objBinding != null)
                        {
                            if (objBinding.Path.Path != "")
                            {
                                PropertyInfo pi = data.GetType().GetProperty(objBinding.Path.Path);
                                if (pi != null) strValue = pi.GetValue(data, null);
                            }
                            if (objBinding.Converter != null)
                            {
                                if (strValue != "")
                                    strValue = objBinding.Converter.Convert(strValue,
                                      typeof(string), objBinding.ConverterParameter,
                                      objBinding.ConverterCulture).ToString();
                                else
                                    strValue = objBinding.Converter.Convert(data,
                                      typeof(string), objBinding.ConverterParameter,
                                      objBinding.ConverterCulture).ToString();
                            }
                        }
                        lstFields.Add(FormatField(strValue.ToString(), strFormat));
                    }
                    BuildStringOfRow(strBuilder, lstFields, strFormat.ToUpper());
                }

                StreamWriter sw = new StreamWriter(objSFD.OpenFile());
                if (strFormat == "XLS")
                {
                    //Let us write the headers for the Excel XML
                    sw.WriteLine("<?xml version=\"1.0\" " +
                                 "encoding=\"utf-8\"?>");
                    sw.WriteLine("<?mso-application progid" +
                                 "=\"Excel.Sheet\"?>");
                    sw.WriteLine("<Workbook xmlns=\"urn:" +
                                 "schemas-microsoft-com:office:spreadsheet\">");
                    sw.WriteLine("<DocumentProperties " +
                                 "xmlns=\"urn:schemas-microsoft-com:" +
                                 "office:office\">");
                    sw.WriteLine("<Author></Author>");
                    sw.WriteLine("<Created>" +
                                 DateTime.UtcNow.ToLocalTime().ToLongDateString() +
                                 "</Created>");
                    sw.WriteLine("<LastSaved>" +
                                 DateTime.UtcNow.ToLocalTime().ToLongDateString() +
                                 "</LastSaved>");
                    sw.WriteLine("<Company>iDeal Teknoloji</Company>");
                    sw.WriteLine("<Version>12.00</Version>");
                    sw.WriteLine("</DocumentProperties>");
                    sw.WriteLine("<Worksheet ss:Name=\"Silverlight Export\" " +
                       "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                    sw.WriteLine("<Table>");
                }
                sw.Write(strBuilder.ToString());
                if (strFormat == "XLS")
                {
                    sw.WriteLine("</Table>");
                    sw.WriteLine("</Worksheet>");
                    sw.WriteLine("</Workbook>");
                }
                sw.Close();
            }

        }


        static void BuildStringOfRow(StringBuilder strBuilder, List<string> lstFields, string strFormat)
        {
            switch (strFormat)
            {
                case "XML":
                case "XLS":
                    strBuilder.AppendLine("<Row>");
                    strBuilder.AppendLine(String.Join("\r\n", lstFields.ToArray()));
                    strBuilder.AppendLine("</Row>");
                    break;
                case "CSV":
                    strBuilder.AppendLine(String.Join(",", lstFields.ToArray()));
                    break;
            }
        }

        static string FormatField(string data, string format)
        {
            switch (format)
            {
                case "XLS":
                case "XML":
                    return String.Format("<Cell><Data ss:Type=\"String" +
                       "\">{0}</Data></Cell>", data);
                case "CSV":
                    return String.Format("\"{0}\"",
                      data.Replace("\"", "\"\"\"").Replace("\n",
                      "").Replace("\r", ""));
            }
            return data;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

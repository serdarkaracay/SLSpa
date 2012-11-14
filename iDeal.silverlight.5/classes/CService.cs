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
using System.Net.Browser;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Windows.Browser;
using System.IO.IsolatedStorage;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using System.Collections.Generic;
using C1.Silverlight.DataGrid;
using System.Windows.Data;
using System.Reflection;

namespace iDeal.silverlight
{
    public enum EErrorType
    {
        REQUEST,
        SERVER,
        READER,
        NODATA,
        DECOMPRESSION,
        UNKNOWN
    }



    public class ServiceException : Exception
    {
        public EErrorType ErrorType { get; set; }

        public ServiceException(EErrorType errorType, string msg)
            : base(msg)
        {
            ErrorType = errorType;
        }
    }

    public class CService
    {
        public string ServicePoint { get; set; }
        public DependencyObject Parent { get; set; }

        public CService()
        {
            if (string.IsNullOrEmpty(ServicePoint))
            {
                ServicePoint = HtmlPage.Document.DocumentUri.AbsoluteUri;
                if (ServicePoint.Contains("#"))
                    ServicePoint = ServicePoint.Substring(0, ServicePoint.IndexOf('#') + 1);
                ServicePoint = System.IO.Path.GetDirectoryName(ServicePoint).Replace("\\", "/").Replace(":/", "://");
            }
        }

        public void GetData(object sender, string sql, DataDownloadedHandler dataDownloaded, ServiceExceptionHandler errorReceived)
        {
            string uriString = String.Format(ServicePoint + "/Services/GetData.ashx?sql={0}", sql);
            HttpWebRequest client = WebRequest.CreateHttp(uriString);
            client.BeginGetResponse((async) =>
            {
                HttpWebResponse res=null;
                try
                {
                    res = (HttpWebResponse)client.EndGetResponse(async);
                }
                catch (Exception v)
                {
                    Exception vv=new Exception(v.Message + " URL : " + uriString);
                    if (errorReceived != null) errorReceived(async.AsyncState, new ServiceException(EErrorType.REQUEST, "Response error."));
                    return;
                }
                if (res.ContentType.Contains("text/xml"))
                {
                    XDocument document=null;
                    try
                    {
                        using (GZipInputStream zip=new GZipInputStream(res.GetResponseStream()))
                        {
                            document = XDocument.Load(zip);
                            zip.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        if (errorReceived != null) errorReceived(async.AsyncState, new ServiceException(EErrorType.DECOMPRESSION, exc.Message));
                        return;
                    }
                    dataDownloaded(async.AsyncState, document.Element("table"));
                }
                else
                {
                    //REQUEST,SERVER,READER,NODATA

                    Stream str = res.GetResponseStream();
                    string s=String.Empty;
                    string[] ss=null;
                    string f=String.Empty;
                    using (StreamReader sr = new StreamReader(str))
                    {
                        s = sr.ReadToEnd();
                    }
                    if (s != String.Empty) ss = s.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    EErrorType et=EErrorType.UNKNOWN;
                    f = ss == null ? "UNKNOWN" : ss[0];
                    Enum.TryParse(f, out et);
                    ServiceException ex=new ServiceException(et, ss[1]);
                    if (errorReceived != null) errorReceived(async.AsyncState, ex);
                }
            }, sender);

        }

        public void Execute(object sender, string sql, ExecutionCompletedHandler executionCompleted, ServiceExceptionHandler errorReceived)
        {
            string uriString = String.Format(ServicePoint + "/Services/execute.ashx?sql={0}", sql);
            HttpWebRequest client = WebRequest.CreateHttp(uriString);
            client.BeginGetResponse((async) =>
            {
                HttpWebResponse res=null;
                try
                {
                    res = (HttpWebResponse)client.EndGetResponse(async);
                }
                catch (Exception v)
                {
                    Exception vv=new Exception(v.Message + " URL : " + uriString);
                    if (errorReceived != null) errorReceived(async.AsyncState, new ServiceException(EErrorType.REQUEST, "Response error."));
                    return;
                }
                if (res.ContentType.Contains("text/result"))
                {
                     int r=-1;
                   Stream str=res.GetResponseStream();
                   using (StreamReader sr=new StreamReader(str))
                   {
                       string s=sr.ReadToEnd();
                       int.TryParse(s, out r);
                   }
                    executionCompleted(async.AsyncState, r );
                }
                else
                {
                    //REQUEST,SERVER,READER,NODATA

                    Stream str = res.GetResponseStream();
                    string s=String.Empty;
                    string[] ss=null;
                    string f=String.Empty;
                    using (StreamReader sr = new StreamReader(str))
                    {
                        s = sr.ReadToEnd();
                    }
                    if (s != String.Empty) ss = s.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    EErrorType et=EErrorType.UNKNOWN;
                    f = ss == null ? "UNKNOWN" : ss[0];
                    Enum.TryParse(f, out et);
                    ServiceException ex=new ServiceException(et, ss[1]);
                    if (errorReceived != null) errorReceived(async.AsyncState, ex);
                }
            }, sender);

        }

        public void GetXML(object sender, string xmlPath, DataDownloadedHandler dataDownloaded, ExceptionHandler errorReceived)
        {
            string uriString =  String.Format(ServicePoint + xmlPath);


            WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Credentials = new NetworkCredential("serviceuser", "password");
            client.UseDefaultCredentials = false;

            //Debug.WriteLine(uriString);


            client.OpenReadCompleted += (s, e) =>
            {

                if (!e.Cancelled && (e.Error == null))
                {

                    XDocument document = XDocument.Load(e.Result);
                    dataDownloaded(sender, document.Element("root"));
                    Thread.CurrentThread.Join(2);


                }
                else
                {
#if DEBUG
                    //MessageBox.Show(e.Error.Message + "\r\n" + (e.Error.InnerException != null ? e.Error.InnerException.Message : ""));
#endif
                    if (errorReceived != null) errorReceived(null, e.Error);
                }

            };
            try
            {
                client.OpenReadAsync(new Uri(uriString, UriKind.Absolute));
            }
            catch (Exception ex)
            {

#if DEBUG
                MessageBox.Show(ex.Message + "\r\n" + (ex.InnerException != null ? ex.InnerException.Message : ""));
#endif
            }


        }

        public void SendMessage(object sender, string msg, MessageReceivedHandler messageReceived, ExceptionHandler errorReceived)
        {
            string uriString = String.Format(ServicePoint + "/Services/SendMessage.ashx?msg={0}", msg);
            //WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            //WebClient client = new WebClient();
            //client.Credentials = new NetworkCredential("serviceuser", "password");
            //client.UseDefaultCredentials = false;

            //client.OpenReadCompleted += (s, e) =>
            //{

            //    if (!e.Cancelled && (e.Error == null))
            //    {

            //        if (client.ResponseHeaders[HttpRequestHeader.ContentType].Contains("text/plain"))
            //        {
            //            Stream str = e.Result;
            //            StreamReader sr = new StreamReader(str);
            //            string x=sr.ReadToEnd();
            //            if (messageReceived != null) messageReceived(null, x);


            //        }
            //        else
            //        {
            //            Stream str = e.Result;
            //            StreamReader sr = new StreamReader(str);
            //            Exception exc = new Exception(sr.ReadToEnd());

            //            if (errorReceived != null) errorReceived("MessageService", exc);
            //        }
            //    }
            //    else
            //    {
            //        if (errorReceived != null) errorReceived("MessageService", e.Error );
            //    }

            //};
            //client.OpenReadAsync(new Uri(uriString, UriKind.Absolute));

            HttpWebRequest client = WebRequest.CreateHttp(uriString);


            client.BeginGetResponse((async) =>
            {
                HttpWebResponse res=null;
                try
                {
                    res = (HttpWebResponse)client.EndGetResponse(async);
                }
                catch (Exception v)
                {
                    Exception vv=new Exception(v.Message + " URL : " + uriString);
                    if (errorReceived != null) errorReceived(async.AsyncState, new ServiceException(EErrorType.REQUEST, "Response error."));
                    return;
                }
                if (res.ContentType.Contains("text/plain"))
                {
                    Stream str = res.GetResponseStream();
                    StreamReader sr = new StreamReader(str);
                    string x=sr.ReadToEnd();
                    if (messageReceived != null) messageReceived(async.AsyncState, x);


                }
                else
                {
                    //REQUEST,SERVER,READER,NODATA

                    Stream str = res.GetResponseStream();
                    StreamReader sr = new StreamReader(str);
                    Exception exc = new Exception(sr.ReadToEnd());

                    if (errorReceived != null) errorReceived(async.AsyncState, exc);
                }
            }, sender);


        }

        #region STATIC METHODS

        public static void SaveData(string data, string fileName)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(fileName, FileMode.Create, isf))
                {
                    using (StreamWriter sw = new StreamWriter(isfs))
                    {
                        sw.WriteLine(data);
                        sw.Close();
                    }
                }
            }
        }

        public static string LoadData(string fileName)
        {
            string data = String.Empty;
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {


                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(fileName, FileMode.Open, isf))
                    {
                        using (StreamReader sr = new StreamReader(isfs))
                        {
                            string lineOfData = String.Empty;
                            while ((lineOfData = sr.ReadLine()) != null)
                                data += lineOfData.Trim();
                        }
                    }

                }

            }
            catch (Exception)
            {

                return "";
            }
            return data;
        }

        public static void TryGetString(XElement xml, string attributeName, String prop)
        {
            if (xml.Attribute(attributeName) != null)
                prop = xml.Attribute(attributeName).Value.ToString();
        }
        public static void TryGetGuid(XElement xml, string attributeName, Guid prop)
        {
            if (xml.Attribute(attributeName) != null)
                Guid.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetDateTime(XElement xml, string attributeName, DateTime prop)
        {
            if (xml.Attribute(attributeName) != null)
                DateTime.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetDouble(XElement xml, string attributeName, Double prop)
        {
            if (xml.Attribute(attributeName) != null)
                Double.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetInt32(XElement xml, string attributeName, Int32 prop)
        {
            if (xml.Attribute(attributeName) != null)
                Int32.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetInt64(XElement xml, string attributeName, Int64 prop)
        {
            if (xml.Attribute(attributeName) != null)
                Int64.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetBoolean(XElement xml, string attributeName, Boolean prop)
        {
            if (xml.Attribute(attributeName) != null)
                bool.TryParse(xml.Attribute(attributeName).Value, out prop);
        }
        public static void TryGetPoint(XElement xml, string attributeName, Point prop)
        {
            if (xml.Attribute(attributeName) != null)
            {
                string[] xy=xml.Attribute(attributeName).Value.ToString().Split(new char[] { ';' });
                double x=181,y=91;
                double.TryParse(xy[0], out x);
                double.TryParse(xy[1], out y);
                if (x != 181 && y != 91) prop = new Point(x, y);
            }
        }

        public static string GetString(XElement xml, string attributeName)
        {
            return GetString(xml, attributeName, "");
        }

        public static string GetString(XElement xml, string attributeName, string defValue)
        {
            string result = defValue;
            if (xml.Attribute(attributeName) != null)
                result = xml.Attribute(attributeName).Value.ToString();
            return result;
        }

        public static Guid GetGuid(XElement xml, string attributeName)
        {
            Guid result = Guid.Empty;
            if (xml.Attribute(attributeName) != null)
                Guid.TryParse(xml.Attribute(attributeName).Value, out result);
            return result;
        }

        public static DateTime GetDateTime(XElement xml, string attributeName)
        {
            return GetDateTime(xml, attributeName, DateTime.MinValue);
        }

        public static DateTime GetDateTime(XElement xml, string attributeName, DateTime defValue)
        {
            DateTime result = defValue;
            if (xml.Attribute(attributeName) != null)
                DateTime.TryParse(xml.Attribute(attributeName).Value, out result);
            return result;
        }

        public static double GetDouble(XElement xml, string attributeName)
        {
            return GetDouble(xml, attributeName, Double.MinValue);
        }

        public static double GetDouble(XElement xml, string attributeName, double defValue)
        {
            double result = defValue;
            if (xml.Attribute(attributeName) != null)
                double.TryParse(xml.Attribute(attributeName).Value.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
            return result;
        }

        public static Int32 GetInt32(XElement xml, string attributeName)
        {
            return GetInt32(xml, attributeName, Int32.MinValue);
        }

        public static Int32 GetInt32(XElement xml, string attributeName, int defValue)
        {
            Int32 result = defValue;
            if (xml.Attribute(attributeName) != null)
                Int32.TryParse(xml.Attribute(attributeName).Value, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="attributeName"></param>
        /// <returns>Default value is false</returns>
        public static bool GetBoolean(XElement xml, string attributeName)
        {
            return GetBoolean(xml, attributeName, false);
        }

        public static bool GetBoolean(XElement xml, string attributeName, bool defValue)
        {
            bool result = defValue;
            if (xml.Attribute(attributeName) != null)
                bool.TryParse(xml.Attribute(attributeName).Value, out result);
            return result;
        }

        public static Point GetPoint(XElement xml, string p)
        {
            throw new NotImplementedException();
        }

        public static Point GetPoint(string p)
        {
            return GetPoint(p, ';');
        }

        public static Point GetPoint(string p, char separatorChar)
        {
            if (string.IsNullOrEmpty(p)) return new Point(0, 0);
            string[] xy=p.Replace(',', '.').Split(new char[] { separatorChar });
            double x=0,y=0;
            try
            {
                y = double.Parse(xy[0], CultureInfo.InvariantCulture);
                x = double.Parse(xy[1], CultureInfo.InvariantCulture);
            }
            catch { }
            return new Point(x, y);
        }

        public static Int32 GetInt32(string p)
        {
            Int32 x=0;
            Int32.TryParse(p, NumberStyles.Float, CultureInfo.InvariantCulture, out x);
            return x;
        }

        public static void ExportToExcel(C1DataGrid grid)
        {
            SaveFileDialog objSFD = new SaveFileDialog()
            {
                DefaultExt = "xls",
                Filter = "Excel Files (*.xls)|*.xls|All files (*.*)|*.*",
                FilterIndex = 1
            };
            if (objSFD.ShowDialog() == true)
            {
                ExportDataGrid(grid, objSFD);
            }
        }

        public static object GetValue(string val, Type type)
        {
            return GetValue(val, type.ToString());
        }

        public static object GetValue(string val, string type)
        {
            switch (type)
            {
                case "System.Boolean":
                    return Boolean.Parse(val);
                case "System.Single":
                    return float.Parse(val.Replace(",", "."), CultureInfo.InvariantCulture);
                case "System.Double":
                    return Double.Parse(val.Replace(",", "."), CultureInfo.InvariantCulture);
                case "System.Int16":
                    return Int16.Parse(val);
                case "System.Int32":
                    return Int32.Parse(val);
                case "System.Int64":
                    return Int64.Parse(val);
                case "System.UInt16":
                    return UInt16.Parse(val);
                case "System.UInt32":
                    return UInt32.Parse(val);
                case "System.UInt64":
                    return UInt64.Parse(val);
                case "System.DateTime":
                    return DateTime.SpecifyKind(DateTime.Parse(val), DateTimeKind.Utc);
                case "System.String":
                    return val;
                case "System.Byte":
                    return Byte.Parse(val);
                case "System.SByte":
                    return SByte.Parse(val);
                case "System.Guid":
                    return Guid.Parse(val);
                case "System.Windows.Point":
                    return GetPoint(val, ';');
                default:
                    return val;
            }
        }

        public static object GetObject(XElement xml, string p, string type)
        {
            return GetValue(CService.GetString(xml, p), type);
        }

        public static string GetStrValue(object itemValue)
        {
            switch (itemValue.GetType().ToString())
            {
                case "System.Boolean":
                    return (bool)itemValue ? "1" : "0";
                case "System.Single":
                case "System.Double":
                    return itemValue.ToString().Replace(',', '.');
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                case "System.String":
                case "System.Byte":
                case "System.SByte":
                default:
                    return itemValue.ToString();
                case "System.DateTime":
                    DateTime dt=(DateTime)itemValue;
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");
                case "System.Guid":
                    return itemValue.ToString().Replace("{", "").Replace("}", "");
                case "System.Windows.Point":
                    Point p=(Point)itemValue;
                    return p.Y + ";" + p.X;

            }
        }

        static void ExportDataGrid(C1DataGrid dGrid, SaveFileDialog objSFD)
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
            if (dGrid.ItemsSource is PagedCollectionView)
            {
                foreach (object data in (dGrid.ItemsSource as PagedCollectionView).SourceCollection)
                {
                    lstFields.Clear();
                    foreach (C1.Silverlight.DataGrid.DataGridColumn col in dGrid.Columns)
                    {
                        string strValue = "";
                        Binding objBinding = null;
                        if (col is C1.Silverlight.DataGrid.DataGridBoundColumn)
                            objBinding = (col as C1.Silverlight.DataGrid.DataGridBoundColumn).Binding;
                        if (col is C1.Silverlight.DataGrid.DataGridTemplateColumn)
                        {
                            //This is a template column...
                            //    let us see the underlying dependency object
                            DependencyObject objDO =
                          (col as C1.Silverlight.DataGrid.DataGridTemplateColumn).CellTemplate.LoadContent();
                            FrameworkElement oFE = (FrameworkElement)objDO;
                            FieldInfo oFI = oFE.GetType().GetField("TextProperty");
                            if (oFI != null)
                            {
                                if (oFI.GetValue(null) != null)
                                {
                                    if (oFE.GetBindingExpression(
                                           (DependencyProperty)oFI.GetValue(null)) != null)
                                        objBinding =
                                          oFE.GetBindingExpression(
                                          (DependencyProperty)oFI.GetValue(null)).ParentBinding;
                                }
                            }
                        }
                        if (objBinding != null)
                        {
                            if (objBinding.Path.Path != "")
                            {
                                PropertyInfo pi = data.GetType().GetProperty(objBinding.Path.Path);
                                if (pi != null) strValue = pi.GetValue(data, null).ToString();
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
                        lstFields.Add(FormatField(strValue, strFormat));
                    }
                    BuildStringOfRow(strBuilder, lstFields, strFormat);
                }
            }
            else
            {
                foreach (object data in dGrid.ItemsSource)
                {
                    lstFields.Clear();
                    foreach (C1.Silverlight.DataGrid.DataGridColumn col in dGrid.Columns)
                    {
                        string strValue = "";
                        Binding objBinding = null;
                        if (col is C1.Silverlight.DataGrid.DataGridBoundColumn)
                            objBinding = (col as C1.Silverlight.DataGrid.DataGridBoundColumn).Binding;
                        if (col is C1.Silverlight.DataGrid.DataGridTemplateColumn)
                        {
                            //This is a template column...
                            //    let us see the underlying dependency object
                            DependencyObject objDO =
                          (col as C1.Silverlight.DataGrid.DataGridTemplateColumn).CellTemplate.LoadContent();
                            FrameworkElement oFE = (FrameworkElement)objDO;
                            FieldInfo oFI = oFE.GetType().GetField("TextProperty");
                            if (oFI != null)
                            {
                                if (oFI.GetValue(null) != null)
                                {
                                    if (oFE.GetBindingExpression(
                                           (DependencyProperty)oFI.GetValue(null)) != null)
                                        objBinding =
                                          oFE.GetBindingExpression(
                                          (DependencyProperty)oFI.GetValue(null)).ParentBinding;
                                }
                            }
                        }
                        if (objBinding != null)
                        {
                            if (objBinding.Path.Path != "")
                            {
                                PropertyInfo pi = data.GetType().GetProperty(objBinding.Path.Path);
                                if (pi != null) strValue = pi.GetValue(data, null).ToString();
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
                        lstFields.Add(FormatField(strValue, strFormat));
                    }
                    BuildStringOfRow(strBuilder, lstFields, strFormat);
                }
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

        static void BuildStringOfRow(StringBuilder strBuilder, List<string> lstFields, string strFormat)
        {
            switch (strFormat)
            {
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
                    return String.Format("<Cell><Data ss:Type=\"String" +
                       "\">{0}</Data></Cell>", data);
                case "CSV":
                    return String.Format("\"{0}\"",
                      data.Replace("\"", "\"\"\"").Replace("\n",
                      "").Replace("\r", ""));
            }
            return data;
        }

        #endregion

    }
}

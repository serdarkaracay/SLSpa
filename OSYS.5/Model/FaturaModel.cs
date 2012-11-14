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
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace OSYS.Model
{
    public class FaturaModel:INotifyPropertyChanged
    {  
        public event PropertyChangedEventHandler PropertyChanged;

        
        public FaturaModel()
        {
            //SetReportUrls();
            PropertyChanged += new PropertyChangedEventHandler(FaturaModel_PropertyChanged);
                
        }

        void FaturaModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "MeterTypeID" ||
                e.PropertyName == "InvoiceDate" ||
                e.PropertyName == "InvoiceFinishDate" ||
                e.PropertyName == "CustomerID" ||
                e.PropertyName == "CustomerGroupID")
            {
                CreateUrls();
            }
            
        }

        
        private int _MeterTypeID = 0;
        public int MeterTypeID
        {
            get { return _MeterTypeID; }
            set
            {
                if (MeterTypeID == value)
                {
                    return;
                }
                _MeterTypeID = value;
                this.NotifyPropertyChanged("MeterTypeID");
            }
        }



        private long? _CustomerID;
        public long? CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if (CustomerID == value)
                {
                    return;
                }
                _CustomerID = value;
                this.NotifyPropertyChanged("CustomerID");
            }
        }

        private long? _CustomerGroupID;
        public long? CustomerGroupID
        {
            get { return _CustomerGroupID; }
            set
            {
                if (CustomerGroupID == value)
                {
                    return;
                }
                _CustomerGroupID = value;
                this.NotifyPropertyChanged("CustomerGroupID");
            }
        }



        private DateTime _InvoiceDate;
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set
            {
                if (InvoiceDate == value)
                {
                    return;
                }
                _InvoiceDate = value;
                this.NotifyPropertyChanged("InvoiceDate");
            }
        }


        private DateTime _InvoiceFinishDate;
        public DateTime InvoiceFinishDate
        {
            get { return _InvoiceFinishDate; }
            set
            {
                if (InvoiceFinishDate == value)
                {
                    return;
                }
                _InvoiceFinishDate = value;
                this.NotifyPropertyChanged("InvoiceFinishDate");
            }
        }
        

        #region ReportViewerURL
        private string _ReportViewerURL = "";
        public string ReportViewerURL
        {
            get { return _ReportViewerURL; }
            set
            {
                if (ReportViewerURL == value)
                {
                    return;
                }
                _ReportViewerURL = value;
                this.NotifyPropertyChanged("ReportViewerURL");
            }
        }
        #endregion
        
        #region INotifyPropertyChanged

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        #region GetBaseAddress
        private static Uri GetBaseAddress()
        {
            // Get the web address of the .xap that launched this application     
            string strBaseWebAddress = App.Current.Host.Source.AbsoluteUri;
            // Find the position of the ClientBin directory        
            int PositionOfClientBin =
                App.Current.Host.Source.AbsoluteUri.ToLower().IndexOf(@"/clientbin");
            // Strip off everything after the ClientBin directory         
            strBaseWebAddress = Strings.Left(strBaseWebAddress, PositionOfClientBin);
            // Create a URI
            Uri UriWebService = new Uri(String.Format(@"{0}/Reports/Report.aspx?", strBaseWebAddress));
            // Return the base address          
            return UriWebService;
        }
        #endregion

        #region SetReportUrls
        private void CreateUrls()
        {
            string custID = string.Empty;
            string groupID = string.Empty;

            if (CustomerID!=null)
            {
                custID = CustomerID.ToString();
            }

              if (CustomerGroupID!=null)
            {
                groupID = CustomerGroupID.ToString();
            }
            
            
            ReportViewerURL = String.Format("{0}meterTypeID={1}&InvoiceDate={2}&InvoiceFinishDate={3}&CustomerID={4}&CustomerGroupID={5}&ShowReportViewer=True",
                    GetBaseAddress(), MeterTypeID.ToString(), InvoiceDate.Date.ToString(), InvoiceFinishDate.Date.ToString()
                    ,custID.ToString(),groupID.ToString());
       }
        #endregion

    }
}


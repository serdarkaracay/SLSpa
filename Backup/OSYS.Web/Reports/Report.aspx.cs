using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using OSYS.Web.DTO;

namespace OSYS.Web.Reports
{
    public partial class Report : System.Web.UI.Page
    {
        private OSYSWcfService service;
        DataTable ls;
        int MeterTypeID;
        private DateTime InvoiceDate;
        DateTime InvoiceFinishDate;
        private long? CustomerID;
        private long? CustomerGroupID;


        protected void Page_Load(object sender, EventArgs e)
        {

            // If parameters are passed just render report
            if (Request.QueryString["MeterTypeID"] != null)
            {
                MeterTypeID = Convert.ToInt32(Request.QueryString["MeterTypeID"]);
                InvoiceDate = Convert.ToDateTime(Request.QueryString["InvoiceDate"]);
                InvoiceFinishDate = Convert.ToDateTime(Request.QueryString["InvoiceFinishDate"]);
                CustomerID = String.IsNullOrEmpty(Request.QueryString["CustomerID"]) ? (long?)null : Convert.ToInt64(Request.QueryString["CustomerID"]);
                CustomerGroupID = String.IsNullOrEmpty(Request.QueryString["CustomerGroupID"]) ? (long?)null : Convert.ToInt64(Request.QueryString["CustomerGroupID"]);


                if (Request.QueryString["ShowReportViewer"] == "False")
                {
                    RenderReport();
                    // ShowReportViewer(); 
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        ShowReportViewer();
                    }
                }
            }
        }

        #region LoadData
        private DataTable LoadData()
        {
            //string Gender = Convert.ToString(Request.QueryString["Gender"]);
            //int AgeHigh = Convert.ToInt32(Request.QueryString["AgeHigh"]);
            //int AgeLow = Convert.ToInt32(Request.QueryString["AgeLow"]);
            //int WeightHigh = Convert.ToInt32(Request.QueryString["WeightHigh"]);
            //int WeightLow = Convert.ToInt32(Request.QueryString["WeightLow"]);



            //var result = from objPeople in People.GetPeople().AsQueryable()
            //             where objPeople.Age <= AgeHigh
            //             where objPeople.Age >= AgeLow
            //             where objPeople.Weight <= WeightHigh
            //             where objPeople.Weight >= WeightLow
            //             select objPeople;

            //if (Gender != "All")
            //{
            //    result = from finalresult in result
            //             where finalresult.Gender == Gender
            //             select finalresult;
            //}

            // Utility objUtility = new Utility();
            //DataTable dt = LINQToDataTable(ls);



            //DataTable dt = null;

            DataTable dt = ls;

            return dt;
        }
        #endregion

        #region RenderReport
        private void RenderReport()
        {
            // CheckBox to see if there is any data
            if (LoadData().Rows.Count > 0)
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Report1.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", LoadData());
                localReport.DataSources.Add(reportDataSource);

                string reportType = "pdf";
                string mimeType = "application/pdf";
                string encoding;
                string fileNameExtension;

                //The DeviceInfo settings should be changed based on the reportType
                //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
                string deviceInfo =
                "<DeviceInfo>" +
                " <OutputFormat>PDF</OutputFormat>" +
                " <PageWidth>8.5in</PageWidth>" +
                " <PageHeight>11in</PageHeight>" +
                " <MarginTop>0.5in</MarginTop>" +
                " <MarginLeft>1in</MarginLeft>" +
                " <MarginRight>1in</MarginRight>" +
                " <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";

                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                //Render the report
                renderedBytes = localReport.Render(
                reportType,
               deviceInfo,
               out mimeType,
               out encoding,
               out fileNameExtension,
               out streams,
               out warnings);

                //Clear the response stream and write the bytes to the outputstream
                //Set content-disposition to "attachment" so that user is prompted to take an action
                //on the file (open or save)
                Response.Clear();
                Response.ContentType = mimeType;
                //Response.AddHeader("content-disposition", "attachment; filename=foo." + fileNameExtension);
                Response.BinaryWrite(renderedBytes);
                Response.End();
            }
            else
            {
                // There were no records returned
                Response.Clear();
                //Response.AddHeader("content-disposition", "attachment; filename=foo." + fileNameExtension);
                Response.Write("No Data");
                Response.End();
            }
        }
        #endregion

        #region ShowReportViewer
        private void ShowReportViewer()
        {
            string ReportName = string.Empty;
            service = new OSYSWcfService();

            switch (MeterTypeID)
            {
                case 1:
                    ReportName = "ReportElec";
                    service.createInvoiceReportE(MeterTypeID, InvoiceDate, InvoiceFinishDate, CustomerID, CustomerGroupID);
                    ls = service.getInvoiceReportE();
                    break;
                case 2:
                    ReportName = "ReportWater";
                    service.createInvoiceReportW(MeterTypeID, InvoiceDate, InvoiceFinishDate, CustomerID, CustomerGroupID);
                    ls = service.getInvoiceReportW();
                    break;
                case 3:
                    ReportName = "ReportGas";

                    break;
            }

            this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/" + ReportName + ".rdlc");
            ReportViewer1.LocalReport.DataSources.Add(
               new ReportDataSource("DataSet1", ls));
            this.ReportViewer1.KeepSessionAlive = true;
        }
        #endregion

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

    }
}
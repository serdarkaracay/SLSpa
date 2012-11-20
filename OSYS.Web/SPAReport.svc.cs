using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DevExpress.Data.Utils.ServiceModel;
using DevExpress.Xpf.Printing.Service;
using DevExpress.XtraReports.Service;
using DevExpress.XtraReports.UI;

namespace OSYS.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SPAReport" in code, svc and config file together.
    [SilverlightFaultBehavior]
    public class SPAReport : DevExpress.XtraReports.Service.ReportService
    {
        protected override void FillDataSources(XtraReport report, string reportName, bool isDesignActive)
        {
        }

        protected override void SaveReportLayout(string reportName, byte[] layoutData)
        {
            throw new FaultException("This method is not implemented. Implement the SaveReportLayout method on the server-side, in the report service code-behind.");
        }
    }
}

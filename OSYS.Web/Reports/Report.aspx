
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="OSYS.Web.Reports.Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%

Response.AddHeader(
"PRAGMA", "NO-CACHE");
Response.ExpiresAbsolute =DateTime.Now.AddMinutes(-1);
Response.Expires = 0;
Response.CacheControl ="no-cache";

%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" AsyncRendering="false" SizeToReportContent="True"
            Width="100%" Height="100%" style="margin-bottom:30px"
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"     >
            <LocalReport ReportPath="Reports\Report1.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>   
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 
    </form>
</body>
</html>

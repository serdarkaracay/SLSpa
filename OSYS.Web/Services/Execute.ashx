<%@ WebHandler Language="C#" Class="Execute" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public class Execute : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/result";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);


        if (context.Application["CONSTR"] == null)
            context.Application["CONSTR"] = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["CONSTR"].ConnectionString; //"Data Source=93.187.207.238,1633;User ID=sa;Password=P@ssw0rd;Initial Catalog=POLAR";
        string commandText = "";
        try
        {

            commandText = context.Request["sql"].ToString();

        }
        catch (Exception )
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("REQUEST=sql bulunamadı");
            context.Response.OutputStream.Flush();
            return;

        }
        SqlConnection cn = new SqlConnection(context.Application["CONSTR"].ToString ());
        try
        {
            cn.Open();
        }
        catch (Exception x)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("SERVER=" + x.Message);
            context.Response.OutputStream.Flush();
            cn.Dispose();
            return;
        }
        SqlCommand cmd = cn.CreateCommand();
      


        cmd.CommandText = commandText;
        //SqlDataReader dr = null;
        int r=-1;
        try
        {
            //dr = cmd.ExecuteReader();
            r = cmd.ExecuteNonQuery();
        }
        catch (Exception x)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("READER=" + x.Message);
            context.Response.OutputStream.Flush();
            //dr.Close();
            cn.Close();
            cn.Dispose();
            return;
        }
        //if (!dr.HasRows)
        //{
        //    context.Response.ContentType = "text/plain";
        //    context.Response.Write("NODATA=No data found.");
        //    context.Response.OutputStream.Flush();
        //    dr.Close();
        //    cn.Close();
        //    cn.Dispose();
        //    return;
        //}
        //DataSet ds = new DataSet("table");
        //ds.Load(dr, LoadOption.OverwriteChanges, "row");
        //dr.Close();
        
        cn.Close();
        //foreach (DataColumn item in ds.Tables[0].Columns)
        //{
        //    item.ColumnMapping = MappingType.Attribute;
        //}
        //context.Response.Filter = new System.IO.Compression.GZipStream(context.Response.Filter, System.IO.Compression.CompressionMode.Compress);
        //ds.WriteXml(context.Response.OutputStream);
        //context.Response.OutputStream.Flush();
        using (System.IO.StreamWriter sw=new System.IO.StreamWriter (context.Response.OutputStream ) )
        {
            sw.Write(r.ToString());
        }
        context.Response.OutputStream.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}
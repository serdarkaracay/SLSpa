<%@ WebHandler Language="C#" Class="SendMessage" %>

using System;
using System.Web;
using System.Net.Sockets;
using System.Timers;

public class SendMessage : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string msg = "";
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (context.Request["msg"] == null)
        {
            context.Response.ContentType = "text/error";
            context.Response.Write("MESSAGE_NOT_FOUND");
            context.Response.End();
            return;
        }
        else
        {
            if (context.Request["msg"] == "")
            {
                context.Response.ContentType = "text/error";
                context.Response.Write("MESSAGE_NOT_FOUND");
                context.Response.End();
                return;
            }
            else msg = context.Request["msg"];
            
        }
        int MSG_ID = ((int)context.Application["MSG_ID"]);
        if (MSG_ID == 16384) MSG_ID = 1;
        context.Application["MSG_ID"] = ++MSG_ID;

        msg = "Msg=" + MSG_ID + "," + msg + "\r\n";
        
       
            TcpClient client = new TcpClient();
            string GATEWAY_IP = System.Web.Configuration.WebConfigurationManager.AppSettings["GATEWAY_IP"];
            string GATEWAY_PORT = System.Web.Configuration.WebConfigurationManager.AppSettings["GATEWAY_PORT"];
            int gateway_port = 0;
            int.TryParse(GATEWAY_PORT, out gateway_port);
            client.Connect(GATEWAY_IP, gateway_port);
            Socket socket = client.Client;
       

        byte[] buffer = new byte[8192];
        int rxLength = 0;
      
        if (socket == null)
        {
            context.Application["MSG_SOCKET"] = null;
            context.Response.ContentType = "text/error";
            context.Response.Write("SOCKET_NOT_READY");
            context.Response.End();
            return;
        }
        bool timedOut = false;
        Timer timer=new Timer();
        timer.AutoReset = false;
        timer.Interval = 5000;
        timer.Elapsed += delegate
        {
            timedOut = true;
            socket.Disconnect(false);
            socket.Send(new byte[] { 255 ,13,10});
            socket.Dispose();
            context.Application["MSG_SOCKET"] = null;
            
        };
        timer.Start();
        try
        {
            socket.Send(System.Text.Encoding.ASCII.GetBytes(msg));
        }
        catch (Exception)
        {
            
             context.Response.ContentType = "text/error";
            context.Response.Write("SEND_ERROR");
            context.Response.End();
            return;
        }
        context.Response.ContentType = "text/error";
        string result = "TIMEOUT";
        string responseMsg="";
        socket.ReceiveTimeout = 10000;
        while (socket.Connected && !timedOut)
        {
            rxLength = socket.Receive(buffer);
            responseMsg = System.Text.Encoding.ASCII.GetString(buffer, 0, rxLength);
            System.Diagnostics.Debug.WriteLine(responseMsg);
            if (responseMsg.Contains("Msg=" + MSG_ID))
            {
                context.Response.ContentType = "text/plain";
                result = responseMsg;
                context.Response.Write(result);
                context.Response.End();
                return;
            }
        }
        context.Response.Write(result);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
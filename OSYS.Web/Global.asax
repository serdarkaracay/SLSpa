﻿<%@ Application Language="C#" %>
<%@ Import Namespace ="System.Net.Sockets" %>


<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application["MSG_ID"] = 16384;
        Application["SOCKET"] = null;


    }
    
    void Application_End(object sender, EventArgs e) 
    {
       
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        

    }

    void Session_Start(object sender, EventArgs e)
    {
        string CookieHeaders = HttpContext.Current.Request.Headers["Cookie"];

        if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
        {
            // It is existing visitor, but ASP.NET session is expired
        }
        else
        {
            // It is a new visitor, session was not created before
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

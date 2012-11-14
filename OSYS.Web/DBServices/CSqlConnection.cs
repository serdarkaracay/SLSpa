using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OSYS.Web.DBServices
{
    static public class CSqlConnection
    {
        static public SqlConnection GetSPConnection { get; set; }
        static public SqlConnection GetSPInstantConnection { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace OSYS.Web.DBServices
{
    public class CSqlOperator
    {
        string connectionStr = "";
        SqlConnection conn, sconn;
        
        public CSqlOperator(string connectionString)
        {
            connectionStr = connectionString;
            if (CSqlConnection.GetSPConnection == null)
                CSqlConnection.GetSPConnection = new SqlConnection(connectionStr);

            if (CSqlConnection.GetSPInstantConnection == null)
                CSqlConnection.GetSPInstantConnection = new SqlConnection(connectionStr);

            conn = CSqlConnection.GetSPConnection;
            sconn = CSqlConnection.GetSPInstantConnection;
          
        }

        public void executeSP(string SPName, Dictionary<string, object> args)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                        Debug.WriteLine("SP connection açıldı");
                    }
                    catch (Exception)
                    {
                        conn.Dispose();
                        conn = new SqlConnection(connectionStr);
                        conn.Open();
                    }
                }
                SqlCommand com = new SqlCommand(SPName, conn);
                com.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, object> item in args)
                    com.Parameters.AddWithValue(item.Key, item.Value);
                int i = com.ExecuteNonQuery();
               
            }
            catch (SqlException x)
            {
                List<string> sendArgs = new List<string>();
                foreach (KeyValuePair<string, object> item in args)
                {
                    sendArgs.Add(item.Key);
                    sendArgs.Add(item.Value.ToString());
                }
                if (sendArgs.Count % 2 != 0)
                {
                    sendArgs.Add(" ");
                }

                Console.WriteLine("SP adı hata:" + SPName + " Hata:" + x.Message + " Args:" + sendArgs.ToArray());
            }

        }

         public DataTable executeSPInstantly(string SPName, Dictionary<string, object> args)
        {

            DataTable dt = new DataTable();
            try
            {
                if (sconn.State != ConnectionState.Open)
                {
                    try
                    {
                        sconn = new SqlConnection(connectionStr);
                        sconn.Open();
                        Debug.WriteLine("SPInstant connection açıldı");
                    }
                    catch (Exception)
                    {
                        sconn.Dispose();
                        sconn = new SqlConnection(connectionStr);
                        sconn.Open();
                    }
                }
                SqlCommand com = new SqlCommand(SPName, sconn);
                com.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, object> item in args)
                    com.Parameters.AddWithValue(item.Key, item.Value);
                SqlDataReader dr = com.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                return dt;
            }
            catch (SqlException x)
            {
                List<string> sendArgs = new List<string>();
                foreach (KeyValuePair<string, object> item in args)
                {
                    sendArgs.Add(item.Key);
                    sendArgs.Add(item.Value.ToString());
                }
                if (sendArgs.Count % 2 != 0)
                {
                    sendArgs.Add(" ");
                }
                Console.WriteLine("SP adı hata:" + SPName + " Hata:" + x.Message + " Args:" + sendArgs.ToArray());
                return dt;
            }
        }
        
    }
}
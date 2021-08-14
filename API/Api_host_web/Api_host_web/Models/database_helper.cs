using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Api_host_web.Models
{
    public class database_helper
    {
        public DataTable Get_form_sql(string sql)
        {
            DataTable dt = new DataTable();
            string cf = ConfigurationManager.ConnectionStrings["suparat_SampleDBEntities1"].ConnectionString;
            SqlConnection sqlclient = new SqlConnection(cf);
            sqlclient.Open();
            SqlCommand com = new SqlCommand(sql, sqlclient);
            com.ExecuteNonQuery();
            SqlDataReader read = com.ExecuteReader();
            if(read.HasRows)
            {
                dt.Load(read);
            }
            sqlclient.Close();
            //object res = JsonConvert.SerializeObject(dt); 
            return dt;
        }
    }
}
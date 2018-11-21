using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace 目录树倒入
{
    internal class SQLHelper
    {
        static readonly string constr = "server = 10.18.105.189; database=FRDRM_DB;uid=sa;pwd=Password01!";
        // ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static DataTable ExecuteTable(string sql, params SqlParameter[] args)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, constr);
            da.SelectCommand.Parameters.AddRange(args);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public static int ExecuteNoQuery(string sql, params SqlParameter[] args)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(args);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }



    }
}
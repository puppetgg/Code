using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeData
{
    public class DapperConnection
    {
        public static IDbConnection GetConnection()
        {
            string connStr = "server = 10.18.105.189; database=FRDRM_DB;uid=sa;pwd=Password01!";
            //ConfigurationManager.AppSettings["conn"];
            return new SqlConnection(connStr);
        }
    }
}

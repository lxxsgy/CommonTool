using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using System.Data;
using System.Data.SqlClient;

namespace ICPSendMailRegularly.BLL
{
   public  class SqlServerHelper
    {
        private ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly string SqlServerConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString().Trim();
        public static string GetSqlServerConnectionString()
        {
            return SqlServerConnectionString;
        }

        public static DataTable QueryTable(string strSql)
        {
            using (var connection = new SqlConnection(SqlServerConnectionString))
            {
                var ds = new DataSet();
                try
                {
                    
                    connection.Open();
                    var command = new SqlDataAdapter(strSql,SqlServerConnectionString);
                    command.SelectCommand.CommandTimeout = 180;//设置查询sql的超时时间
                    command.Fill(ds,"ds");
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds.Tables[0];
            }
            
        }
    }
}

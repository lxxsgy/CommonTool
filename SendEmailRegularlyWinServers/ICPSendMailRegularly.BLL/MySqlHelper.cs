using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using System.Data;
using MySql.Data.MySqlClient;

namespace ICPSendMailRegularly.BLL
{
    public class MySqlHelper
    {
        private ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly string mySqlConnectionString = ConfigurationManager.ConnectionStrings["mySqlConstring"].ToString().Trim();
        public static string GetSqlConnectionstring()
        {
            return mySqlConnectionString;
        }
        public static DataTable ExecuteDataTable(string strSql)
        {
            using (var connection = new MySqlConnection(mySqlConnectionString))
            {
                var ds = new DataSet();
                try
                {
                    connection.Open();
                    var command = new MySqlDataAdapter(strSql,mySqlConnectionString);
                    command.SelectCommand.CommandTimeout = 180;//设置查询sql的超时时间
                    command.Fill(ds,"ds");
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }finally
                {
                    connection.Close();
                }
                return ds.Tables[0];
            }
        }
    }
}

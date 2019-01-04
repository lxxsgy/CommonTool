using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL
{
    public class SqlServerHelper
    {
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
                    var command = new SqlDataAdapter(strSql, SqlServerConnectionString);
                    command.SelectCommand.CommandTimeout = 180;//设置查询sql的超时时间
                    command.Fill(ds, "ds");
                }
                catch (Exception ex)
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

        public static object ExecuteScalar(string strSql)
        {
            object obj = new object();
            using (var connection = new SqlConnection(SqlServerConnectionString))
            {
                try
                {

                    connection.Open();
                    var command = new SqlCommand(strSql, connection);
                    obj= command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return obj;
            }
        }
    }
}

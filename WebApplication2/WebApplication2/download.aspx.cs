using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String fileId = Request.QueryString["FileId"];
            string ss = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\file.mdb";
            string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ss + ";Persist Security Info=False;";
            //string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|App_Data|file.mdb";
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(strCnString);
            String strSql = "select * from filedata Where fileId=@FileId";
            System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(strSql, myConnection);
            command.Parameters.AddWithValue("@FileId", fileId);
            //打开连接，执行查询
            myConnection.Open();
            System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Response.ClearContent();
                Response.ContentType = dr["ContentType"].ToString();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(dr["Title"].ToString()));
                Response.BinaryWrite((Byte[])dr["Content"]);
                Response.End();
            }
            myConnection.Close();

        }
    }
}
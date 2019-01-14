using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //构建数据库连接，SQL语句，创建参数


            string ss = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\file.mdb";
            string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ss + ";Persist Security Info=False;";
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(strCnString);
            String strSql = "SELECT count(*) FROM tab";
            // myConnection.Open();
            // System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(strSql, myConnection);
            //打开连接，执行查询
            DataSet ds = new DataSet();
            System.Data.OleDb.OleDbDataAdapter da = new OleDbDataAdapter();
            myConnection.Open();
            da.SelectCommand = new OleDbCommand(strSql, myConnection);
            da.Fill(ds, "tab");
            // System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            myConnection.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //得到文件数组
            //byte[] fileData = FileUpload1.FileBytes;
            ////得到文件大小
            //int fileLength = FileUpload1.PostedFile.ContentLength;
            ////得到文件名字
            //string fileName = System.IO.Path.GetFileName(FileUpload1.FileName);

            ////得到文件类型
            //string fileType = FileUpload1.PostedFile.ContentType;
            //string ss = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\file.mdb";
            ////构建数据库连接，SQL语句，创建参数
            //string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ss + ";Persist Security Info=False;";
            //System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(strCnString);
            //String strSql = "INSERT INTO fileData (ContentType,Content,Title)" +
            //                "VALUES (@ContentType,@Content,@Title)";
            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(strSql, myConnection);
            //command.Parameters.AddWithValue("@ContentType", fileType);
            //command.Parameters.AddWithValue("@Content", fileData);
            //command.Parameters.AddWithValue("@Title", fileName);
            ////打开连接，执行查询
            //myConnection.Open();
            //command.ExecuteNonQuery();
            //myConnection.Close();
            // Response.Redirect(Request.FilePath);

          //// 下载
          //  string ss = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\file.mdb";
          //  string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ss + ";Persist Security Info=False;";
          //  //string strCnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|App_Data|file.mdb";
          //  System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(strCnString);
          //  String strSql = "select * from filedata Where fileId=@FileId";
          //  System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(strSql, myConnection);
          //  command.Parameters.AddWithValue("@FileId", 2);
          //  //打开连接，执行查询
          //  myConnection.Open();
          //  System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader();
          //  if (dr.Read())
          //  {
          //      Response.ClearContent();
          //      Response.ContentType = dr["ContentType"].ToString();
              
          //      Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(dr["Title"].ToString()));
          //      Response.BinaryWrite((Byte[])dr["Content"]);
          //      Response.End();
          //  }
          //  myConnection.Close();

        }
        //上传文件到服务器
        //protected void btnupload_Click(object sender, EventArgs e)
        //{

        //    if(FileUpload1.HasFile)
        //    {
        //        Stream str = FileUpload1.FileContent;
        //        string filetype = FileUpload1.PostedFile.ContentType;
        //        //if(filetype=="image/bmp"||filetype=="image.pjpeg")
        //        //{

        //        //}
        //        string fileName = FileUpload1.PostedFile.FileName;
        //        FileInfo file = new FileInfo(fileName);
        //        string webfilePath = Server.MapPath("App_Data/"+ fileName);
        //        FileUpload1.SaveAs(webfilePath);
        //        this.lmsg.Text = "App_Data/" + fileName;


        //    }
        //}
    }
}
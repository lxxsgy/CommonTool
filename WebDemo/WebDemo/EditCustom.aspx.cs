using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Management;
namespace WebDemo
{
    public partial class EditCustom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            //Response.Charset = "utf-8";
            //string userName = Request["userName"];
            //if(userName!=null)
            //{
            //    Response.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //}
        }

        protected void BtnAddNews_Click(object sender, EventArgs e)
        {
            //string strTitle = TextNewsTitle.Text;
            //BulletedList1.Items.Add(strTitle+"  "+DateTime.Now.ToString());
         
        }
    }
}
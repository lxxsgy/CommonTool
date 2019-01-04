using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 web = new WebService1();
           if( web.HelloWorld()== "Hello World")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "js",

            "alert('登录成功')", true);
            }
           
        }
    }
}
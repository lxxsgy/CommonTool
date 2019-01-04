using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string username = "";
            if (Session["CurrentUser"]!=null)
            {
                username = Session["CurrentUser"].ToString();
            }  else
            {
                username = this.TextBoxUsername.Text;
            }
            
            string pwd = this.TextBoxpwd.Text;
            string checkcode = this.CheckCode.Text;
           if (!checkimage.checkCode(checkcode))
            {
                ClientScriptManager csm = Page.ClientScript;
                csm.RegisterStartupScript(GetType(), "", "<script>alert('验证码不对！！！');</script>");
                return;
            }
           if(!string.IsNullOrEmpty(username))

            {
                Session["CurrentUser"] = username;
                Response.Redirect("WebForm1.aspx");
               
            }  else
            {
               
                ClientScriptManager csm = Page.ClientScript;
                csm.RegisterStartupScript(GetType(),"", "<script>alert('用户名不能为空');</script>");
              //  Response.Write("<script>alert('用户名不能为空');</script>");
            }
        }
    }
}
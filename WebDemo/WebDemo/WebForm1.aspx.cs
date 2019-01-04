using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               var res= Request.QueryString["pwd"];
               var s= Request.Form["pwd"];
              var ss=  Request["pwd"];
               
                this.lblHostName.Text = Request.UserHostName;
                this.lblIP.Text = Request.UserHostAddress;
                this.lblURL.Text = Request.Url.ToString();
                string language = "en";
                //if(language=="ch")
                //{
                //    Server.Transfer("cn_index.html");
                //}else
                //{
                //    Server.Transfer("en_index.html");
                //}
              //string htmdecode=  Server.HtmlDecode("<script> alert(123);</script>");
              //string htmlEncode=  Server.HtmlEncode("<script> alert(123);</script>");
              //   htmdecode = Server.HtmlDecode(htmlEncode);

            } else
            {

            }
           
        }
    }
}
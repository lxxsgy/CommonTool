using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class UpdateProcessDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
            //Label1.Visible = true;
            //Label1.Text = "你选定日期是:"+Calendar1.SelectedDate.ToLongDateString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
          //  timeCount.Text = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

        }

        protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string make = DropDownList1.SelectedItem.Text;
            //string model = DropDownList2.SelectedItem.Text;

            //if (string.IsNullOrEmpty(make))
            //    Label1.Text = "Please select a make.";
            //else if (string.IsNullOrEmpty(model))
            //    Label1.Text = "Please select a model.";
           
            //else
            //    Label1.Text = string.Format("您已经选择了一个{0} {1} .Nice car!",  make, model);
        }

        [WebMethod]

        [System.Web.Script.Services.ScriptMethod]

        public static CascadingDropDownNameValue[] GetDropDownContentsPageMethod(string knownCategoryValues, string category)

        {
            return new CarsService().GetDropDownContents(knownCategoryValues, category);

        }


    }
}
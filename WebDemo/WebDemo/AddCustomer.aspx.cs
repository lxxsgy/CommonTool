using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Room newroom = getRoomPage();
            DataClassesRoomDataContext dataContent = new DataClassesRoomDataContext();
            dataContent.Room.InsertOnSubmit(newroom);
            dataContent.SubmitChanges();
            this.LabelMessage.Text = "添加完成";
            Response.Redirect("ListCustom.aspx");


        }

        private Room getRoomPage()
        {
            return new Room
            {
                Number = this.txtNumber.Text,
                Class = this.ddlRoomClass.Text,
                Status = this.ddlStatus.Text,
                Price = this.TxtPrice.Text,
                
                

            };
        }

    }
}
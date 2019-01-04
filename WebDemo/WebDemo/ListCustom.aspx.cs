using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class ListCustom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           DataClassesRoomDataContext newdata = new DataClassesRoomDataContext();
            //var rooms = from r in newdata.his_tblData1  select r;
            //this.GridcustomInfo.DataSource = rooms;
            //this.GridcustomInfo.DataBind();
            //this.Repeater1.DataSource = bindBlog();
            //this.Repeater1.DataBind();
            //this.DataList1.DataSource = bindBlog();
            //this.DataList1.DataBind();
            //this.DetailsView1.DataSource = bindBlog();
            //this.DetailsView1.DataBind();
            //DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
          //  var rooms = from r in newdata.his_tblData1 select r;
            this.FormView1.DataSource = bindBlog() ;
            this.FormView1.DataBind();
        }
        
        private List<Blog> bindBlog()
        {
            List<Blog> blogList = new List<Blog>();
            blogList.Add(new Blog {
                Title = "asp",
                Content = @"asp是微软公司发布的一种面向对象的、运行于.NET Framework之上的高级程序设计语言。并定于在微软职业开发者论坛(PDC)上登台亮相。C#是微软公司研究员Anders Hejlsberg的最新成果。C#看起来与Java有着惊人的相似；它包括了诸如单一继承、接口、与Java几乎同样的语法和编译成中间代码再运行的过程。但是C#与Java有着明显的不同，它借鉴了Delphi的一个特点，与COM（组件对象模型）是直接集成的，而且它是微软公司 .NET windows网络框架的主角。
C#是一种安全的、稳定的、简单的、优雅的，由C和C++衍生出来的面向对象的编程语言。它在继承C和C++强大功能的同时去掉了一些它们的复杂特性（例如没有宏以及不允许多重继承）。C#综合了VB简单的可视化操作和C++的高运行效率，以其强大的操作能力、优雅的语法风格、创新的语言特性和便捷的面向组件编程的支持成为.NET开发的首选语言。 [1] 
C#是面向对象的编程语言。它使得程序员可以快速地编写各种基于MICROSOFT .NET平台的应用程序，MICROSOFT .NET提供了一系列的工具和服务来最大程度地开发利用计算与通讯领域。
C#使得C++程序员可以高效的开发程序",
                PublishTime = "2018-08-11 10:23"
            });
            blogList.Add(new Blog
            {
                Title = "c#",
                Content = @"C#是微软公司发布的一种面向对象的、运行于.NET Framework之上的高级程序设计语言。并定于在微软职业开发者论坛(PDC)上登台亮相。C#是微软公司研究员Anders Hejlsberg的最新成果。C#看起来与Java有着惊人的相似；它包括了诸如单一继承、接口、与Java几乎同样的语法和编译成中间代码再运行的过程。但是C#与Java有着明显的不同，它借鉴了Delphi的一个特点，与COM（组件对象模型）是直接集成的，而且它是微软公司 .NET windows网络框架的主角。
C#是一种安全的、稳定的、简单的、优雅的，由C和C++衍生出来的面向对象的编程语言。它在继承C和C++强大功能的同时去掉了一些它们的复杂特性（例如没有宏以及不允许多重继承）。C#综合了VB简单的可视化操作和C++的高运行效率，以其强大的操作能力、优雅的语法风格、创新的语言特性和便捷的面向组件编程的支持成为.NET开发的首选语言。 [1] 
C#是面向对象的编程语言。它使得程序员可以快速地编写各种基于MICROSOFT .NET平台的应用程序，MICROSOFT .NET提供了一系列的工具和服务来最大程度地开发利用计算与通讯领域。
C#使得C++程序员可以高效的开发程序，且因可调用由 C/C++ 编写的本机原生函数，因此绝不损失C/C++原有的强大的功能。因为这种继承关系，C#与C/C++具有极大的相似性，熟悉类似语言的开发者可以很快的转向C#。",
                PublishTime = "2018-08-11 10:23"
            });
            blogList.Add(new Blog
            {
                Title = "javascript",
                Content = @"JavaScript一种直译式脚本语言，是一种动态类型、弱类型、基于原型的语言，内置支持类型。它的解释器被称为JavaScript引擎，为浏览器的一部分，广泛用于客户端的脚本语言，最早是在HTML（标准通用标记语言下的一个应用）网页上使用，用来给HTML网页增加动态功能。
在1995年时，由Netscape公司的Brendan Eich，在网景导航者浏览器上首次设计实现而成。因为Netscape与Sun合作，Netscape管理层希望它外观看起来像Java，因此取名为JavaScript。但实际上它的语法风格与Self及Scheme较为接近。 [1]
为了取得技术优势，微软推出了JScript，CEnvi推出ScriptEase，与JavaScript同样可在浏览器上运行。为了统一规格，因为JavaScript兼容于ECMA标准，因此也称为ECMAScript",
                PublishTime = "2018-08-11 10:23"
            });
            blogList.Add(new Blog
            {
                Title = "java",
                Content = @"JavaScript一种直译式脚本语言，是一种动态类型、弱类型、基于原型的语言，内置支持类型。它的解释器被称为JavaScript引擎，为浏览器的一部分，广泛用于客户端的脚本语言，最早是在HTML（标准通用标记语言下的一个应用）网页上使用，用来给HTML网页增加动态功能。
在1995年时，由Netscape公司的Brendan Eich，在网景导航者浏览器上首次设计实现而成。因为Netscape与Sun合作，Netscape管理层希望它外观看起来像Java，因此取名为JavaScript。但实际上它的语法风格与Self及Scheme较为接近。 [1]
为了取得技术优势，微软推出了JScript，CEnvi推出ScriptEase，与JavaScript同样可在浏览器上运行。为了统一规格，因为JavaScript兼容于ECMA标准，因此也称为ECMAScript",
                PublishTime = "2018-08-11 10:23"
            });

            return blogList;

        }

      

        protected void GridcustomInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var grid = (GridView)sender;
            grid.PageIndex = e.NewPageIndex;
        }

        protected void GridcustomInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
           var grid= (GridView)sender;
            grid.EditIndex = e.NewEditIndex;
            grid.DataKeyNames = new string[] { "RecordID" };
            grid.DataBind();
        }

        protected void GridcustomInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void GridcustomInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridcustomInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var grid = (GridView)sender;
            grid.DataKeyNames = new string[] { "RecordID" };
           
        }

        protected void GridcustomInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            var grid = (GridView)sender;
            grid.DataKeyNames = new string[] { "RecordID" };
            grid.EditIndex = -1;
            grid.DataBind();

        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
          // this.DetailsView1.DefaultMode = DetailsViewMode.Insert;
        }

        protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            
            FormView1.ChangeMode(FormViewMode.Edit);
           // this.FormView1.DataSource = bindBlog();
            this.FormView1.DataBind();
        }
    }
    public class Blog
    {
         public string Title { get; set; }
        public string Content { get; set; }
        public string PublishTime { get; set; }
    }
}
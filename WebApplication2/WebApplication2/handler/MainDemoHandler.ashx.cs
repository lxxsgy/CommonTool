using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Test.BLL;
using Test.Model;

namespace WebApplication2.handler
{
    /// <summary>
    /// MainDemoHandler 的摘要说明
    /// </summary>
    public class MainDemoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var method = context.Request["methods"];
            if(method=="search")
            {
                var page = context.Request["page"];
                var data = context.Request["data"];
                var rows = context.Request["rows"];
                var sort = context.Request["sort"];
                var order = context.Request["order"];
                var projectId = context.Request["projectId"];
                var pname = context.Request["pname"];
                var packageid = context.Request["packageId"];


                TabPackInfoBLL tabPack = new TabPackInfoBLL();
                Pager<TabPackageInfo> pager = new Pager<TabPackageInfo>();
                pager.Where = new TabPackageInfo();
                pager.Sort = sort;
                pager.Order = order;
                if (packageid != null)
                {
                    pager.Where.PackageId = packageid;
                }
                if (pname != null)
                {
                    pager.Where.Pname = pname;
                }
                if (projectId != null)
                {
                    pager.Where.ProjectId = projectId;
                }



                pager.Order = order;
                pager.PageIndex = page == null ? 1 : Convert.ToInt32(page);
                pager.PageCount = rows == null ? 20 : Convert.ToInt32(rows);

                pager = tabPack.GetPackageInfo(pager);


                string json = "{\"total\":" + pager.RecordTotal + ",\"rows\":";
                json += JsonConvert.SerializeObject(pager.DataTableSource) + "}";
                context.Response.Write(json);
            }

            if(method=="add")
            {
                var projectId = context.Request["projectId"];
                var pname = context.Request["pname"];
                var packageid = context.Request["packageId"];
                TabPackInfoBLL tabPack = new TabPackInfoBLL();
                Pager<TabPackageInfo> pager = new Pager<TabPackageInfo>();
                pager.Where = new TabPackageInfo();
                pager.Where.PackageId = packageid;
                pager.Where.ProjectId = projectId;
                pager.Where.Pname = pname;
               int res= tabPack.InsertPackageInfo(pager);
                context.Response.Write(res);


            }
            if (method == "update")
            {
                var projectId = context.Request["projectId"];
                var pname = context.Request["pname"];
                var packageid = context.Request["packageId"];
                var mainid = context.Request["mainid"];
                TabPackInfoBLL tabPack = new TabPackInfoBLL();
                Pager<TabPackageInfo> pager = new Pager<TabPackageInfo>();
                pager.Where = new TabPackageInfo();
                pager.Where.PackageId = packageid;
                pager.Where.ProjectId = projectId;
                pager.Where.mainid = mainid;
                pager.Where.Pname = pname;
                int res = tabPack.UpdatePackageInfo(pager);
                context.Response.Write(res);

            }
            if (method == "remove")
            {
                TabPackInfoBLL tabPack = new TabPackInfoBLL();
                var mainid = context.Request["mainid"];
                int res = tabPack.deletePackageInfo(mainid);
                context.Response.Write(res);
            }


            }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class PageInfo
    {
        public int totals { get; set; }
        public int rows { get; set; }
        public DataTable data { get; set; }
    }
}
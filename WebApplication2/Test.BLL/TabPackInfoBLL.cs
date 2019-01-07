using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL;
using Test.Model;

namespace Test.BLL
{
    public class TabPackInfoBLL
    {
        SqlServerHelper sqlOpterator = new SqlServerHelper();

        

        public Pager<TabPackageInfo> GetPackageInfo(Pager<TabPackageInfo> pager)
        {

            string whereString = "";
            string orderString = "";
            if(pager.Sort!=null && pager.Sort != "")
            {
                orderString = " Order by " + pager.Sort;
            }
            if(orderString!="")
            {
                if (pager.Order != null && pager.Order != "")
                {
                    orderString += " " + pager.Order;
                }
            }
            if(pager.Where.PackageId!=null&&pager.Where.PackageId!="")
            {
                whereString = " Packageid= '" + pager.Where.PackageId + "' AND ";
            }
            if (pager.Where.Pname != null && pager.Where.Pname != "")
            {
                whereString += " Pname= '" + pager.Where.Pname + "' AND ";
            }
            if (pager.Where.ProjectId != null && pager.Where.ProjectId != "")
            {
                whereString += " ProjectId= '" + pager.Where.ProjectId + "' AND ";
            }
            if (whereString != "")
            {
                whereString = whereString.Substring(0, whereString.Length - 4);
            }
            if (whereString!="")
            {
                string sql = "select top " + pager.PageCount + " mainid,Pname,PackageId,ProjectId  from tabpackageInfo where "+whereString +" AND mainID not in (select top " + pager.PageCount * (pager.PageIndex - 1) + " mainID from tabpackageInfo  Where "+whereString +" "+ orderString+") "+orderString;
                pager.DataTableSource = SqlServerHelper.QueryTable(sql);
                pager.RecordTotal = GetPackageInfoTotal(whereString);
            }
            else
            {
                string sql = "select top " + pager.PageCount + "mainid,Pname,PackageId,ProjectId  from tabpackageInfo where mainID not in (select top " + pager.PageCount * (pager.PageIndex - 1) + " mainID from tabpackageInfo "+orderString+")  "+ orderString;
                pager.DataTableSource = SqlServerHelper.QueryTable(sql);
                pager.RecordTotal = GetPackageInfoTotal("");
            }
           
            return pager;

        }

        private int GetPackageInfoTotal(string whereSql)
        {
            int count = 0;
            string sql = "select count(*) from tabpackageInfo"+(whereSql==""?"":" where "+ whereSql);
            count = Convert.ToInt32( SqlServerHelper.ExecuteScalar(sql));
            return count;
        }

        public int InsertPackageInfo(Pager<TabPackageInfo> pager)
        {
            int res = 0;
            try
            {
                string sql = "insert into  tabpackageInfo (Pname,PackageId,ProjectId) values('{0}','{1}','{2}')";
                sql = string.Format(sql,pager.Where.Pname,pager.Where.PackageId,pager.Where.ProjectId);
                res =SqlServerHelper.ExecuteNonQuery(sql);
            }
            catch(Exception ex)
            {
                res = -1;
            }

            return res;
        }
        public int UpdatePackageInfo(Pager<TabPackageInfo> pager)
        {
            int res = 0;
            try
            {
                string sql = "update  tabpackageInfo set Pname='{0}',PackageId='{1}',ProjectId='{2}' where mainid='{3}'";
                sql = string.Format(sql, pager.Where.Pname, pager.Where.PackageId, pager.Where.ProjectId, pager.Where.mainid);
                res = SqlServerHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                res = -1;
            }
            return res;
        }

        public int deletePackageInfo(string mainid)
        {
            int res = 0;
            try
            {
                string sql = "delete from tabpackageInfo where mainid in ({0})";
                sql = string.Format(sql,mainid);
                res = SqlServerHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                res = -1;
            }
            return res;
        }
    }
  
}

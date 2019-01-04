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
            if(whereString!="")
            {
                whereString = " Where " + whereString.Substring(0, whereString.Length-4);
            }
            string sql = "select top "+pager.PageCount+" Pname,PackageId,ProjectId  from tabpackageInfo where mainID not in (select top "+ pager.PageSize *(pager.PageIndex-1)+ " mainID from tabpackageInfo order by mainID) order by mainID ";
            pager.DataTableSource= SqlServerHelper.QueryTable(sql);
           pager.RecordTotal= GetPackageInfoTotal();
            return pager;

        }

        private int GetPackageInfoTotal()
        {
            int count = 0;
            string sql = "select count(*) from tabpackageInfo";
            count = Convert.ToInt32( SqlServerHelper.ExecuteScalar(sql));
            return count;
        }
    }
}

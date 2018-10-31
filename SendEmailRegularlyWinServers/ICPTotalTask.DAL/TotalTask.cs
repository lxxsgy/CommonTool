using ICPSendMailRegularly.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPTotalTask.DAL
{
    public class TotalTaskDAL
    {
        public List<TotalTaskModel> GetList(string CustomerCode, string StartTime, string EndTime, string PacketNo, string swiftNumber)
        {
            List<TotalTaskModel> list = new List<TotalTaskModel>();

            #region 获取前置机Task表中相关环节任务总量监控
            DataTable taskDataTable = GetNonCompletedTaskCountList(CustomerCode, StartTime, EndTime, PacketNo);
            GetNonCompletedTaskModelList(ref list, taskDataTable, true);
            #endregion

            if (string.IsNullOrEmpty(PacketNo) || !string.IsNullOrEmpty(swiftNumber))
            {
                #region 获取集中作业 EntryTaskAuto表中任务总量监控
                DataTable entryTaskAutoDt = GetNonCompletedETAutoCountList(CustomerCode, StartTime, EndTime, PacketNo, swiftNumber);
                GetNonCompletedTaskModelList(ref list, entryTaskAutoDt);
                #endregion

                #region 获取集中作业EntryTask表中任务总量监控
                DataTable entryTaskDt = GetNonCompletedETCountList(CustomerCode, StartTime, EndTime, PacketNo, swiftNumber);
                GetNonCompletedTaskModelList(ref list, entryTaskDt);
                #endregion

                #region 获取集中作业ProductProject表中任务总量监控
                DataTable productPDt = GetNonCompletedPPCountList(CustomerCode, StartTime, EndTime, PacketNo, swiftNumber);
                GetNonCompletedTaskModelList(ref list, productPDt);
                #endregion
            }

            #region 获取前置机BusinessForm 表中相关环节任务总量监控
            DataTable businessFormData = GetNonCompletedBusinessFormCountList(CustomerCode, StartTime, EndTime, PacketNo);
            GetNonCompletedTaskModelList(ref list, businessFormData);
            #endregion

            return list;
        }
        /// <summary>
        /// 组合界面实体
        /// </summary>
        /// <param name="totalTaskModels"></param>
        /// <param name="dt"></param>
        private void GetNonCompletedTaskModelList(ref List<TotalTaskModel> totalTaskModels, DataTable dt, bool IsTaskTable = false)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string CustomerCode = dr["CustomerCode"].ToString();
                    string CustomerName = dr["CustomerName"].ToString();
                    string LinkName = dr["ActivityName"].ToString();
                    int PendingQuantity = int.Parse(dr["New"].ToString());
                    int Exception = int.Parse(dr["Exception"].ToString());
                    int ProcessingQuantity = int.Parse(dr["AutoDoing"].ToString());
                    int CompleteNormalQuantity = int.Parse(dr["CompleteNormal"].ToString());
                    int CompleteExceptionQuantity = int.Parse(dr["CompleteException"].ToString());
                    int SumQuantity = int.Parse(dr["SumQuantity"].ToString());
                    if (IsTaskTable && CompleteNormalQuantity == 0 && CompleteExceptionQuantity != 0)
                    {
                        CompleteNormalQuantity = CompleteExceptionQuantity;
                        CompleteExceptionQuantity = 0;
                    }
                    TotalTaskModel totalTaskModel = new TotalTaskModel();
                    totalTaskModel.ID = Guid.NewGuid();
                    totalTaskModel.CustomerCode = CustomerCode;
                    totalTaskModel.CustomerName = CustomerName;
                    totalTaskModel.LinkName = LinkName;
                    totalTaskModel.PendingQuantity = PendingQuantity;
                    totalTaskModel.Exception = Exception;
                    totalTaskModel.ProcessingQuantity = ProcessingQuantity;
                    totalTaskModel.CompleteNormalQuantity = CompleteNormalQuantity;
                    totalTaskModel.CompleteExceptionQuantity = CompleteExceptionQuantity;
                    totalTaskModel.SumQuantity = SumQuantity;
                    totalTaskModels.Add(totalTaskModel);
                }
            }
        }


        /// <summary>
        /// 获取前置机Task表中相关环节任务总量监控
        /// </summary>
        /// <param name="customerCode">客户Code</param>
        /// <returns></returns>
        private DataTable GetNonCompletedTaskCountList(string customerCode, string StartTime, string EndTime, string PacketNo)
        {
            string strSql = @"
SELECT t7.*,t8.OrderNumber FROM(
 
SELECT
  t6.CustomerCode,
  t6.CustomerName,
  t6.ActivityCode,
  t6.ActivityName,
  MAX(CASE Status WHEN 'New'THEN IsNormalCount ELSE 0 END ) New,
  MAX(CASE Status WHEN 'Exception' THEN IsNormalCount ELSE 0 END ) Exception,
  MAX(CASE Status WHEN 'AutoDoing' THEN IsNormalCount ELSE 0 END ) AutoDoing,
  MAX(CASE Status WHEN 'CompleteNormal' THEN IsNormalCount ELSE 0 END ) CompleteNormal,
  MAX(CASE Status WHEN 'CompleteException' THEN IsNormalCount ELSE 0 END ) CompleteException,
  MAX(CASE Status WHEN 'New' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Exception' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'AutoDoing' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'CompleteNormal' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'CompleteException' THEN IsNormalCount ELSE 0 END ) AS SumQuantity
 FROM(

SELECT
  t5.CustomerCode,
  t5.CustomerName,
  t5.ActivityCode,
  t5.ActivityName,
  (
    CASE WHEN t5.IsNormal = 1 AND t5.Status = 'Complete' THEN 'CompleteNormal'
         WHEN t5.IsNormal = 0 AND t5.Status = 'Complete' THEN 'CompleteException'
         WHEN t5.Status = 'ManualMarkup' THEN 'New'
         WHEN t5.Status = 'ManualMarkupDoing' THEN 'AutoDoing'
         WHEN t5.Status = 'ManualMarkupException' THEN 'Exception'
         WHEN t5.Status = 'MarkupException' THEN 'Exception'
         WHEN t5.Status = 'LookupException' THEN 'Exception'
    ELSE Status END  
  ) AS Status,
  t5.IsNormalCount
 FROM(

SELECT t4.CustomerCode,t4.CustomerName,t4.ActivityCode,t4.ActivityName,t4.Status,COUNT(t4.Status) AS StatusCount,t4.IsNormal,COUNT(t4.IsNormal) AS IsNormalCount FROM (
SELECT
	t1.ID,
	t1.CustomerCode,
	t3.CustomerName,
  t2.Code AS ActivityCode,
	t2.Name AS ActivityName,
	t1.Status,
	(CASE t1.IsNormal WHEN 0 THEN 0 ELSE 1 END ) AS IsNormal
FROM
	`task` AS t1
INNER JOIN `activitytype` AS t2 ON t1.ActivityType = t2.ID
INNER JOIN
(
	SELECT CustomerCode,CustomerName FROM `businesstemplate` GROUP BY CustomerCode
) AS t3 ON t1.CustomerCode = t3.CustomerCode
WHERE
	1=1
";
            if (!string.IsNullOrEmpty(customerCode))
            {
                strSql += "AND t1.CustomerCode = '" + customerCode + "' ";
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql += "AND t1.CreateTime >= '" + StartTime + "' ";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql += "AND t1.CreateTime <= '" + EndTime + "' ";
            }
            if (!string.IsNullOrEmpty(PacketNo))
            {
                strSql += "AND t1.BatchCode = '" + PacketNo + "' ";
            }
            strSql += @"
) AS t4
GROUP BY t4.CustomerName,t4.ActivityName,t4.Status,t4.IsNormal

) AS t5

) AS t6
GROUP BY t6.CustomerName,t6.ActivityName

) AS t7
INNER JOIN  `activitytypecategory` AS t8 ON t8.Code = t7.ActivityCode ORDER BY t8.OrderNumber          
            ";
            DataTable resultTable = MySqlHelper.ExecuteDataTable(strSql);
            return resultTable;
        }
        /// <summary>
        ///  获取前置机BusinessForm 表中相关环节任务总量监控
        /// </summary>
        /// <param name="customerCode">客户Code</param>
        /// <returns></returns>
        private DataTable GetNonCompletedBusinessFormCountList(string customerCode, string StartTime, string EndTime, string PacketNo)
        {
            string strSql = @"

SELECT
  t6.CustomerCode,
  t6.CustomerName,
  t6.ActivityName,
  MAX(CASE Status WHEN 'New'THEN IsNormalCount ELSE 0 END ) New,
  MAX(CASE Status WHEN 'Exception' THEN IsNormalCount ELSE 0 END ) Exception,
  MAX(CASE Status WHEN 'AutoDoing' THEN IsNormalCount ELSE 0 END ) AutoDoing,
  MAX(CASE Status WHEN 'CompleteNormal' THEN IsNormalCount ELSE 0 END ) CompleteNormal,
  MAX(CASE Status WHEN 'CompleteException' THEN IsNormalCount ELSE 0 END ) CompleteException,
  MAX(CASE Status WHEN 'New' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Exception' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'AutoDoing' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'CompleteNormal' THEN IsNormalCount ELSE 0 END )+
  MAX(CASE Status WHEN 'CompleteException' THEN IsNormalCount ELSE 0 END ) AS SumQuantity
 FROM(

SELECT
  t5.CustomerCode,
	t5.CustomerName,
	t5.ActivityName,
  (
    CASE WHEN t5.IsNormal = 1 AND t5.Status = 'Complete' THEN 'CompleteNormal'
         WHEN t5.IsNormal = 0 AND t5.Status = 'Complete' THEN 'CompleteException'
         WHEN t5.IsNormal = 0 AND t5.Status <> 'Complete' THEN 'Exception'
    ELSE Status END  
  ) AS Status,
  t5.IsNormalCount
 FROM(

SELECT t4.CustomerCode,t4.CustomerName,t4.ActivityName,t4.Status,COUNT(t4.Status) AS StatusCount,t4.IsNormal,COUNT(t4.IsNormal) AS IsNormalCount FROM (
SELECT
	t1.ID,
	t1.CustomerCode,
	t3.CustomerName,
  (
    CASE WHEN t1.Status = 'Exception' OR t1.Status = 'ExceptionDoing' THEN '整单'
         WHEN t1.Status = 'New' OR t1.Status = 'AutoDoing' THEN 'Validate'
         WHEN t1.Status = 'ManualValidate' OR t1.Status = 'ManualValidateDoing' THEN '人工Validate'
         WHEN t1.Status = 'Export' OR t1.Status = 'Exporting' THEN '导出'
    ELSE Status END  
  ) AS ActivityName,
  (
    CASE WHEN t1.Status = 'Exception' OR t1.Status = 'ManualValidate' OR t1.Status = 'Export' THEN 'New'
         WHEN t1.Status = 'ExceptionDoing' OR t1.Status = 'ManualValidateDoing' OR t1.Status = 'Exporting' THEN 'AutoDoing'
         WHEN t1.Status = 'Exported' THEN 'Complete'
    ELSE Status END  
  ) AS Status,
	(CASE t1.IsNormal WHEN 0 THEN 0 ELSE 1 END ) AS IsNormal
FROM
	`businessform` AS t1
INNER JOIN
(
	SELECT CustomerCode,CustomerName FROM `businesstemplate` GROUP BY CustomerCode
) AS t3 ON t1.CustomerCode = t3.CustomerCode
WHERE
	1=1
";
            if (!string.IsNullOrEmpty(customerCode))
            {
                strSql += "AND t1.CustomerCode = '" + customerCode + "' ";
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql += "AND t1.CreateTime >= '" + StartTime + "' ";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql += "AND t1.CreateTime <= '" + EndTime + "' ";
            }
            if (!string.IsNullOrEmpty(PacketNo))
            {
                strSql += "AND t1.BatchCode = '" + PacketNo + "' ";
            }
            strSql += @"
) AS t4
GROUP BY t4.CustomerName,t4.ActivityName,t4.Status,t4.IsNormal

) AS t5

) AS t6
GROUP BY t6.CustomerName,t6.ActivityName          
            ";
            DataTable resultTable = MySqlHelper.ExecuteDataTable(strSql);
            return resultTable;
        }
        /// <summary>
        /// 获取集中作业EntryTaskAuto表中任务总量监控
        /// </summary>
        /// <param name="customerCode">客户Code</param>
        /// <returns></returns>
        private DataTable GetNonCompletedETAutoCountList(string customerCode, string StartTime, string EndTime, string PacketNo, string swiftNumber)
        {
            string strSql = @"
SELECT 
  t5.CustomerNumber AS CustomerCode,
  t5.CustomerName,
  N'自动OCR' AS ActivityName,
  MAX(CASE Status WHEN 'New' THEN StatusCount ELSE 0 END ) New,
  0 AS 'Exception',
  MAX(CASE Status WHEN 'AutoDoing' THEN StatusCount ELSE 0 END ) AutoDoing,
  MAX(CASE Status WHEN 'Completed' THEN StatusCount ELSE 0 END ) CompleteNormal,
  0 AS 'CompleteException',
  MAX(CASE Status WHEN 'New'THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'AutoDoing' THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Completed' THEN StatusCount ELSE 0 END ) AS SumQuantity
 FROM (

SELECT t4.CustomerNumber,t4.CustomerName,t4.Status,COUNT(t4.Status) AS StatusCount FROM(
SELECT
	t1.ID,
	t1.CustomerID,
	t3.CustomerNumber,
	t3.CustomerName,
	t1.Status
FROM
	[dbo].[EntryTaskAuto] AS t1
INNER JOIN [dbo].[ProductCaseForm] AS t2 ON t2.ID = t1.CaseFormID
INNER JOIN [dbo].[CustomerInfo] AS t3 ON t3.ID = t1.CustomerID
WHERE
	1=1
";
            if (!string.IsNullOrEmpty(customerCode))
            {
                strSql += "AND t3.CustomerNumber = '" + customerCode + "' ";
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql += "AND t1.CreateTime >= '" + StartTime + "' ";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql += "AND t1.CreateTime <= '" + EndTime + "' ";
            }
            if (!string.IsNullOrEmpty(swiftNumber))
            {
                strSql += "AND t2.ProductProjectID = '" + swiftNumber + "' ";
            }
            strSql += @"
) AS t4 GROUP BY t4.CustomerNumber,t4.CustomerName,t4.Status

) AS t5
GROUP BY t5.CustomerNumber,t5.CustomerName   
";
            DataTable resultTable = SqlServerHelper.QueryTable(strSql);
            return resultTable;
        }
        /// <summary>
        /// 获取集中作业EntryTask表中任务总量监控
        /// </summary>
        /// <param name="customerCode">客户Code</param>
        /// <returns></returns>
        private DataTable GetNonCompletedETCountList(string customerCode, string StartTime, string EndTime, string PacketNo, string swiftNumber)
        {
            string strSql = @"
SELECT 
  t5.CustomerNumber AS CustomerCode,
  t5.CustomerName,
  N'人工录入' AS ActivityName,
  MAX(CASE Status WHEN 'Manual' THEN StatusCount ELSE 0 END ) New,
  0 AS 'Exception',
  MAX(CASE Status WHEN 'ManualDoing' THEN StatusCount ELSE 0 END ) AutoDoing,
  MAX(CASE Status WHEN 'Completed' THEN StatusCount ELSE 0 END ) CompleteNormal,
  0 AS 'CompleteException',
  MAX(CASE Status WHEN 'Manual'THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'ManualDoing' THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Completed' THEN StatusCount ELSE 0 END ) AS SumQuantity
 FROM (

SELECT t4.CustomerNumber,t4.CustomerName,t4.Status,COUNT(t4.Status) AS StatusCount FROM(
SELECT
	t1.ID,
	t1.CustomerID,
	t3.CustomerNumber,
	t3.CustomerName,
	t1.Status
FROM
	[dbo].[EntryTask] AS t1
left JOIN [dbo].[ProductCaseForm] AS t2 ON t2.ID = t1.CaseFormID
left JOIN [dbo].[CustomerInfo] AS t3 ON t3.ID = t1.CustomerID

";
            if (!string.IsNullOrEmpty(customerCode))
            {
                strSql += "AND t3.CustomerNumber = '" + customerCode + "' ";
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql += "AND t1.CreateTime >= '" + StartTime + "' ";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql += "AND t1.CreateTime <= '" + EndTime + "' ";
            }
            if (!string.IsNullOrEmpty(swiftNumber))
            {
                strSql += "AND t2.ProductProjectID = '" + swiftNumber + "' ";
            }
            strSql += @"
) AS t4 GROUP BY t4.CustomerNumber,t4.CustomerName,t4.Status

) AS t5
GROUP BY t5.CustomerNumber,t5.CustomerName   
";
            DataTable resultTable = SqlServerHelper.QueryTable(strSql);
            return resultTable;
        }
        /// <summary>
        /// 获取集中作业ProductProject表中任务总量监控
        /// </summary>
        /// <param name="customerCode">客户Code</param>
        /// <returns></returns>
        private DataTable GetNonCompletedPPCountList(string customerCode, string StartTime, string EndTime, string PacketNo, string swiftNumber)
        {
            string strSql = @"
SELECT 
  t5.CustomerNumber AS CustomerCode,
  t5.CustomerName,
  N'回传' AS ActivityName,
  MAX(CASE Status WHEN 'New' THEN StatusCount ELSE 0 END ) New,
  0 AS 'Exception',
  MAX(CASE Status WHEN 'Doing' THEN StatusCount ELSE 0 END ) AutoDoing,
  MAX(CASE Status WHEN 'Complete' THEN StatusCount ELSE 0 END ) CompleteNormal,
  0 AS 'CompleteException',
  MAX(CASE Status WHEN 'New'THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Doing' THEN StatusCount ELSE 0 END )+
  MAX(CASE Status WHEN 'Complete' THEN StatusCount ELSE 0 END ) AS SumQuantity
 FROM (

SELECT t4.CustomerNumber,t4.CustomerName,t4.Status,COUNT(t4.Status) AS StatusCount FROM(
SELECT
	t2.CustomerID,
	t3.CustomerNumber,
	t3.CustomerName,
	t1.Status
FROM
	[dbo].[ProductProject] AS t1
INNER JOIN [dbo].[ProjectInfo] AS t2 ON t2.ID = t1.ProjectID
INNER JOIN [dbo].[CustomerInfo] AS t3 ON t3.ID = t2.CustomerID
WHERE
	1=1
";
            if (!string.IsNullOrEmpty(customerCode))
            {
                strSql += "AND t3.CustomerNumber = '" + customerCode + "' ";
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql += "AND t1.CreateTime >= '" + StartTime + "' ";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql += "AND t1.CreateTime <= '" + EndTime + "' ";
            }
            if (!string.IsNullOrEmpty(swiftNumber))
            {
                strSql += "AND t1.ProductProjectID = '" + swiftNumber + "' ";
            }
            strSql += @"
) AS t4 GROUP BY t4.CustomerNumber,t4.CustomerName,t4.Status

) AS t5
GROUP BY t5.CustomerNumber,t5.CustomerName   
";
            DataTable resultTable = SqlServerHelper.QueryTable(strSql);
            return resultTable;
        }
        /// <summary>
        /// 查询SwiftNumber
        /// </summary>
        /// <param name="PacketNo"></param>
        /// <returns></returns>
        public DataTable GetSwiftNumberByPacketNo(string PacketNo)
        {
            string strSql = @"
SELECT
	SwiftNumber
FROM
	`task` AS t1
INNER JOIN `activitytype` AS t2 ON t1.ActivityType = t2.ID
WHERE
	t2.Name = '切片' AND t1.BatchCode = '" + PacketNo + @"'
";
            DataTable resultTable = MySqlHelper.ExecuteDataTable(strSql);
            return resultTable;
        }

    }
    public class TotalTaskModel
    {
        public Guid? ID
        {
            get;
            set;
        }
        /// <summary>
        /// 客户名称ID
        /// </summary>
        public string CustomerCode
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        /// <summary>
        /// 环节名称
        /// </summary>
        public string LinkName
        {
            get;
            set;
        }
        /// <summary>
        /// 待处理量(单)
        /// </summary>
        public int PendingQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 问题件量(单)
        /// </summary>
        public int Exception
        {
            get;
            set;
        }
        /// <summary>
        /// 正在处理量(单)
        /// </summary>
        public int ProcessingQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 已完成正常量
        /// </summary>
        public int CompleteNormalQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 已完问题件量
        /// </summary>
        public int CompleteExceptionQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 总量
        /// </summary>
        public int SumQuantity
        {
            get;
            set;
        }
    }
}

using System;
using System.ServiceProcess;
using log4net;
using System.Configuration;
using System.Timers;
using ICPSendMailRegularly.BLL;
using ICPTotalTask.DAL;
using System.Collections.Generic;
using System.Data;

namespace SendEmailRegularlyWinServers
{
    public partial class SendMailSRegularService : ServiceBase
    {
        #region 字段
        private ILog log = null;
        System.Timers.Timer time = new System.Timers.Timer();
        private static DataTable orbitDT = null;
        /// <summary>
        /// 服务运行时长
        /// </summary>
        private int timeInterval = 0;
        /// <summary>
        /// 服务开始运行时间
        /// </summary>
        private int beginHour = 6; 
        /// 服务结束运营时间
        /// </summary>
        private int endHour = 20;

        
        #endregion
        public SendMailSRegularService()
        {
             log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            InitializeComponent();
            timeInterval = ConfigurationManager.AppSettings["timeInterval"].ToString().Trim() == "" ? 0 : Convert.ToInt32(ConfigurationManager.AppSettings["timeInterval"].ToString().Trim());
            int.TryParse(ConfigurationManager.AppSettings["StartHour"].ToString().Trim(), out beginHour);
            int.TryParse(ConfigurationManager.AppSettings["EndHour"].ToString().Trim(), out endHour);
        }

        protected override void OnStart(string[] args)
        {
            log.Debug("服务开始运行");
            InitialTimer();
        }

        private void InitialTimer()
        {
            time.Interval = timeInterval*60*1000;
            time.Elapsed += new System.Timers.ElapsedEventHandler(DoWork);
            time.Enabled = true;
            time.AutoReset = true;
            DoWork(null,null);

        }

      
         /// <summary>
        /// 导出全流程任务总量监控
        /// </summary>
        private void InitOrbitDT()
        {
            if (orbitDT == null)
            {
                orbitDT = new DataTable();
                orbitDT.Columns.Add("客户名称", typeof(string));
                orbitDT.Columns.Add("环节名称", typeof(string));
                orbitDT.Columns.Add("待处理量(单)", typeof(int));
                orbitDT.Columns.Add("正在处理量(单)", typeof(int));
                orbitDT.Columns.Add("问题件量(单)", typeof(int));
                orbitDT.Columns.Add("已完成正常量", typeof(int));
                orbitDT.Columns.Add("已完成问题件量", typeof(int));
                orbitDT.Columns.Add("总量", typeof(int));
            }
        }
        private void BuildingDataTable(List<TotalTaskModel> list)
        {
            InitOrbitDT();
            foreach (var item in list)
            {
                DataRow dr = orbitDT.NewRow();
                dr[0] = item.CustomerName;
                dr[1] = item.LinkName;
                dr[2] = item.PendingQuantity;
                dr[3] = item.ProcessingQuantity;
                dr[4] = item.Exception;
                dr[5] = item.CompleteNormalQuantity;
                dr[6] = item.CompleteExceptionQuantity;
                dr[7] = item.SumQuantity;
                orbitDT.Rows.Add(dr);
            }
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            time.Stop();
            log.Debug("发送邮件");
            for(int i = 0;i< 3;i++)
            {
                if(GetDataAndSendEmail())
                {
                    log.Debug("发送成功");
                    break;
                }
                System.Threading.Thread.Sleep(3000);
            }
            time.Enabled=true;
        }
        public bool GetDataAndSendEmail()
        {
            bool result = true;
            try
            {
                if (DateTime.Now.Hour >= beginHour && DateTime.Now.Hour < endHour)
                {
                    List<TotalTaskModel> list = new List<TotalTaskModel>();
                    TotalTaskDAL toalTaskDal = new TotalTaskDAL();
                    list = toalTaskDal.GetList("", "", "", "", "");
                    if (list != null)
                    {
                        BuildingDataTable(list);
                    }
                    if (orbitDT != null)
                    {
                        string MailBody = "<p style=\"font-size: 10pt\">以下内容为系统自动发送，请勿直接回复，谢谢。</p><table cellspacing=\"1\" cellpadding=\"3\" border=\"0\" bgcolor=\"000000\" style=\"font-size: 10pt;line-height: 15px;\">";
                        MailBody += "<div align=\"center\">";
                        MailBody += "<tr>";
                        for (int hcol = 0; hcol < orbitDT.Columns.Count; hcol++)
                        {
                            MailBody += "<td bgcolor=\"999999\">&nbsp;&nbsp;&nbsp;";
                            MailBody += orbitDT.Columns[hcol].ColumnName;
                            MailBody += "&nbsp;&nbsp;&nbsp;</td>";
                        }
                        MailBody += "</tr>";

                        for (int row = 0; row < orbitDT.Rows.Count; row++)
                        {
                            MailBody += "<tr>";
                            for (int col = 0; col < orbitDT.Columns.Count; col++)
                            {
                                MailBody += "<td bgcolor=\"dddddd\">&nbsp;&nbsp;&nbsp;";
                                MailBody += orbitDT.Rows[row][col].ToString();
                                MailBody += "&nbsp;&nbsp;&nbsp;</td>";
                            }
                            MailBody += "</tr>";
                        }
                        MailBody += "</table>";
                        MailBody += "</div>";
                        result= Mails.SendMial("ICP全流程监控", MailBody, null);

                    }
                }
                orbitDT = null;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                result = false;
            }
            return result;
          
        }
        protected override void OnStop()
        {
            log.Debug("服务终止运行");
        }
    }
}

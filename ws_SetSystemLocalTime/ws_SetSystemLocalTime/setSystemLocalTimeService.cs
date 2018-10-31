using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;

namespace ws_SetSystemLocalTime
{
    public partial class setSystemLocalTimeService : ServiceBase
    {
        public setSystemLocalTimeService()
        {
            InitializeComponent();
        }
        System.Timers.Timer time = new System.Timers.Timer();
        private int timeInterval = 1;

        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(SystemTime st);
        [DllImport("Kernel32.dll")]
        public static extern void SetLocalTime(SystemTime st);
        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort Whour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        SystemTime st = new SystemTime();
        protected override void OnStart(string[] args)
        {
            InitialTimer();
        }

        protected override void OnStop()
        {
            time.Stop();

        }
        private void InitialTimer()
        {
            timeInterval = (Convert.ToInt32(ConfigurationManager.AppSettings["timeInterval"].ToString()));
            st.wYear = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Year"].ToString()));
            st.wMonth = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Month"].ToString()));
            st.wDay = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Day"].ToString()));
            st.Whour = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Hour"].ToString()));
            st.wMinute = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Minute"].ToString()));
            st.wSecond = (ushort)(Convert.ToInt32(ConfigurationManager.AppSettings["Second"].ToString()));
            time.Interval = timeInterval * 60 * 1000;
            time.Elapsed += new System.Timers.ElapsedEventHandler(DoWork);
            time.Enabled = true;
            time.AutoReset = true;
            DoWork(null, null);

        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            SetLocalTime(st);
        }
    }
}

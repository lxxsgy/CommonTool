using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQdemo
{
    public partial class Form1 : Form
    {

        [Serializable]
        public class DataModel
        {
            public string ProjectId { get; set; }
            public List<ProjectData> ProjectDatas { get; set; }

        }
        [Serializable]
        public class ProjectData
        {
            private DataTable projectData = null;
            public string ProjectTabID { get; set; }
            public DataTable ProjectDataTable
            {
                get
                {
                    return this.projectData;
                }
                set
                {
                    this.projectData = value;
                }
            }

        }


        public Form1()
        {
            InitializeComponent();
        }
       private MessageQueue queue = null;
        string path = @"FormatName:DIRECT=TCP:172.16.6.212\private$\test";
        private void Form1_Load(object sender, EventArgs e)
        {
            queue = new MessageQueue(path);
            queue.Formatter = new BinaryMessageFormatter();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
           //   List<DataModel> dataEntity = new List<DataModel>();
                DataModel dataEntity = new DataModel();
                dataEntity.ProjectId = "17DB01";
                dataEntity.ProjectDatas = new List<ProjectData>();
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("agent");
                dt1.Columns.Add("zip");
                dt1.Columns.Add("city");
                dt1.TableName = "17DB0101";

                for (int i = 0; i < 5; i++)
                {
                    DataRow newdr = dt1.NewRow();

                    newdr["agent"] = "a" + i;
                    newdr["zip"] = "b" + i;
                    newdr["city"] = "c" + i;
                    dt1.Rows.Add(newdr);

                }
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("name");
                dt2.Columns.Add("age");
                dt2.Columns.Add("address");
                dt2.TableName = "17DB0102";
                for (int i = 0; i < 5; i++)
                {
                    DataRow newdr = dt2.NewRow();

                    newdr["name"] = "e" + i;
                    newdr["age"] = "f" + i;
                    newdr["address"] = "g" + i;
                    dt2.Rows.Add(newdr);
                }

                dataEntity.ProjectDatas.Add(new ProjectData { ProjectTabID = "17DB0101", ProjectDataTable = dt1 });
                dataEntity.ProjectDatas.Add(new ProjectData { ProjectTabID = "17DB0102", ProjectDataTable = dt2 });
                byte[] data = SerializeObject(dataEntity);
                var message = new System.Messaging.Message(data, new BinaryMessageFormatter());
                queue.Send(message);
            }
            catch(Exception ex)
            {

            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessReceiveTasks();
    }
        private void ProcessReceiveTasks()
        {
            TimeSpan timeOut = new TimeSpan(0,0,0,0,5000);
            System.Messaging.Message message = new System.Messaging.Message();
            while (true)
            {
                try
                {
                   
                    try
                    {
                            message = queue.Receive(timeOut);//设置超时时长，队列没有消息后的等待时长
                        if(message.Body!=null)
                        {
                            var msgInfo = DeserializeObject(message.Body as byte[]);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("超时") || ex.Message.Contains("Timeout"))
                        {
                            message = null;
                            System.Threading.Thread.Sleep(100);//如果队列没有消息，休息100毫秒
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    finally { }

                    if (message != null)
                    {
                        //OperateMessage(message);
                    }

               
                }
                catch (Exception ex)
                {

                }
            }
        }

        public  byte[] SerializeObject(object pObj)
        {
            byte[] array = null;
            if(pObj!=null)
            {
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(memoryStream,pObj);
                memoryStream.Position = 0L;

                array = new byte[memoryStream.Length];
                memoryStream.Read(array,0, array.Length);
                memoryStream.Close();

            }



            return array;

        }

        public  object DeserializeObject(byte[] pBytes)
        {
            object result = null;
            //if (pBytes != null)
            //{
            //    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(pBytes);
            //    memoryStream.Position = 0L;
            //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    result = binaryFormatter.Deserialize(memoryStream);
            //    memoryStream.Close();
            //}
            if(pBytes!=null)
            {
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(pBytes);
                  memoryStream.Position = 0L;
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new BinaryFormatter();
                result = binaryFormatter.Deserialize(memoryStream);
                memoryStream.Close();

            }
            return result;
        }
    }
}

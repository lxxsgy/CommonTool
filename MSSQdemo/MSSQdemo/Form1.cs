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
            public string Name { get; set; }
            public string Opterate { get; set; }
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
              
              List<DataModel> dataEntity = new List<DataModel>();
                dataEntity.Add(new DataModel { Name="sgy",Opterate="insert"});
                dataEntity.Add(new DataModel { Name = "lxx", Opterate = "delete" });
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

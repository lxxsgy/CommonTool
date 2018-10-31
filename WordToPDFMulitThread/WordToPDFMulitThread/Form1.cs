using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace WordToPDFMulitThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AsyUpdateUIDeleGate += new AsyUpdateUI(updateUIStatus);
        }

        private void updateUIStatus(int step)
        {
            this.progressBar1.BeginInvoke(new Action(()=> {
                if (this.progressBar1.Value + step > this.progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += step;
                }
            }));
           

        }
        public delegate void AsyUpdateUI(int step);
        public AsyUpdateUI AsyUpdateUIDeleGate;
        public delegate void Accompolish(int step);
        public Accompolish AccompolishDelegate;


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
              if(fbd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }
                 
        private void button3_Click(object sender, EventArgs e)
        {

            this.progressBar1.Maximum = 10000;
            this.progressBar1.Value = 0;
            try
            {
                string[] docFiles = Directory.GetFiles(textBox1.Text);
                object obj = new object();
                List<string> filesContent=  docFiles.ToList();
                int step = 10000 / filesContent.Count;
                System.Threading.Tasks.Task.Run(new Action(()=> {

                    while(true)
                    {
                       string docFileName = "";
                       lock(obj)
                        {
                            if(filesContent.Count>0)
                            {
                                docFileName = filesContent[0];
                                filesContent.RemoveAt(0);
                            }   else
                            {
                                break;
                            }
                        }
                        if(docFileName!="")
                        {
                            string pdfPath = Path.Combine(textBox2.Text.Trim(), Path.GetFileNameWithoutExtension(docFileName) + ".pdf");
                            string exceptionMessage = "";
                            bool result = WordHelper.Word2PdfFromFileSaveFile(docFileName, pdfPath, out exceptionMessage);
                            if (!result)
                            {
                                throw new Exception(exceptionMessage);
                            } else
                            {
                                AsyUpdateUIDeleGate(step);
                            }
                        }
                       

                    }
                }));
                System.Threading.Tasks.Task.Run(new Action(() => {

                    while (true)
                    {
                        string docFileName = "";
                        lock (obj)
                        {
                            if (filesContent.Count > 0)
                            {

                                docFileName = filesContent[0];
                                filesContent.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (docFileName != "")
                        {
                            string pdfPath = Path.Combine(textBox2.Text.Trim(), Path.GetFileNameWithoutExtension(docFileName) + ".pdf");
                            string exceptionMessage = "";
                            bool result = WordHelper.Word2PdfFromFileSaveFile(docFileName, pdfPath, out exceptionMessage);
                            if (!result)
                            {
                                throw new Exception(exceptionMessage);
                            }
                            else
                            {
                                AsyUpdateUIDeleGate(step);
                            }
                        }


                    }
                }));
                System.Threading.Tasks.Task.Run(new Action(() => {

                    while (true)
                    {
                        string docFileName = "";
                        lock (obj)
                        {
                            if (filesContent.Count > 0)
                            {

                                docFileName = filesContent[0];
                                filesContent.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (docFileName != "")
                        {
                            string pdfPath = Path.Combine(textBox2.Text.Trim(), Path.GetFileNameWithoutExtension(docFileName) + ".pdf");
                            string exceptionMessage = "";
                            bool result = WordHelper.Word2PdfFromFileSaveFile(docFileName, pdfPath, out exceptionMessage);
                            if (!result)
                            {
                                throw new Exception(exceptionMessage);
                            }
                            else
                            {
                                AsyUpdateUIDeleGate(step);
                            }
                        }


                    }
                }));
                System.Threading.Tasks.Task.Run(new Action(() => {

                    while (true)
                    {
                        string docFileName = "";
                        lock (obj)
                        {
                            if (filesContent.Count > 0)
                            {

                                docFileName = filesContent[0];
                                filesContent.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (docFileName != "")
                        {
                            string pdfPath = Path.Combine(textBox2.Text.Trim(), Path.GetFileNameWithoutExtension(docFileName) + ".pdf");
                            string exceptionMessage = "";
                            bool result = WordHelper.Word2PdfFromFileSaveFile(docFileName, pdfPath, out exceptionMessage);
                            if (!result)
                            {
                                throw new Exception(exceptionMessage);
                            }
                            else
                            {
                                AsyUpdateUIDeleGate(step);
                            }
                        }


                    }
                }));
                System.Threading.Tasks.Task.Run(new Action(() => {

                    while (true)
                    {
                        string docFileName = "";
                        lock (obj)
                        {
                            if (filesContent.Count > 0)
                            {

                                docFileName = filesContent[0];
                                filesContent.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (docFileName != "")
                        {
                            string pdfPath = Path.Combine(textBox2.Text.Trim(), Path.GetFileNameWithoutExtension(docFileName) + ".pdf");
                            string exceptionMessage = "";
                            bool result = WordHelper.Word2PdfFromFileSaveFile(docFileName, pdfPath, out exceptionMessage);
                            if (!result)
                            {
                                throw new Exception(exceptionMessage);
                            }
                            else
                            {
                                AsyUpdateUIDeleGate(step);
                            }
                        }


                    }
                }));


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            



        }

        public class WordHelper
        {
            /// <summary>
            /// Word转Pdf(源自文件->存成文件)
            /// </summary>
            /// <param name="wordFileFullPath">保存的Pdf文件绝对路径</param>
            /// <param name="pdfFileFullPath">读取的Word文件绝对路径</param>
            /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
            /// <returns></returns>
            public static bool Word2PdfFromFileSaveFile(string wordFileFullPath, string pdfFileFullPath, out string exceptionMessage)
            {
                var returnResult = true;
                exceptionMessage = string.Empty;
                try
                {
                    Microsoft.Office.Interop.Word.Application appword = new Microsoft.Office.Interop.Word.Application();
                    appword.Visible = false;

                  Document wordDoc=  appword.Documents.Open(wordFileFullPath);
                    if(wordDoc!=null)
                    {
                        wordDoc.SaveAs(pdfFileFullPath,WdSaveFormat.wdFormatPDF);
                      
                      
                    }
                    wordDoc.Close();

                    KillProcess(wordFileFullPath);

                    appword.Quit();
                  
                }
                catch (Exception ex)
                {
                    returnResult = false;
                    exceptionMessage = ex.Message;
                }
                return returnResult;
            }


            private static void KillProcess(string fileName)
            {
               Process[] process= Process.GetProcesses();
                foreach(var item in process)
                {
                    if(item.ProcessName==fileName)
                    {
                        item.Kill();
                    }
                }
            }

        }


        
    }
}

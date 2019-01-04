using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using OpenCVOCRModule;
using Emgu.CV.OCR;

namespace opencvDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Mat mat = CvInvoke.Imread(@"C:\Users\Administrator\Desktop\567.png");
            Mat des = new Mat();
            //  CvInvoke.CvtColor(mat,des,ColorConversion.Bgr2Gray);
            // Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle,new Size(1,1),new Point());
            //  CvInvoke.Erode(mat,des,element,new Point(),1,BorderType.Constant,new MCvScalar(1));
            // CvInvoke.Blur(mat,des,new Size(7,7),new Point(1));
            // CvInvoke.Canny(des,des,3,9,3);
           // CvInvoke.Circle(mat, new Point(150), 150, new MCvScalar(5));
            //CvInvoke.Rotate(mat, des, RotateFlags.Rotate180);
            pictureBox1.Image = mat.Bitmap;


            string path = Application.StartupPath + "\\tessdata";  //下载识别文件夹
            string language = "eng";//识别语言
            Tesseract ocr = new Tesseract(path, language, Emgu.CV.OCR.OcrEngineMode.Default);//生成OCR对象。
            Emgu.CV.Image<Gray, byte> GAY1 = new Image<Gray, byte>((Bitmap)pictureBox1.Image);//原图一定为灰阶图片
            ocr.SetImage(GAY1);//放进图像到OCR对象中
            int A_LENG = 2;
            A_LENG = ocr.Recognize();//进行识别图像
            if (A_LENG == 0)  //判断是否成功，应为返回为0时才是成功，因此开始定义初始化为其他值（非零）。
            {
               // MessageBox.Show("ok");
                Tesseract.Character[] tet = ocr.GetCharacters();//得到
                string tex1 = ocr.GetUTF8Text();//得到文字

                MessageBox.Show(tex1);
                foreach (var a4 in tet)
                {
                    GAY1.Draw(a4.Region, new Gray(180), 2);
                    pictureBox1.Image = GAY1.ToBitmap();


                }
            }
            else
            {
                MessageBox.Show("NG");
            }
          
          


        }
    }
    }

  

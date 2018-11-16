using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Leadtools;
using Leadtools.Annotations;
using Leadtools.Codecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeedtoolsModules
{
    public partial class MainForm : Form
    {
        Leadtools.Codecs.RasterCodecs m_codecs = null;
        // private IOcrDocument _ocrDocument;
        //private IOcrEngine ocrEngine = null;
        private AnnAutomation annAutomation = null;
        private AnnAutomationManager annAutoManager = null;
        public MainForm()
        {
            InitializeComponent();
            Leadtools.Codecs.RasterCodecs.Startup();
            m_codecs = new RasterCodecs();
            //ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.Professional, false);
            //ocrEngine.Startup(null, null, null, @"C:\Program Files (x86)\LEAD Technologies\LEADTOOLS 16.5\Bin\Common\OcrProfessionalRuntime");
            annAutoManager = new AnnAutomationManager();
            //创建默认的自动化对象
            annAutoManager.CreateDefaultObjects();
            AnnAutomationObject hiliteObject = annAutoManager.FindObject(AnnAutomationManager.HiliteObjectId);
            ContextMenu hiliteObjectMenu = hiliteObject.ContextMenu;
            foreach (MenuItem menuItem in hiliteObjectMenu.MenuItems)
            {
                //if (menuItem.Text.ToUpper() != "&DELETE")
                {
                    menuItem.Visible = true;
                }
            }
            annAutomation = new AnnAutomation(annAutoManager, rasterImageViewer1);
            annAutomation.Active = true;
            annAutoManager.UserMode = AnnUserMode.Design;
            annAutomation.Container.Objects.ItemAdded += new EventHandler<RasterCollectionEventArgs<AnnObject>>(Objects_ItemAdded);
            annAutomation.Container.Objects.ItemRemoved += new EventHandler<RasterCollectionEventArgs<AnnObject>>(Objects_ItemRemoved);
            annAutomation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(annAuto_AfterObjectChanged);

            //当AnnAutomationManager对象的UserMode被设置为Design时去掉所有自动化对象的选择手柄
            foreach (AnnAutomationObject obj in annAutoManager.Objects)
            {
                obj.UseRotateControlPoints = false;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void Objects_ItemRemoved(object sender, RasterCollectionEventArgs<AnnObject> e)
        {


        }

        private void Objects_ItemAdded(object sender, RasterCollectionEventArgs<AnnObject> e)
        {

            annAutomation.Container.Objects.Clear();
        }
        private void annAuto_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
        {

            switch (e.ChangeType)
            {
                case AnnObjectChangedType.DesignerDraw:
                    if (e.Objects.Count > 0)
                    {
                        AnnObject ann = e.Objects[0];
                        AnnRectangle annRect = ann.ConvertObjectToLogicalRectangle(ann.BoundingRectangle);
                        Int32 width, height, top, left;
                        height = (Int32)annRect.Height;
                        width = (Int32)annRect.Width;
                        top = (Int32)annRect.Top;
                        left = (Int32)annRect.Left;
                        if (top > 0 && height > 0 && top > 0 && left > 0)


                        {
                            Rectangle rectangle = new Rectangle(left, top, width, height);
                            using (RasterImage image = this.rasterImageViewer1.Image.Clone(rectangle))
                            {

                                using (MemoryStream stream = new MemoryStream())
                                {
                                    this.m_codecs.Save(image, stream, image.OriginalFormat, image.BitsPerPixel);
                                   
                                    Bitmap Bitmap = new Bitmap(stream);

                                    string temp = GetOCRText(Bitmap,checkBoxLanguage.Checked? "中文":"");
                                    //byte[] bytes = File.ReadAllBytes("123.tif");
                                    //OCRServiceClient clinet = new OCRServiceClient
                                    //    ();
                                    //var ocrresult = clinet.OCRCutSnippet(bytes);
                                    //string temp = ocrresult.OCRResult;
                                    //clinet.Close();

                                    richTextBox4.Text = "识别结果：" + temp;

                                }
                            }
                        }


                    }
                    break;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;
            }
            rasterImageViewer1.Image = m_codecs.Load(textBox4.Text);
            rasterImageViewer1.Show();
            //int count = rasterImageViewer1.Image.PageCount;
            //for (int i = 0; i < count; i++)
            //{
            //    RasterCodecs m_code = new RasterCodecs();
            //    string newImage = i.ToString().PadLeft(8, '0') + ".tiff";

            //    using (RasterImage rimg = m_codecs.Load(textBox4.Text.Trim(), 0, CodecsLoadByteOrder.Bgr, i + 1, i + 1))
            //    {
            //        m_codecs.Save(rimg, newImage, RasterImageFormat.Tif, rimg.BitsPerPixel, 1, 1, 1, CodecsSavePageMode.Overwrite);
            //    }

            //}
            annAutoManager.CurrentObjectId = AnnAutomationManager.HiliteObjectId;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            annAutoManager.CurrentObjectId = AnnAutomationManager.HiliteObjectId;
        }

        private string GetOCRText(Bitmap bit,string languageType)
        {
            string language = "eng";//识别语言
            if (languageType=="中文")
            {
                language = "chi_sim";
            }
           
            string value = "";
            string path = Application.StartupPath + "\\tessdata";  //下载识别文件夹
            Tesseract ocr = new Tesseract(path, language, Emgu.CV.OCR.OcrEngineMode.Default);//生成OCR对象。
            Emgu.CV.Image<Gray, byte> GAY1 = new Image<Gray, byte>(bit);//原图一定为灰阶图片
            ocr.SetImage(GAY1);//放进图像到OCR对象中
            int A_LENG = 2;
            A_LENG = ocr.Recognize();//进行识别图像
            if (A_LENG == 0)  //判断是否成功，应为返回为0时才是成功，因此开始定义初始化为其他值（非零）。
            {
                // MessageBox.Show("ok");
                Tesseract.Character[] tet = ocr.GetCharacters();//得到
                 value = ocr.GetUTF8Text();//得到文字
            }
            else
            {
                value = "fail to ocr";
            }
           
            return value;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            rasterImageViewer1.ScaleFactor += 0.5;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            rasterImageViewer1.ScaleFactor -= 0.5;
        }
    }
}

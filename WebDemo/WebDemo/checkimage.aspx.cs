using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebDemo
{
    public partial class checkimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int len = rand.Next(4, 4);

            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            char[] chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int iCount = 0; iCount < len; iCount++)
            {
                myStr.Append(chars[rand.Next(chars.Length)]);
            }
            string text = myStr.ToString();
            this.Session["CheckCode"] = text;
            Size ImageSize = Size.Empty;
            Font myFont = new Font("MS Sans Serif",14);
            using (Bitmap btm = new Bitmap(10, 10))
            {
                using (Graphics g = Graphics.FromImage(btm))
                {
                    SizeF size = g.MeasureString(text,myFont,200);
                    ImageSize.Width = (int)size.Width + 8;
                    ImageSize.Height = (int)size.Height;

                }
            }
            using (Bitmap bmp = new Bitmap(ImageSize.Width, ImageSize.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    using (StringFormat f = new StringFormat())
                    {
                        f.Alignment = StringAlignment.Center;
                        f.FormatFlags = StringFormatFlags.NoWrap;
                        g.DrawString(text,myFont,Brushes.Black,new RectangleF(0,0,ImageSize.Width,ImageSize.Height),f);
                    }

                }

                int number = ImageSize.Width * ImageSize.Height * 20 / 100;
                for(int iCount = 0;iCount<number;iCount++)
                {
                    int x = rand.Next(ImageSize.Width);
                    int y = rand.Next(ImageSize.Height);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    Color c = Color.FromArgb(r,g,b);
                    bmp.SetPixel(x,y,c);
                }
                myFont.Dispose();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                bmp.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
                this.Response.ContentType = "image/png";
                ms.WriteTo(this.Response.OutputStream);
                ms.Close();
            }

        

        }
        public static bool checkCode(string text)
        {
            string txt = System.Web.HttpContext.Current.Session["CheckCode"].ToString();
            return text == txt;
        }

    }
}
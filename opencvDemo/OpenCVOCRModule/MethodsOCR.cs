using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Threading.Tasks;
using Emgu.CV;
using System.Threading;
using Emgu.CV.Structure;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using Emgu.CV.OCR;

namespace OpenCVOCRModule
{
    public class MethodsOCR
    {
        private static List<Rectangle> textArea;
        public String archivo = "";
        public String ruta = "";
        public String layout = "";
        public string campos = "";
        public String unidad = "";
        System.Threading.Semaphore S = new System.Threading.Semaphore(3, 3);
        public ArrayList arrText = new ArrayList();
        private static int dim = 0;
        private static int umbral = 0;
        private static List<Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>> imageparts;

        private int procesado = 0;
        private static List<palabra> palabrasProc = new List<palabra>();
        private static int contador;

        class palabra
        {
            public int orden;
            public String texto;
            public String nombre;
        }

        public void cargarCampos()
        {
            StreamReader objReader = new StreamReader(ruta + campos + ".txt");
            string sLine = "";



            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();
        }
        public void escalarImagen()
        {

            System.Drawing.Bitmap memoryImageT =
        new System.Drawing.Bitmap(System.Drawing.Image.FromFile(
            archivo));
            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> img = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(memoryImageT);

            string layoutr = ruta + "files/" + layout + ".bmp";
            System.Drawing.Bitmap imglayout =
         new System.Drawing.Bitmap(System.Drawing.Image.FromFile(layoutr));


            // Emgu.CV.CvInvoke.Resize(img, img, new Size(imglayout.Width, imglayout.Height));
            int width = imglayout.Width;
            int height = imglayout.Height;
            Emgu.CV.CvInvoke.Resize(img, img, new Size(width, height));
            guardarArchivo(img.Mat, "imagenEscalada");
            archivo = ruta + "files/imagenEscalada.bmp"; ;

        }

        public Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> eliminarlineasegmento(Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> img, int num, int porcentajeR, int porcentajeC)
        {
            if (porcentajeC < 65)
                porcentajeC = 75;
            //era 230
            int acumula = 0;
            //vertical
            int[] valores = new int[img.Width];
            List<int> maximos = new List<int>();
            List<int> minimos = new List<int>();

            int min = 2 * img.Height;
            int max = 0;
            for (int v = 0; v < img.Width; v++)
            {
                acumula = 0;
                min = 2 * img.Height;
                max = 0;
                for (int u = 0; u < img.Height; u++)
                {

                    byte a = img.Data[u, v, 0];
                    if (a < umbral)
                    {
                        acumula++;



                    }




                }
                valores[v] = acumula;



            }


            for (int i = 0; i < valores.Length; i++)
            {

                if (valores[i] * 100 / img.Height > porcentajeC)
                {
                    //Console.WriteLine("Linea encontrada en imagen-" + num + " columna " + i);
                    for (int j = 0; j < img.Height; j++)
                    {


                        img.Data[j, i, 0] = 255;
                        img.Data[j, i, 1] = 255;
                        img.Data[j, i, 2] = 255;
                    }
                }
            }




            //horizontal
            valores = new int[img.Height];
            for (int v = 0; v < img.Height; v++)
            {
                acumula = 0;

                for (int u = 4; u < img.Width - 4; u++)
                {

                    byte a = img.Data[v, u, 0];
                    byte b = img.Data[v, u + 2, 0];
                    byte c = img.Data[v, u + 4, 0];
                    byte d = img.Data[v, u - 2, 0];
                    byte e = img.Data[v, u - 4, 0];
                    if (a < umbral && b < umbral && c < umbral && d < umbral && e < umbral)
                        acumula++;





                }
                valores[v] = acumula;
            }

            for (int i = 0; i < valores.Length; i++)
            {

                if (valores[i] * 100 / img.Width > porcentajeR)
                {
                    //  Console.WriteLine("Linea encontrada en imagen-" + num + " fila " + i);
                    for (int j = 0; j < img.Width; j++)
                    {


                        img.Data[i, j, 0] = 255;
                        img.Data[i, j, 1] = 255;
                        img.Data[i, j, 2] = 255;
                    }
                }
            }





            //delimitar region vertical

            for (int v = 0; v < img.Width; v++)
            {

                min = 2 * img.Height;

                for (int u = 0; u < img.Height; u++)
                {

                    byte a = img.Data[u, v, 0];
                    if (a < umbral)
                    {


                        if (u < min && u < img.Height / 2)
                            min = u;


                    }

                }


                if (min != img.Height * 2)
                    minimos.Add(min);




            }

            foreach (var n in minimos)
                min = n + min;

            min = min / minimos.Count;


            //buscar delimitador maximo
            for (int v = min + dim / 2; v < img.Height; v++)
            {


                max = 0;
                for (int u = 0; u < img.Width; u++)
                {
                    byte a = img.Data[v, u, 0];
                    if (a == 255)
                        max++;
                }
                if (max >= img.Width * 0.95)
                    maximos.Add(v);
            }
            maximos.Sort();
            if (maximos.Count != 0)
                max = maximos[0] + dim / 10;



            for (int i = 0; i < img.Height; i++)
            {


                if (i < min - dim / 5 || i > max)

                {

                    for (int j = 0; j < img.Width; j++)
                    {


                        img.Data[i, j, 0] = 255;
                        img.Data[i, j, 1] = 255;
                        img.Data[i, j, 2] = 255;
                    }
                }
            }



            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(img.Width, img.Height);

            for (int i = 0; i < img2.Width; i++)
            {


                for (int j = 0; j < img2.Height; j++)
                {
                    img2.Data[j, i, 0] = img.Data[j, i, 0];
                    img2.Data[j, i, 1] = img.Data[j, i, 1];
                    img2.Data[j, i, 2] = img.Data[j, i, 2];


                }
            }



            return img2;
        }

        public bool recortarROI()
        {

            System.Drawing.Bitmap memoryImageT =
         new System.Drawing.Bitmap(System.Drawing.Image.FromFile(archivo));
            int minx = 10000;
            int miny = 10000;
            int maxx = 0;
            int maxy = 0;

            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> img = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(memoryImageT);

            umbral = valorUmbral(img);


            for (int v = 4; v < img.Height - 4; v++)
            {
                for (int u = 4; u < img.Width - 4; u++)
                {
                    byte a = img.Data[v, u, 0]; //Get Pixel Color | fast way
                    if (a <= umbral * 0.50 && (
                        (img.Data[v - 4, u - 4, 0] <= umbral * 0.50 && img.Data[v + 4, u + 4, 0] <= umbral * 0.50 && img.Data[v - 2, u - 2, 0] <= umbral * 0.50 && img.Data[v + 2, u + 2, 0] <= umbral * 0.50) ||
                        (img.Data[v + 4, u - 4, 0] <= umbral * 0.50 && img.Data[v - 4, u + 4, 0] <= umbral * 0.50 && img.Data[v + 2, u - 2, 0] <= umbral * 0.50 && img.Data[v - 2, u + 2, 0] <= umbral * 0.50) ||
                        (img.Data[v, u - 4, 0] <= umbral * 0.50 && img.Data[v, u + 2, 0] <= umbral * 0.50 && img.Data[v, u - 2, 0] <= umbral * 0.50 && img.Data[v, u + 2, 0] <= umbral * 0.50) ||
                        (img.Data[v + 4, u, 0] <= umbral * 0.50 && img.Data[v - 2, u, 0] <= umbral * 0.50 && img.Data[v + 2, u, 0] <= umbral * 0.50 && img.Data[v - 2, u, 0] <= umbral * 0.50)
                        ))
                    {


                        if (u < minx)
                            minx = u;
                        if (v < miny)
                            miny = v;
                        if (u > maxx)
                            maxx = u;
                        if (v > maxy)
                            maxy = v;
                    }

                }
            }
            Console.WriteLine("minimo: " + minx + "," + miny + "  maximo: " + maxx + "," + maxy);
            Rectangle roi = new Rectangle();
            roi.X = minx;
            roi.Y = miny;
            roi.Width = maxx - minx;
            roi.Height = maxy - miny;
            img.ROI = roi;
            guardarArchivo(img.Copy().Mat, "imagenROI");
            //detectar traslacion por relacion proporcional entre punto minimo y tamaño de la imagen

            float proporcionX = img.Width / minx;
            float proporcionY = img.Height / miny;
            archivo = ruta + "files/imagenROI.bmp";
            if ((proporcionX > 11 || proporcionX < 9) || (proporcionY > 47 || proporcionY < 45))
                return true;

            return false;

        }


        public bool Deskew()
        {



            System.Drawing.Bitmap memoryImageT =
         new System.Drawing.Bitmap(System.Drawing.Image.FromFile(
             archivo));


            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> imgOrig = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(memoryImageT);


            System.Drawing.Bitmap bmp = imgOrig.ToBitmap();


            UnmanagedImage unmanagedImage = UnmanagedImage.FromManagedImage(bmp);


            DocumentSkewChecker skewChecker = new DocumentSkewChecker();
            double angle = skewChecker.GetSkewAngle(unmanagedImage);
            // create rotation filter
            archivo = ruta + "files/imagen.bmp";
            Console.WriteLine("El angulo de inclinacion del documento es " + angle.ToString());
            if (angle != 0)
            {
                RotateBilinear rotationFilter = new RotateBilinear(-angle);
                rotationFilter.FillColor = Color.White;
                // rotate image applying the filter
                Bitmap rotatedImage = rotationFilter.Apply(bmp);
                Emgu.CV.Image<Emgu.CV.Structure.Gray, byte> image = new Emgu.CV.Image<Emgu.CV.Structure.Gray, byte>(rotatedImage);
                guardarArchivo(image.Mat, "imagen");
                return true;
            }
            guardarArchivo(imgOrig.Mat, "imagen");
            return false;

        }


        public void guardarArchivo(Emgu.CV.Mat img, String name)
        {

            Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> memoryImageOut = img.ToImage<Emgu.CV.Structure.Bgr, Byte>();

            Bitmap memoryImageT = memoryImageOut.ToBitmap();

            memoryImageT.Save(ruta + "/files/" + name + ".bmp");


        }
        public Emgu.CV.Mat detectarLineas(Mat img)
        {
            double cannyThreshold = umbral;
            //Convert the image to grayscale and filter out the noise
            Emgu.CV.Mat uimage = img.Clone();
            Emgu.CV.Mat imgret = new Emgu.CV.Mat();








            double cannyThresholdLinking = umbral - 60;
            Emgu.CV.Mat cannyEdges = new Emgu.CV.Mat();
            Emgu.CV.CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);




            Emgu.CV.Structure.LineSegment2D[] lines = Emgu.CV.CvInvoke.HoughLinesP(
               cannyEdges,
               1, //Distance resolution in pixel-related units 1
               Math.PI / 180.0, //Angle resolution measured in radians.
              255 - umbral, //threshold
               30, //min Line width 10
               5); //gap between lines 1



            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> lineImage = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(img.Width, img.Height);
            foreach (Emgu.CV.Structure.LineSegment2D line in lines)
            {



                lineImage.Draw(line, new Gray(255), 2);


            }



            Emgu.CV.Mat imgInv = new Emgu.CV.Mat();
            Emgu.CV.CvInvoke.BitwiseNot(uimage, uimage);


            Emgu.CV.CvInvoke.BitwiseNot(lineImage, lineImage);



            guardarArchivo(lineImage.Mat, "3imagenmascara");


            guardarArchivo(uimage, "4imagenLineas");
            Emgu.CV.CvInvoke.BitwiseAnd(uimage, lineImage, imgret);





            Emgu.CV.CvInvoke.BitwiseNot(imgret, imgret);


            guardarArchivo(imgret, "5imagensinLineas");
            return imgret;
        }

        public int encontrarDimensionLetra()
        {
            int tamano = 0;
            System.Drawing.Bitmap bmp =
        new System.Drawing.Bitmap(System.Drawing.Image.FromFile(ruta + "files/6imagenthresherode.bmp"));
            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> imgt = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(bmp);

            Emgu.CV.Structure.MCvScalar sc = new Emgu.CV.Structure.MCvScalar();
            Size s = new Size(imgt.Width / 10, 1);

            Point p = new Point(-1, -1);
            Mat element = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, s, p);


            Emgu.CV.CvInvoke.MorphologyEx(imgt, imgt, Emgu.CV.CvEnum.MorphOp.Close, element, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Constant, sc);
            guardarArchivo(imgt.Mat, "imagenCerrada");
            List<int> valores = new List<int>();



            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            Emgu.CV.Mat hier = new Emgu.CV.Mat();
            Emgu.CV.CvInvoke.FindContours(imgt, contours, hier, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            Emgu.CV.Util.VectorOfVectorOfPoint contours_poly = new Emgu.CV.Util.VectorOfVectorOfPoint(contours.Size);

            for (int i = 0; i < contours.Size; i++)
            {
                if (contours[i].Size > 100)//80
                {
                    Emgu.CV.CvInvoke.ApproxPolyDP((contours[i]), contours_poly[i], 3, true);

                    Rectangle appRect = Emgu.CV.CvInvoke.BoundingRectangle(contours_poly[i]);                //get the bounding rect
                    if (appRect.Height > 2)
                        valores.Add(appRect.Height);

                }
            }
            valores.Sort();
            if (valores.Count % 2 == 0)
            {
                tamano = (valores[Convert.ToInt32(Math.Floor(valores.Count * 0.50))] + valores[Convert.ToInt32(Math.Floor(valores.Count * 0.50)) + 1]) / 2;

            }
            else
            {
                tamano = valores[Convert.ToInt32(Math.Round(valores.Count * 0.50))];
            }




            return tamano;

        }
        public int valorUmbral(Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> imgt)
        {
            int umbral = 0, acumula = 0, con = 0;
            for (int v = 0; v < imgt.Width; v++)
            {

                for (int u = 0; u < imgt.Height; u++)
                {

                    byte a = imgt.Data[u, v, 0];

                    acumula = a + acumula;
                    con++;


                }
            }
            umbral = acumula / con;
            return umbral;
        }
        public List<Rectangle> detectLetters(Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> imgOrig)
        {

            List<Rectangle> boundRect = new List<Rectangle>();
            Emgu.CV.Mat img_gray = new Emgu.CV.Mat();
            Emgu.CV.Mat img_sobel = new Emgu.CV.Mat();
            Emgu.CV.Mat img_threshold = new Emgu.CV.Mat();
            Emgu.CV.Mat element = new Emgu.CV.Mat();
            Emgu.CV.Mat mascara = new Emgu.CV.Mat();
            Emgu.CV.Structure.MCvScalar sc = new Emgu.CV.Structure.MCvScalar();
            Mat img = imgOrig.Mat;
            string layoutr = ruta + "files/" + layout + ".bmp";
            System.Drawing.Bitmap bmplayout =
         new System.Drawing.Bitmap(System.Drawing.Image.FromFile(layoutr));
            Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte> imageLayout = new Emgu.CV.Image<Emgu.CV.Structure.Gray, Byte>(bmplayout);



            guardarArchivo(img, "1ImageWork");
            Emgu.CV.CvInvoke.CvtColor(img, img_gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Emgu.CV.CvInvoke.Threshold(img_gray, img_threshold, umbral, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);

            Emgu.CV.CvInvoke.BitwiseNot(img_threshold, img_threshold);



            Emgu.CV.CvInvoke.BitwiseAnd(img_threshold, imageLayout, img_threshold);



            guardarArchivo(img_threshold, "2threshImage");


            Emgu.CV.Mat verticalStructure = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(2, 1), new Point(-1, -1));


            Emgu.CV.CvInvoke.BitwiseNot(img_threshold, img_threshold);





            img_threshold = detectarLineas(img_threshold);
            Emgu.CV.CvInvoke.BitwiseNot(img_threshold, img_threshold);

            Emgu.CV.CvInvoke.Erode(img_threshold, img_threshold, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
            guardarArchivo(img_threshold, "6imagenthresherode");
            dim = encontrarDimensionLetra();

            verticalStructure = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(2, 2), new Point(-1, -1));

            Emgu.CV.CvInvoke.Dilate(img_threshold, img_threshold, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
            guardarArchivo(img_threshold, "7imagenthreshdilate");

            //proporcion de letra 3/4 de altura cerradura aplicada entre 3 letras tomando en cuenta espacios
            Size s = new Size(Convert.ToInt32(Math.Round(dim * 0.75 * 3)), 2);//modificado 40-3
            Point p = new Point(-1, -1);
            element = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, s, p);
            guardarArchivo(element, "kernel");

            Emgu.CV.CvInvoke.MorphologyEx(img_threshold, img_threshold, Emgu.CV.CvEnum.MorphOp.Close, element, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Constant, sc);
            guardarArchivo(img_threshold, "8morphoImage");

            verticalStructure = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(4, 4), new Point(-1, -1));

            Emgu.CV.CvInvoke.Erode(img_threshold, img_threshold, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
            guardarArchivo(img_threshold, "9imagenthresherode");


            Emgu.CV.CvInvoke.Dilate(img_threshold, img_threshold, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
            guardarArchivo(img_threshold, "10imagenthreshdilate");

            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            Emgu.CV.Mat hier = new Emgu.CV.Mat();
            Emgu.CV.CvInvoke.FindContours(img_threshold, contours, hier, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            Emgu.CV.Util.VectorOfVectorOfPoint contours_poly = new Emgu.CV.Util.VectorOfVectorOfPoint(contours.Size);

            for (int i = 0; i < contours.Size; i++)
            {

                {
                    Emgu.CV.CvInvoke.ApproxPolyDP((contours[i]), contours_poly[i], 3, true);

                    Rectangle appRect = Emgu.CV.CvInvoke.BoundingRectangle(contours_poly[i]);                //get the bounding rect


                    if (appRect.Height > dim / 2)
                    {




                        appRect.Height = appRect.Height + dim / 2;
                        appRect.Width = appRect.Width + dim * 3 / 4;
                        appRect.Y = appRect.Y - dim / 4;
                        appRect.X = appRect.X - dim * 3 / 4;

                        boundRect.Add(appRect);
                    }

                }
            }


            return boundRect;
        }


        public void ExtraerArea()
        {

            System.Drawing.Bitmap memoryImageT =
         new System.Drawing.Bitmap(System.Drawing.Image.FromFile(
             archivo));


            Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> imgOrig = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>(memoryImageT);








            //detecta areas con texto

            textArea = detectLetters(imgOrig);


            for (int i = 0; i < textArea.Count; i++)
            {
                Emgu.CV.CvInvoke.Rectangle(imgOrig, textArea[i], new Emgu.CV.Structure.MCvScalar(0, 0, 255), 2);
            }

            Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> memoryImageOut = imgOrig;


            memoryImageT = memoryImageOut.ToBitmap();



            System.Drawing.Bitmap memoryImageT2 =
       new System.Drawing.Bitmap(System.Drawing.Image.FromFile(
           archivo));



            //guardar segmentos de imagen
            Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> imgOriginal = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>(memoryImageT2);

            imgOriginal = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>(imgOriginal.Mat.Bitmap);

            imageparts = new List<Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>>(); // List of extracted image parts


            foreach (var roi in textArea)
            {
                imgOriginal.ROI = roi;
                imageparts.Add(imgOriginal.Copy());
            }
            int k = 0;
            contador = imageparts.Count;

            foreach (var imagen in imageparts)
            {


                //mejoro calidad de texto en cada segmento

                Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> mt = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte>(imagen.Mat.Bitmap);

                Emgu.CV.CvInvoke.CvtColor(imagen, mt, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                guardarArchivo(mt.Mat, "z-imgtexto-" + k.ToString() + "-antes");
                int umbralsegmento = valorUmbral(mt.Mat.ToImage<Emgu.CV.Structure.Gray, Byte>());

                if (umbralsegmento < 200)
                    Emgu.CV.CvInvoke.Threshold(mt, mt, umbral, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);





                Mat imagenMat = new Mat();


                if (Convert.ToDouble(imagen.Height) / dim <= 1.5)
                {
                    imagenMat = eliminarlineasegmento(mt.Mat.ToImage<Emgu.CV.Structure.Bgr, Byte>(), k, 40, dim * 130 / imagen.Height).Mat;

                }
                if (Convert.ToDouble(imagen.Height) / dim > 1.5 && imagen.Height / dim <= 2.0)//2.5
                {
                    imagenMat = eliminarlineasegmento(mt.Mat.ToImage<Emgu.CV.Structure.Bgr, Byte>(), k, 40, dim * 120 / imagen.Height).Mat;

                }
                if (Convert.ToDouble(imagen.Height) / dim > 2.0)
                {
                    imagenMat = eliminarlineasegmento(mt.Mat.ToImage<Emgu.CV.Structure.Bgr, Byte>(), k, 40, dim * 110 / imagen.Height).Mat;
                }


                /*
                Emgu.CV.CvInvoke.BitwiseNot(imagenMat, imagenMat);
                Mat verticalStructure = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(2, 1), new Point(-1, -1));
                Emgu.CV.CvInvoke.Erode(imagenMat, imagenMat, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
                verticalStructure = Emgu.CV.CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(2, 2), new Point(-1, -1));
                Emgu.CV.CvInvoke.Dilate(imagenMat, imagenMat, verticalStructure, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new Emgu.CV.Structure.MCvScalar());
                Emgu.CV.CvInvoke.BitwiseNot(imagenMat, imagenMat);
    */


                guardarArchivo(imagenMat, "z-imgtexto-" + k.ToString());
                k++;
            }


            memoryImageT.Save(ruta + "/files/11textarea.bmp");


        }





        public void procesar()
        {






            for (int i = 0; i < textArea.Count; i++)
            {

                new Thread(() =>
                {

                    ProcesarOCRHilos();


                }).Start();



            }






        }
        public String coincidirCampo(int x, int y)
        {

            String nombre = "";


            foreach (String campo in arrText)
            {
                if (Math.Abs(x - Convert.ToInt16(campo.Split(',')[1])) < dim * 2 && Math.Abs(y - Convert.ToInt16(campo.Split(',')[2])) < dim / 2)
                    nombre = campo.Split(',')[0];
            }
            return nombre;

        }
        public void ProcesarOCRHilos()
        {

            try
            {

                S.WaitOne();
                int i = -1;

                System.Object obj = (System.Object)procesado;
                System.Threading.Monitor.Enter(obj);
                String campo = "";
                try
                {
                    i = procesado;
                    procesado++;

                }
                finally
                {
                    System.Threading.Monitor.Exit(obj);
                }

                if (i < textArea.Count)
                {
                    //var img = Pix.LoadFromFile(ruta + "/files/" + "z-imgtexto-" + i.ToString() + ".bmp");


                    try
                    {                        
                    //    using (var engine = new Tesseract(unidad + @":\tessdata", "eng", OcrEngineMode.Default))
                    //    {
                    //        using (var page = engine.GetUTF8Text(img, Tesseract.PageSegMode.SingleLine))



                    //        {

                    //            int x = textArea[i].X;
                    //            int y = textArea[i].Y;
                    //            string field = coincidirCampo(x, y);




                    //            campo = page.GetText();
                    //            palabra p = new palabra();
                    //            p.nombre = field;
                    //            p.orden = i;
                    //            p.texto = campo.Replace('‘', '\0').Replace("'", "\0");
                    //            palabrasProc.Add(p);
                    //            // Console.WriteLine("exito hilo " + i.ToString());
                    //            if (palabrasProc.Count == textArea.Count)
                    //                Console.WriteLine("Se obtuvo texto de los segmentos, presione una tecla para generar archivo.");
                    //        }
                    //    }
                    }
                    catch (Exception)
                    {
                        //  Console.WriteLine("fallo hilo " + i.ToString());

                    }
                }
            }
            finally
            {
                // release so others can go (increment)     
                S.Release();
            }




        }






        public void mostrarTexto()
        {

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(ruta + "output.txt");

                //Write a line of text





                if (palabrasProc.Count == textArea.Count)
                {
                    palabrasProc.Sort((p, q) => -1 * p.orden.CompareTo(q.orden));
                    foreach (palabra campo in palabrasProc)
                    {
                        // Console.WriteLine(campo.nombre+": "+campo.texto + "\n\r");
                        sw.WriteLine(campo.nombre + ":" + campo.texto.Replace('\n', ' '));
                    }

                }
                //Close the file
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }

        }
    }
}
   



using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class ImageFunctions
    {

        public static Bitmap grayTransformation(Bitmap image)
        {
            
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    int grayValue = (int)(currentPixel.R * 0.299 + currentPixel.G * 0.587 + currentPixel.B * 0.114);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    image.SetPixel(x, y, grayColor);
                }
            }

            return image;
        }

        public static Bitmap binaryTransformation(Bitmap image, int threshold)
        {

            image = grayTransformation(image);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    // Grayscale formatta R, G ve B değerleri eşit olduğu için yalnız birisiyle karşılaştırma yapılıyor.
                    if (currentPixel.R < threshold)
                    {
                        Color black = Color.FromArgb(0, 0, 0);
                        image.SetPixel(x, y, black);
                    }

                    else
                    {
                        Color white = Color.FromArgb(255, 255, 255);
                        image.SetPixel(x, y, white);
                    }
                }
            }

            return image;
        }

        public static (double, double, double) RGBtoYCbCr(int R, int G, int B)
        {
            double Y, Cb, Cr;
            int delta = 128;
            Y = 0.299 * R + 0.587 * G + 0.114 * B;
            Cr = (R - Y) * 0.713 + delta;
            Cb = (B - Y) * 0.564 + delta;

            return (Y, Cb, Cr);
        }

        public static (int, int, int) YCbCrtoRGB(double Y, double Cb, double Cr)
        {
            int R, G, B;
            int delta = 128;

            R = (int)(Y + 1.403 * (Cr - delta));
            G = (int)((Y - 0.714 * (Cr - delta)) - 0.344 * (Cb - delta));
            B = (int)(Y + 1.773 * (Cb - delta));
            R = Math.Clamp(R, 0, 255);
            G = Math.Clamp(G, 0, 255);
            B = Math.Clamp(B, 0, 255);
            return (R, G, B);
        }

        /*
        public static Bitmap imageRGBtoYCbCr(Bitmap image, double new_Y, double new_Cb, double new_Cr)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0);
            }

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    Color currentPixel = newImage.GetPixel(x, y);

                    (double curr_Y, double curr_Cb, double curr_Cr) = RGBtoYCbCr(currentPixel.R, currentPixel.G, currentPixel.B);

                    (int new_R, int new_G, int new_B) = YCbCrtoRGB(new_Y, new_Cb, new_Cr);

                    Color transformedPixel = Color.FromArgb(new_R, new_G, new_B);
                    newImage.SetPixel(x, y, transformedPixel);
                }
            }
            return newImage;
        }
        */

        public static (double, double, double) RGBtoHSV(int R, int G, int B)
        {
            double H = 0, S, V;
            double maxValue = Math.Max(R, Math.Max(G, B));
            double minValue = Math.Min(R, Math.Min(G, B));

            double deltaValue = maxValue - minValue;

            if (deltaValue == 0)
            {
                H = 360;
                S = 0;
                V = maxValue;
                return (H, S, V);
            }

            // Hue hesaplama
            if (maxValue == R && G >= B)
            {
                H = 60 * ((G-B) / deltaValue) + 0;
            }

            else if (maxValue == R && G < B)
            {
                H = 60 * ((G - B) / deltaValue) + 360;
            }

            else if (maxValue == G)
            {
                H = 60 * ((B - R) / deltaValue) + 120;
            }

            else if (maxValue == B)
            {
                H = 60 * ((R - G) / deltaValue) + 240;
            }

            if (H < 0)
            {
                H += 360;
            }
            // Satürasyon hesaplama
            S = (maxValue == 0) ? 0 : 1 - (deltaValue / maxValue);

            // Değer (value) hesaplama
            V = maxValue;


            return (H, S, V);
        }

        public static (int, int, int) HSVtoRGB(double H, double S, double V)
        {
            double _R = 0;
            double _G = 0;
            double _B = 0;

            double chromaValue = V * S;
            double _H = H / 60;
            double X = chromaValue * (1 - Math.Abs((_H / 60) % 2 - 1));
            double m = V - chromaValue;

            if (_H >= 0 && _H < 60)
            {
                (_R, _G, _B) = (chromaValue, X, 0);

            }

            else if (_H >= 60 && _H < 120)
            {
                (_R, _G, _B) = (X, chromaValue, 0);
            }

            else if (_H >= 120 && _H < 180)
            {
                (_R, _G, _B) = (0, chromaValue, X);
            }

            else if (_H >= 180 && _H < 240)
            {
                (_R, _G, _B) = (0, X, chromaValue);
            }

            else if (_H >= 240 && _H < 300)
            {
                (_R, _G, _B) = (X, 0, chromaValue);
            }

            else if (_H >= 300 && _H < 360)
            {
                (_R, _G, _B) = (chromaValue, 0, X);
            }

            return ((int)((_R + m) * 255), (int)((_G + m) * 255), (int)((_B + m) * 255));
        }
        
        /*
        public static Bitmap imageRGBtoHSV(Bitmap image, double new_H, double new_S, double new_V)
        {

            Bitmap newImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0);
            }

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    Color currentPixel = newImage.GetPixel(x, y);
                    double curr_H, curr_S, curr_V;

                    (curr_H, curr_S, curr_V) = RGBtoHSV(currentPixel.R, currentPixel.G, currentPixel.B);

                    double weighted_H = (curr_H * new_H) % 360;
                    double weighted_S = Math.Min(Math.Max(curr_S * new_S, 0), 1);
                    double weighted_V = Math.Min(Math.Max(curr_V * new_V, 0), 1);

                    int new_R, new_G, new_B;
                    (new_R, new_G, new_B) = HSVtoRGB(weighted_H, weighted_S, weighted_V);

                    new_R = Math.Min(Math.Max(new_R, 0), 255);
                    new_G = Math.Min(Math.Max(new_G, 0), 255);
                    new_B = Math.Min(Math.Max(new_B, 0), 255);

                    Color transformedPixel = Color.FromArgb(new_R, new_G, new_B);
                    newImage.SetPixel(x, y, transformedPixel);
                }
            }
            return newImage;
        }
        */

        public static Bitmap Convolution(Bitmap image, double[,] kernel, bool isAddEdge)
        {
            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);

            int halfKernelWidth = kernelWidth / 2;
            int halfKernelHeight = kernelHeight / 2;
            // Kenarları doldurma
            if (!isAddEdge)
            {
                Bitmap newImage = new Bitmap(image.Width, image.Height);
                for (int y = halfKernelHeight; y < image.Height - halfKernelHeight; y++)
                {
                    for (int x = halfKernelWidth; x < image.Width - halfKernelWidth; x++)
                    {
                        int sumR = 0;
                        int sumG = 0;
                        int sumB = 0;
                        int R, G, B = 0;
                        for (int tX = 0; tX < kernelHeight; tX++)
                        {
                            for (int tY = 0; tY < kernelWidth; tY++)
                            {

                                int pixelX = x + (tX - halfKernelWidth);
                                int pixelY = y + (tY - halfKernelHeight);

                                Color currentPixel = image.GetPixel(pixelX, pixelY);
                                R = (int)(currentPixel.R * kernel[tX, tY]);
                                G = (int)(currentPixel.G * kernel[tX, tY]);
                                B = (int)(currentPixel.B * kernel[tX, tY]);
                                sumR += R;
                                sumG += G;
                                sumB += B;
                            }
                        }

                        sumR = Math.Min(Math.Max(sumR, 0), 255);
                        sumG = Math.Min(Math.Max(sumG, 0), 255);
                        sumB = Math.Min(Math.Max(sumB, 0), 255);
                        Color newPixel = Color.FromArgb(sumR, sumG, sumB);
                        newImage.SetPixel(x, y, newPixel);
                    }
                }
                return newImage;
            }
            // Kenarları Doldur
            else
            {
                Bitmap newImage = FillEdge(image);

                for (int y = halfKernelHeight; y < newImage.Height - halfKernelHeight; y++)
                {
                    for (int x = halfKernelWidth; x < newImage.Width - halfKernelWidth; x++)
                    {
                        int sumR = 0;
                        int sumG = 0;
                        int sumB = 0;
                        int R, G, B = 0;
                        for (int tX = 0; tX < kernelHeight; tX++)
                        {
                            for (int tY = 0; tY < kernelWidth; tY++)
                            {

                                int pixelX = x + (tX - halfKernelWidth);
                                int pixelY = y + (tY - halfKernelHeight);

                                Color currentPixel = newImage.GetPixel(pixelX, pixelY);
                                R = (int)(currentPixel.R * kernel[tX, tY]);
                                G = (int)(currentPixel.G * kernel[tX, tY]);
                                B = (int)(currentPixel.B * kernel[tX, tY]);
                                sumR += R;
                                sumG += G;
                                sumB += B;
                            }
                        }

                        sumR = Math.Min(Math.Max(sumR, 0), 255);
                        sumG = Math.Min(Math.Max(sumG, 0), 255);
                        sumB = Math.Min(Math.Max(sumB, 0), 255);
                        Color newPixel = Color.FromArgb(sumR, sumG, sumB);
                        newImage.SetPixel(x, y, newPixel);
                    }
                }
                return newImage;
            }
        }
        public static Bitmap FillEdge(Bitmap image)
        {
            Bitmap newBitmap = new Bitmap(image.Width + 1, image.Height + 1);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (x == 0 || y == 0 || x == newBitmap.Width || y == newBitmap.Height)
                    {
                        newBitmap.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        newBitmap.SetPixel(x, y, image.GetPixel(x, y));
                    }
                }
            }
            return newBitmap;
        }
        public static double[,] GaussianFilter(double sigma, int kernelSize)
        {

            double[,] kernel = new double[kernelSize, kernelSize];
            double sum = 0.0;
            int center = kernelSize / 2;

            double twoSigmaSquare = 2.0 * Math.PI * sigma * sigma;

            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    int x = j - center;
                    int y = i - center;

                    double exponent = -(x * x + y * y) / twoSigmaSquare;

                    kernel[i, j] = Math.Exp(exponent);

                    sum += kernel[i, j];
                }
            }

            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            return kernel;
        }

        public static Bitmap brightnessTransformation(Bitmap image, int brightness)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    int R = Math.Min(Math.Max(currentPixel.R + brightness, 0), 255);
                    int G = Math.Min(Math.Max(currentPixel.G + brightness, 0), 255);
                    int B = Math.Min(Math.Max(currentPixel.B + brightness, 0), 255);
                    Color newPixel = Color.FromArgb(R, G, B);
                    result.SetPixel(x, y, newPixel);
                }
            }
            return result;
        }
        // Format24bppRgb kullanımının nedeni bazı dosyaların indexed-pixel kullanması, bu hataya yol açıyor. O yüzden bazı fonksiyonlara dönüştürme için ekliyorum.
        public static int[] calculateHistogram(Bitmap image)
        {
            // zaten grayTransformation kullanılmış, o yüzden Format24bppRgb kullanımına gerek yok.
            image = ImageFunctions.grayTransformation(image);
            int[] histogramCounter = new int[256];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    int grayValue = currentPixel.R;
                    histogramCounter[grayValue] += 1;
                }
            }
            return histogramCounter;
        }

        public static Bitmap stretchingHistogram(Bitmap image)
        {
            image = ImageFunctions.grayTransformation(image);
            int min = 255;
            int max = 0;

            // Min–max tespiti
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int pixelValue = image.GetPixel(x, y).R;

                    if (pixelValue < min) min = pixelValue;
                    if (pixelValue > max) max = pixelValue;
                }
            }

            if (min == max) return image;

            Bitmap stretchedImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    int stretchedValue = ((currentPixel.R - min) * 255) / (max - min);
                    Color newPixel = Color.FromArgb(stretchedValue, stretchedValue, stretchedValue);
                    stretchedImage.SetPixel(x, y, newPixel);
                }
            }
            return stretchedImage;
        }
        public static Bitmap extendingHistogram(Bitmap image, int minRange, int maxRange)
        {
            image = ImageFunctions.grayTransformation(image);

            Bitmap extendedImage = new Bitmap(image.Width, image.Height);

            int tempMin = Math.Min(minRange, maxRange);
            int tempMax = Math.Max(minRange, maxRange);
            minRange = tempMin;
            maxRange = tempMax;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    if (currentPixel.R >= minRange && currentPixel.R <= maxRange)
                    {
                        
                        int stretchedValue = ((currentPixel.R - minRange) * 255) / (maxRange - minRange);
                        Color newPixel = Color.FromArgb(stretchedValue, stretchedValue, stretchedValue);
                        extendedImage.SetPixel(x, y, newPixel);
                    }

                    else 
                    { 
                        extendedImage.SetPixel(x, y, currentPixel);
                    }
                }
            }

            return extendedImage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class Sobel
    {
        public static Bitmap sobelEdgeAlgoritm(Bitmap image)
        {
            image = ImageFunctions.grayTransformation(image);
            Bitmap sobelImage = new Bitmap(image.Width, image.Height);
            int[,] kernelAxisX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] kernelAxisY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int Gx = 0;
                    int Gy = 0;
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int posX = x + kx;
                            int posY = y + ky;
                            if (posX >= 0 && posX < image.Width && posY >= 0 && posY < image.Height)
                            {
                                Gx += kernelAxisX[ky + 1, kx + 1] * image.GetPixel(posX, posY).R;
                                Gy += kernelAxisY[ky + 1, kx + 1] * image.GetPixel(posX, posY).R;
                            }
                        }
                    }
                    int Gsobel = (int)Math.Sqrt((Gx * Gx) + (Gy * Gy));
                    Gsobel = Math.Clamp(Gsobel, 0, 255);
                    Color sobelPixel = Color.FromArgb(Gsobel, Gsobel, Gsobel);
                    sobelImage.SetPixel(x,y, sobelPixel);
                }
            }

            return sobelImage;
        }

        /*
        public static Bitmap sobelEdgeAlgoritm(Bitmap image)
        {
            image = ImageFunctions.binaryTransformation(image, 100);
            int[,] kernelAxisX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] kernelAxisY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            int matrixCenterX = kernelAxisX.GetLength(0) / 2;
            int matrixCenterY = kernelAxisX.GetLength(1) / 2;
            for (int y = matrixCenterY; y < image.Height - matrixCenterY; y++)
            {
                for (int x = matrixCenterX; x < image.Width - matrixCenterX; x++)
                {
                    Color centerPixel = image.GetPixel(x, y);

                    for (int ky = 0; ky < kernelAxisX.GetLength(0); ky++)
                    {
                        for (int kx = 0; kx < kernelAxisX.GetLength(1); kx++)
                        {
                            int posX = x + kx - matrixCenterX;
                            int posY = y + ky - matrixCenterY;
                            if (posX >= 0 && posX < image.Width && posY >= 0 && posY < image.Height)
                            {
                                Color P1 = image.GetPixel(posX - 1, posY - 1);
                                Color P2 = image.GetPixel(posX, posY - 1);
                                Color P3 = image.GetPixel(posX + 1, posY - 1);
                                Color P4 = image.GetPixel(posX - 1, posY);
                                Color P5 = image.GetPixel(posX, posY);
                                Color P6 = image.GetPixel(posX + 1, posY);
                                Color P7 = image.GetPixel(posX - 1, posY + 1);
                                Color P8 = image.GetPixel(posX, posY + 1);
                                Color P9 = image.GetPixel(posX + 1, posY + 1);

                                int Gx = Math.Abs((-1 * (P1.R + 2 * P4.R + P7.R)) + (P3.R + 2 * P6.R + P9.R));
                                int Gy = Math.Abs((-1 * (P7.R + 2 * P8.R + P9.R)) + (P1.R + 2 * P2.R + P3.R));
                                int Gsobel = (int)Math.Sqrt((Gx * Gx) + (Gy * Gy));

                            }
                        }
                    }
                }
            }
        }
        */
    }
}

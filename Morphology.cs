using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class Morphology
    {
        
        public static Bitmap imageDilation(Bitmap image, int[,] kernel)
        {
            image = ImageFunctions.binaryTransformation(image, 100);
            int matrixCenterX = kernel.GetLength(0) / 2;
            int matrixCenterY = kernel.GetLength(1) / 2;
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int y = matrixCenterY; y < image.Height - matrixCenterY; y++)
            {
                for (int x = matrixCenterX; x < image.Width - matrixCenterX; x++)
                {
                    Color centerPixel = image.GetPixel(x, y);

                    for (int ky = 0; ky < kernel.GetLength(0); ky++)
                    {
                        for (int kx = 0; kx < kernel.GetLength(1); kx++)
                        {
                            int posX = x + kx - matrixCenterX;
                            int posY = y + ky - matrixCenterY;
                            if (posX >= 0 && posX < image.Width && posY >= 0 && posY < image.Height)
                            {
                                Color neighborPixel = image.GetPixel(posX, posY);
                                if (centerPixel.R == 0 && neighborPixel.R == 0)
                                {
                                    newImage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }

                                else
                                {
                                    newImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                }
                            }
                        }
                    }
                }
            }

            return newImage;
        }

        public static Bitmap imageErosion(Bitmap image, int[,] kernel)
        {
            image = ImageFunctions.binaryTransformation(image, 100);
            int matrixCenterX = kernel.GetLength(0) / 2;
            int matrixCenterY = kernel.GetLength(1) / 2;
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int y = matrixCenterY; y < image.Height - matrixCenterY; y++)
            {
                for (int x = matrixCenterX; x < image.Width - matrixCenterX; x++)
                {
                    Color centerPixel = image.GetPixel(x, y);

                    for (int ky = 0; ky < kernel.GetLength(0); ky++)
                    {
                        for (int kx = 0; kx < kernel.GetLength(1); kx++)
                        {
                            int posX = x + kx - matrixCenterX;
                            int posY = y + ky - matrixCenterY;
                            if (posX >= 0 && posX < image.Width && posY >= 0 && posY < image.Height)
                            {
                                Color neighborPixel = image.GetPixel(posX, posY);
                                if (centerPixel.R == 255 && neighborPixel.R == 255)
                                {
                                    newImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                }

                                else
                                {
                                    newImage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                }
                            }
                        }
                    }
                }
            }

            return newImage;
        }

    }
}

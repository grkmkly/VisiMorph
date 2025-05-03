using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class SaltPepper
    {
        public static Bitmap saltpepperNoise(Bitmap image, int noiseRatio, int saltRatio)
        {
            int width = image.Width;
            int height = image.Height;

            int totalnoisedPixel = (width * height) * noiseRatio / 100;
            int totalwhitePixel = totalnoisedPixel * saltRatio / 100;
            int totalblackPixel = totalnoisedPixel * (100 - saltRatio) / 100;

            Random random = new Random();

            // Salt (white) uygulanması
            for (int s = 0; s < totalwhitePixel; s++)
            {
                int imageX = random.Next(width);
                int imageY = random.Next(height);
                image.SetPixel(imageX, imageY, Color.White);
            }

            // Pepper (black) uygulanması
            for (int p = 0; p < totalblackPixel; p++)
            {
                int imageX = random.Next(width);
                int imageY = random.Next(height);
                image.SetPixel(imageX, imageY, Color.Black);
            }

            return image;
        }
    }
}

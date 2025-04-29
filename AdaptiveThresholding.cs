using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class AdaptiveThresholding
    {
        public static Bitmap adaptivethresholdingMean(Bitmap image, int wsize)
        {
            int windowsize = wsize;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int count = 0;
                    int sum = 0;
                    for (int wy = -(windowsize / 2); wy <= windowsize / 2; wy++)
                    {
                        for (int wx = -(windowsize / 2); wx <= windowsize / 2; wx++)
                        {
                            int currentX = x + wx;
                            int currentY = y + wy;
                            if (currentX >= 0 && currentX < image.Width && currentY >= 0 && currentY < image.Height)
                            {
                                Color windowPixel = image.GetPixel(currentX, currentY);
                                sum += windowPixel.R;
                                count++;
                            }
                        }
                    }

                    int thresholdMean = sum / count;
                    Color currentPixel = image.GetPixel(x, y);
                    int newPixelValue = currentPixel.R > thresholdMean ? 255 : 0;
                    Color newPixel = Color.FromArgb(newPixelValue, newPixelValue, newPixelValue);
                    image.SetPixel(x, y, newPixel);
                }
            }

            return image;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class Filters
    {
        public static Bitmap meanFilter(Bitmap image, int msize)
        {
            int windowsize = msize;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int count = 0;
                    int R_sum = 0;
                    int G_sum = 0;
                    int B_sum = 0;

                    for (int wy = -(windowsize / 2); wy <= windowsize / 2; wy++)
                    {
                        for (int wx = -(windowsize / 2); wx <= windowsize / 2; wx++)
                        {
                            int currentX = x + wx;
                            int currentY = y + wy;
                            if (currentX >= 0 && currentX < image.Width && currentY >= 0 && currentY < image.Height)
                            {
                                Color windowPixel = image.GetPixel(currentX, currentY);
                                R_sum += windowPixel.R;
                                G_sum += windowPixel.G;
                                B_sum += windowPixel.B;
                                count++;
                            }
                        }
                    }

                    Color currentPixel = image.GetPixel(x, y);

                    Color newPixel = Color.FromArgb(R_sum/count, G_sum/count, B_sum/count);
                    image.SetPixel(x, y, newPixel);
                }
            }

            return image;
        }


        public static Bitmap medianFilter(Bitmap image, int msize)
        {
            int windowsize = msize;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    List<int> R_values = new List<int>();
                    List<int> G_values = new List<int>();
                    List<int> B_values = new List<int>();

                    for (int wy = -(windowsize / 2); wy <= windowsize / 2; wy++)
                    {
                        for (int wx = -(windowsize / 2); wx <= windowsize / 2; wx++)
                        {
                            int currentX = x + wx;
                            int currentY = y + wy;
                            if (currentX >= 0 && currentX < image.Width && currentY >= 0 && currentY < image.Height)
                            {
                                Color windowPixel = image.GetPixel(currentX, currentY);
                                R_values.Add(windowPixel.R);
                                G_values.Add(windowPixel.G);
                                B_values.Add(windowPixel.B);
                            }
                        }
                    }

                    Color currentPixel = image.GetPixel(x, y);

                    int new_R, new_G, new_B;

                    R_values.Sort();
                    G_values.Sort();
                    B_values.Sort();

                    if (R_values.Count % 2 != 0)
                    {
                        new_R = R_values[R_values.Count / 2];
                        new_G = G_values[G_values.Count / 2];
                        new_B = B_values[B_values.Count / 2];
                    }
                    else
                    {
                        int midIndex = R_values.Count / 2;
                        new_R = (R_values[midIndex - 1] + R_values[midIndex]) / 2;
                        new_G = (G_values[midIndex - 1] + G_values[midIndex]) / 2;
                        new_B = (B_values[midIndex - 1] + B_values[midIndex]) / 2;
                    }

                    Color newPixel = Color.FromArgb(new_R, new_G, new_B);

                    image.SetPixel(x, y, newPixel);
                }
            }

            return image;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class GeometricOperations
    {
        public static Bitmap ImageRotate(Bitmap image, double radius)
        {
            Bitmap returnImage = new Bitmap(image.Width, image.Height);
            
            double radyan = radius * Math.PI / 180;


            int xCenter = image.Width / 2;
            int yCenter = image.Height / 2;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);

                    double xOffset = x - xCenter;
                    double yOffset = y - yCenter;
                    double tempX = (int)(Math.Cos( -1 *radyan) * (xOffset) - Math.Sin(-1 * radyan) * (yOffset) + xCenter);
                    double tempY = (int)(Math.Sin(-1 *radyan) * (xOffset) + Math.Cos(-1 * radyan) * (yOffset) + yCenter);


                    if (tempX >= 0 && tempX < image.Width && tempY >= 0 && tempY < image.Height)
                    {
                        color = BilinearInterpolation(image, tempX, tempY);
                    }
                    else
                    {
                        color = Color.Black;
                    }
                    returnImage.SetPixel(x, y, color);

                }
            }
            return returnImage;
        }
        public static (int,int) NearestNeighborInterpolation(double x, double y)
        {
            int returnX = 0;
            int returnY = 0;

            returnX = (int)Math.Round(x);
            returnY = (int)Math.Round(y);

            return (returnX, returnY);
        }
        public static Color BilinearInterpolation(Bitmap image,double tempX,double tempY)
        {
            int returnX = 0;
            int returnY = 0;

            Point point0 = new Point((int)Math.Floor(tempX),(int)Math.Floor(tempY));
            Point point1 = new Point((int)Math.Ceiling(tempX), (int)Math.Floor(tempY));
            Point point2 = new Point((int)Math.Floor(tempX), (int)Math.Ceiling(tempY));
            Point point3 = new Point((int)Math.Ceiling(tempX), (int)Math.Ceiling(tempY));

            double dx = tempX - point0.X;
            double dy = tempY - point0.Y;


           int red = (int)(image.GetPixel(point0.X, point0.Y).R * (1 - dx) * (1 - dy) + image.GetPixel(point1.X, point1.Y).R * dx * (1 - dy) + image.GetPixel(point2.X, point2.Y).R * (1 - dx) * dy + image.GetPixel(point3.X, point3.Y).R * dx * dy);
           int green = (int)(image.GetPixel(point0.X, point0.Y).G * (1 - dx) * (1 - dy) + image.GetPixel(point1.X, point1.Y).G * dx * (1 - dy) + image.GetPixel(point2.X, point2.Y).G * (1 - dx) * dy + image.GetPixel(point3.X, point3.Y).G * dx * dy);
           int blue = (int)(image.GetPixel(point0.X, point0.Y).B * (1 - dx) * (1 - dy) + image.GetPixel(point1.X, point1.Y).B * dx * (1 - dy) + image.GetPixel(point2.X, point2.Y).B * (1 - dx) * dy + image.GetPixel(point3.X, point3.Y).B * dx * dy);

            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            if (tempX < 0 || tempY < 0 || tempX >= image.Width - 1 || tempY >= image.Height - 1)
            {
                return Color.Black; // veya başka bir default değer
            }

            return Color.FromArgb(red, green, blue);
        }
    }
}

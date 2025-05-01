using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    internal class GeometricOperations
    {
        public static Size newImageSize(Bitmap image) { 
            return CalculateNewDimensions(image.Width,image.Height,45);
        }
        public static Size CalculateNewDimensions(int originalWidth, int originalHeight, double degrees)
        {
            double angleRad = degrees * Math.PI / 180.0;
            double cos = Math.Cos(angleRad);
            double sin = Math.Sin(angleRad);

            int newWidth = (int)Math.Ceiling((originalWidth * cos) + (originalHeight * sin));
            int newHeight = (int)Math.Ceiling((originalWidth * sin) + (originalHeight * cos));

            return new Size(newWidth, newHeight);
        }

        public static Bitmap ImageRotate(Bitmap image, double degrees) // Arka plan rengi parametresi ekledim
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (degrees % 360 == 0) return new Bitmap(image); // Orijinalin kopyasını döndür

            Size newSize = CalculateNewDimensions(image.Width, image.Height, degrees);
            // SetPixel ile uyumlu bir format kullanmak daha güvenli olabilir:
            Bitmap returnImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
            returnImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            double radyan = degrees * Math.PI / 180.0;
            // Sinüs ve kosinüsü döngü dışında hesapla (performans için)
            double cosTheta = Math.Cos(radyan); // Not: Ters dönüşüm için -radyan kullanacağız
            double sinTheta = Math.Sin(radyan); // Veya formülde işaretleri ayarlayacağız

            float origXCenter = (float)image.Width / 2f;
            float origYCenter = (float)image.Height / 2f;
            float newXCenter = (float)returnImage.Width / 2f;
            float newYCenter = (float)returnImage.Height / 2f;

            for (int y = 0; y < returnImage.Height; y++)
            {
                for (int x = 0; x < returnImage.Width; x++)
                {
                    Color color;

                    // 1. Hedef pikselin YENİ merkeze göre ofsetini bul
                    double xOffsetNew = x - newXCenter;
                    double yOffsetNew = y - newYCenter;

                    // 2. Ters dönüşümle ORİJİNAL merkeze göre ofseti bul
                    //    Formül: x_orig = cos(theta)*x_new + sin(theta)*y_new
                    //            y_orig = -sin(theta)*x_new + cos(theta)*y_new
                    //    (Not: Bu, (x_new, y_new) noktasını GERİ döndürür)
                    //    !!! (int) KALDIRILDI !!!
                    double xOffsetOrig = cosTheta * xOffsetNew + sinTheta * yOffsetNew;
                    double yOffsetOrig = -sinTheta * xOffsetNew + cosTheta * yOffsetNew;

                    // 3. ORİJİNAL resimdeki MUTLAK kaynak koordinatını bul
                    double sourceX = xOffsetOrig + origXCenter;
                    double sourceY = yOffsetOrig + origYCenter;

                    // 4. Sınır kontrolünü MUTLAK kaynak koordinatları (sourceX, sourceY) ile yap
                    //    !!! KOŞUL DEĞİŞTİ !!!
                    if (sourceX >= 0 && sourceX < image.Width && sourceY >= 0 && sourceY < image.Height)
                    {
                        // 5. İnterpolasyonu MUTLAK kaynak koordinatları (sourceX, sourceY) ile yap
                        //    !!! PARAMETRELER DEĞİŞTİ !!!
                        color = NearestNeighborInterpolation(image, sourceX, sourceY);
                    }
                    else
                    {
                        // Sınır dışıysa belirlenen arka plan rengini kullan
                        color = Color.Transparent;
                    }

                    // SetPixel işlemi (PixelFormat uyumluysa çalışır)
                    returnImage.SetPixel(x, y, color);
                }
            }
            return returnImage;
        }
        public static Color NearestNeighborInterpolation( Bitmap image,double x, double y)
        {
            int returnX = 0;
            int returnY = 0;

            returnX = (int)Math.Round(x);
            returnY = (int)Math.Round(y);

            if (returnX < 0 || returnX >= image.Width || returnY < 0 || returnY >= image.Height)
                return Color.Transparent;
            return image.GetPixel(returnX, returnY);
        }
        public static Color BilinearInterpolation(Bitmap image, double tempX, double tempY)
        {

            Point point0 = new Point((int)Math.Floor(tempX), (int)Math.Floor(tempY));
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

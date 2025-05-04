using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiMorph
{
    class ArithmeticTransforms
    {

        public static Bitmap AddImage(Bitmap _firstImage, Bitmap _secondImage)
        {
            if(!(_firstImage.Width == _secondImage.Width && _firstImage.Height == _secondImage.Height))
            {
                if (_firstImage.Width > _secondImage.Width || _firstImage.Height > _secondImage.Height)
                {

                    _secondImage = new Bitmap(_secondImage, new Size(_firstImage.Width, _firstImage.Height));
                    MessageBox.Show("İkinci resim birinci resime uygun olarak boyutlandırıldı.");
                }
                else
                {
                    _firstImage = new Bitmap(_firstImage, new Size(_secondImage.Width, _secondImage.Height));
                    MessageBox.Show("Birinci resim ikinci resime uygun olarak boyutlandırıldı.");
                }

            }
            Bitmap newImage = new Bitmap(_firstImage.Width, _firstImage.Height);
            for (int y = 0; y < _firstImage.Height; y++)
            {
                for (int x = 0; x < _firstImage.Width; x++)
                {
                    Color firstPixel = _firstImage.GetPixel(x, y);
                    Color secondPixel = _secondImage.GetPixel(x, y);
                    int red = Math.Min(firstPixel.R + secondPixel.R, 255);
                    int green = Math.Min(firstPixel.G + secondPixel.G, 255);
                    int blue = Math.Min(firstPixel.B + secondPixel.B, 255);
                    newImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            return newImage;
        }

        public static Bitmap MultiplyImage(Bitmap _firstImage, Bitmap _secondImage)
        {
            if (!(_firstImage.Width == _secondImage.Width && _firstImage.Height == _secondImage.Height))
            {
                if (_firstImage.Width > _secondImage.Width || _firstImage.Height > _secondImage.Height)
                {

                    _secondImage = new Bitmap(_secondImage, new Size(_firstImage.Width, _firstImage.Height));
                    MessageBox.Show("İkinci resim birinci resime uygun olarak boyutlandırıldı.");
                }
                else
                {
                    _firstImage = new Bitmap(_firstImage, new Size(_secondImage.Width, _secondImage.Height));
                    MessageBox.Show("Birinci resim ikinci resime uygun olarak boyutlandırıldı.");
                }

            }
            Bitmap newImage = new Bitmap(_firstImage.Width, _firstImage.Height);
            for (int y = 0; y < _firstImage.Height; y++)
            {
                for (int x = 0; x < _firstImage.Width; x++)
                {
                    Color firstPixel = _firstImage.GetPixel(x, y);
                    Color secondPixel = _secondImage.GetPixel(x, y);
                    int red = Math.Max(firstPixel.R * secondPixel.R, 0);
                    int green = Math.Max(firstPixel.G * secondPixel.G, 0);
                    int blue = Math.Max(firstPixel.B * secondPixel.B, 0);
                    red = Math.Clamp(red, 0, 255);
                    green = Math.Clamp(green, 0, 255);
                    blue = Math.Clamp(blue, 0, 255);
                    newImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            return newImage;

        }
        public static Bitmap CropImage(Image image, Rectangle cropRect, Size displaySize)
        {
            if (image == null || cropRect.Width <= 0 || cropRect.Height <= 0)
                return null;

            Bitmap source = new Bitmap(image);

            float scaleX = (float)source.Width / displaySize.Width;
            float scaleY = (float)source.Height / displaySize.Height;

            int cropX = (int)(cropRect.X * scaleX);
            int cropY = (int)(cropRect.Y * scaleY);
            int cropWidth = (int)(cropRect.Width * scaleX);
            int cropHeight = (int)(cropRect.Height * scaleY);

            if (cropX < 0) cropX = 0;
            if (cropY < 0) cropY = 0;
            if (cropX + cropWidth > source.Width)
                cropWidth = source.Width - cropX;
            if (cropY + cropHeight > source.Height)
                cropHeight = source.Height - cropY;

            Bitmap cropped = new Bitmap(cropWidth, cropHeight);

            for (int y = 0; y < cropHeight; y++)
            {
                for (int x = 0; x < cropWidth; x++)
                {
                    Color pixel = source.GetPixel(cropX + x, cropY + y);
                    cropped.SetPixel(x, y, pixel);
                }
            }

            return cropped;
        }



    }
}

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


    }
}

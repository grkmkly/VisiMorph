using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace VisiMorph
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
        }

        private PictureBox imageBox = new PictureBox();
        private Bitmap image;
        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPictureBoxInPanel();
        }
        private void CenterPictureBoxInPanel()
        {
            // Eðer pictureBox veya appPanel henüz oluþturulmadýysa iþlem yapma
            if (imageBox == null || appPanel == null || imageBox.Image == null)
                return;

            // PictureBox'ý panel içinde ortala
            int x = Math.Max(0, (appPanel.ClientSize.Width - imageBox.Width) / 2);
            int y = Math.Max(0, (appPanel.ClientSize.Height - imageBox.Height) / 2);
            imageBox.Location = new Point(x, y);
        }
        private void fileopenButton_Click(object sender, EventArgs e)
        {
            appPanel.Controls.Clear();
            imageopenFileDialog.Title = "Bir görüntü dosyası seçiniz.";
            imageopenFileDialog.Filter = "Görüntü dosyaları|*.bmp; *.png; *.jpeg; *.jpg";

            if (imageopenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string imagePath = imageopenFileDialog.FileName;
                image = new Bitmap(imagePath);

                imageBox.Image = image;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                imageBox.Width = image.Width;
                imageBox.Height = image.Height;
                CenterPictureBoxInPanel();

                appPanel.Controls.Add(imageBox);
            };

        }

        private void filecloseButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Herhangi bir görsel yüklenmedi, işlem başarısız.");
            }

            else
            {
                image = null;
                imageBox.Image = null;
            }
        }

        private void filesaveButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Herhangi bir resim açmadınız.");
                return;
            }

            imagesaveFileDialog.Title = "Görüntü dosyasının kaydedileceği dizini seçiniz.";
            imagesaveFileDialog.DefaultExt = "jpeg";
            imagesaveFileDialog.AddExtension = true;
            imagesaveFileDialog.Filter = "BMP Dosyası (*.bmp)|*.bmp|PNG Dosyası (*.png)|*.png|JPEG Dosyası (*.jpeg)|*.jpeg|JPG Dosyası (*.jpg)|*.jpg";


            if (imagesaveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string savePath = imagesaveFileDialog.FileName;
                ImageFormat format = ImageFormat.Jpeg;

                string extension = Path.GetExtension(savePath).ToLower();
                if (extension == ".png")
                {
                    format = ImageFormat.Png;
                }

                else if (extension == ".bmp")
                {
                    format = ImageFormat.Bmp;
                }

                else if (extension == ".jpg")
                {
                    format = ImageFormat.Jpeg;
                }

                image.Save(savePath, format);
                MessageBox.Show("Resim başarıyla kaydedildi.");
            }
        }

        private void graytransformationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                image = ImageFunctions.grayTransformation(image);
                imageBox.Image = image;
            }
        }

        private void binarytransformationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                int threshold = 0;
                ThresholdTrackBar thresholdTrackBar = new ThresholdTrackBar();
                if (thresholdTrackBar.ShowDialog() == DialogResult.OK)
                {
                    threshold = thresholdTrackBar.trackbarValue;
                }
                image = ImageFunctions.binaryTransformation(image, threshold);
                imageBox.Image = image;
            }
        }
        private void adaptiveButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                int windowSize = 0;
                AdaptiveThresholdingForm adaptiveThresholdingForm = new AdaptiveThresholdingForm();
                if (adaptiveThresholdingForm.ShowDialog() == DialogResult.OK)
                {
                    windowSize = adaptiveThresholdingForm.windowMatrixSize;
                }
                image = AdaptiveThresholding.adaptivethresholdingMean(image, windowSize);
                imageBox.Image = image;
            }
        }
        private void RGBtoHSVButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                double new_H;
                double new_S;
                double new_V;
                RGBtoHSVTrackBar RGBtoHSVForm = new RGBtoHSVTrackBar();
                if (RGBtoHSVForm.ShowDialog() == DialogResult.OK)
                {
                    new_H = RGBtoHSVForm.H;
                    new_S = RGBtoHSVForm.S;
                    new_V = RGBtoHSVForm.V;
                    image = ImageFunctions.imageRGBtoHSV(image, new_H, new_S, new_V);
                    imageBox.Image = image;
                }
            }

        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                int brightness = 0;
                BrightnessTrackBar brightnessTrackBar = new BrightnessTrackBar();
                if (brightnessTrackBar.ShowDialog() == DialogResult.OK)
                {
                    brightness = brightnessTrackBar.trackbarValue;
                }
                image = ImageFunctions.brightnessTransformation(image, brightness);
                imageBox.Image = image;
            }
        }

        private void imagehistogramButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                Histogram histogramChart = new Histogram(image);
                histogramChart.ShowDialog();

                if (histogramChart.DialogResult == DialogResult.OK)
                {
                    image = histogramChart.resultImage;
                    imageBox.Image = image;
                }

            }
        }

        private void dilationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageDilation(image, kernel);
                    image = newImage;
                    imageBox.Image = image;
                }
            }
        }

        private void erosionButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageErosion(image, kernel);
                    image = newImage;
                    imageBox.Image = image;
                }

            }
        }

        private void openingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageErosion(image, kernel);
                    image = Morphology.imageDilation(newImage, kernel);
                    imageBox.Image = image;
                }
            }
        }

        private void closingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageDilation(image, kernel);
                    image = Morphology.imageErosion(newImage, kernel);
                    imageBox.Image = image;
                }
            }
        }

        private void convolutionButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                double[,] gaussFilter = ImageFunctions.GaussianFilter(1, 3);
                //image = ImageFunctions.Convolution(image, gaussFilter, true);
                image = ImageFunctions.Convolution(image, gaussFilter, false);
                imageBox.Image = image;
            }
        }

        private void addimageButton_Click(object sender, EventArgs e)
        {

            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                Bitmap image = this.image;
                appPanel.Controls.Clear();
                imageopenFileDialog.Title = "Bir görüntü dosyası seçiniz.";
                imageopenFileDialog.Filter = "Görüntü dosyaları|*.bmp; *.png; *.jpeg";
                if (imageopenFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string imagePath = imageopenFileDialog.FileName;
                    Bitmap secondImage = new Bitmap(imagePath);
                    image = ArithmeticTransforms.AddImage(image, secondImage);
                    imageBox.Image = image;
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    imageBox.Width = image.Width;
                    imageBox.Height = image.Height;
                    CenterPictureBoxInPanel();
                    appPanel.Controls.Add(imageBox);
                }
            }

        }

        private void sobelButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                image = Sobel.sobelEdgeAlgoritm(image);
                imageBox.Image = image;
            }
        }

        private void multiplyimageButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                Bitmap image = this.image;
                appPanel.Controls.Clear();
                imageopenFileDialog.Title = "Bir görüntü dosyası seçiniz.";
                imageopenFileDialog.Filter = "Görüntü dosyalarý|*.bmp; *.png; *.jpeg";
                if (imageopenFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string imagePath = imageopenFileDialog.FileName;
                    Bitmap secondImage = new Bitmap(imagePath);
                    image = ArithmeticTransforms.MultiplyImage(image, secondImage);
                    imageBox.Image = image;
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    imageBox.Width = image.Width;
                    imageBox.Height = image.Height;
                    CenterPictureBoxInPanel();
                    appPanel.Controls.Add(imageBox);
                }
            }

        }

        private void meanfilterButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                image = Filters.meanFilter(image, 5);
                imageBox.Image = image;
            }
        }

        private void medianfilterButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                image = Filters.medianFilter(image, 5);
                imageBox.Image = image;
            }
        }

        private void saltpepperButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                SaltPepperForm saltpepperForm = new SaltPepperForm();
                saltpepperForm.ShowDialog();

                if (saltpepperForm.DialogResult == DialogResult.OK)
                {
                    image = SaltPepper.saltpepperNoise(image, saltpepperForm.totalNoiseRatioValue, saltpepperForm.saltRatioValue);
                    imageBox.Image = image;
                }
            }
        }

        private void imagerotationButton_Click(object sender, EventArgs e)
        {
            Bitmap newImage = GeometricOperations.ImageRotate(image, 90);
            image = newImage;
            imageBox.Image = image;

        }
    }
}

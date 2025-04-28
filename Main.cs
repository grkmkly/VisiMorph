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
            // E�er pictureBox veya appPanel hen�z olu�turulmad�ysa i�lem yapma
            if (imageBox == null || appPanel == null || imageBox.Image == null)
                return;

            // PictureBox'� panel i�inde ortala
            int x = Math.Max(0, (appPanel.ClientSize.Width - imageBox.Width) / 2);
            int y = Math.Max(0, (appPanel.ClientSize.Height - imageBox.Height) / 2);
            imageBox.Location = new Point(x, y);
        }
        private void fileopenButton_Click(object sender, EventArgs e)
        {
            appPanel.Controls.Clear();
            imageopenFileDialog.Title = "Bir g�r�nt� dosyas� se�iniz.";
            imageopenFileDialog.Filter = "G�r�nt� dosyalar�|*.bmp; *.png; *.jpeg";

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
                MessageBox.Show("Herhangi bir g�rsel y�klenmedi, i�lem ba�ar�s�z.");
            }

            else
            {
                image.Dispose();
                imageBox.Image = null;
            }
        }

        private void filesaveButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Herhangi bir resim a�mad�n�z.");
                return;
            }

            imagesaveFileDialog.Title = "G�r�nt� dosyas�n�n kaydedilece�i dizini se�iniz.";
            imagesaveFileDialog.DefaultExt = "jpeg";
            imagesaveFileDialog.AddExtension = true;
            imagesaveFileDialog.Filter = "G�r�nt� dosyalar�|*.bmp; *.png; *.jpeg";


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

                image.Save(savePath, format);
                MessageBox.Show("Resim ba�ar�yla kaydedildi.");
            }
        }

        private void graytransformationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
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
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                int threshold = 0;
                ThresholdTrackBar thresholdTrackBar = new ThresholdTrackBar();
                if (thresholdTrackBar.ShowDialog() == DialogResult.OK)
                {
                    threshold = thresholdTrackBar.trackbarValue;
                }
                imageBox.Image = ImageFunctions.binaryTransformation(image, threshold);
            }
        }
        private void adaptiveButton_Click(object sender, EventArgs e)
        {

        }
        private void RGBtoHSVButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
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
                    imageBox.Image = ImageFunctions.imageRGBtoHSV(image, new_H, new_S, new_V); ;
                }
            }

        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                int brightness = 0;
                BrightnessTrackBar brightnessTrackBar = new BrightnessTrackBar();
                if (brightnessTrackBar.ShowDialog() == DialogResult.OK)
                {
                    brightness = brightnessTrackBar.trackbarValue;
                }

                imageBox.Image = ImageFunctions.brightnessTransformation(image, brightness);
            }
        }

        private void imagehistogramButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
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
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.ShowDialog();

                int[,] kernel = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
                Bitmap newImage = Morphology.imageDilation(image, kernel);
                imageBox.Image = newImage;
            }
        }

        private void erosionButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                int[,] kernel = { { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
                Bitmap newImage = Morphology.imageErosion(image, kernel);
                imageBox.Image = newImage;

            }
        }

        private void openingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                int[,] kernel = { { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
                Bitmap newImage = Morphology.imageErosion(image, kernel);
                newImage = Morphology.imageDilation(newImage, kernel);
                imageBox.Image = newImage;
            }
        }

        private void closingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Hen�z bir resim y�klemediniz, i�lem ba�ar�s�z.");
            }

            else
            {
                int[,] kernel = { { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
                Bitmap newImage = Morphology.imageDilation(image, kernel);
                newImage = Morphology.imageErosion(newImage, kernel);
                imageBox.Image = newImage;
            }
        }
    }
}

using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private PictureBox imageBox = new PictureBox();
        private Bitmap image;
        public Bitmap _originalImage;
        private Size newSize;
        bool zoomModeActive;
        bool returnModeActive;
        private List<Bitmap> zoomedImageList = new List<Bitmap>();
        private int prevVal;
        private int brightness;
        bool brightnessModeActive;



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


        //private void fileopenButton_Click(object sender, EventArgs e)
        //{
        //    if (appPanel.Controls.Contains(imageBox))
        //    {
        //        appPanel.Controls.Remove(imageBox);
        //    }
        //    imageopenFileDialog.Title = "Bir görüntü dosyası seçiniz.";
        //    imageopenFileDialog.Filter = "Görüntü dosyaları|*.bmp; *.png; *.jpeg; *.jpg";

        //    if (imageopenFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string imagePath = imageopenFileDialog.FileName;
        //        image = new Bitmap(imagePath);
        //        originalImage = new Bitmap(imagePath);


        //        imageBox.Image = image;
        //        imageBox.SizeMode = PictureBoxSizeMode.Normal;
        //        imageBox.Width = image.Width;
        //        imageBox.Height = image.Height;
        //        CenterPictureBoxInPanel();

        //        appPanel.Controls.Add(imageBox);
        //        isImageRotated = false;
        //    }

        //}

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

        //private void filesaveButton_Click(object sender, EventArgs e)
        //{
        //    if (image == null)
        //    {
        //        MessageBox.Show("Herhangi bir resim açmadınız.");
        //        return;
        //    }

        //    imagesaveFileDialog.Title = "Görüntü dosyasının kaydedileceği dizini seçiniz.";
        //    imagesaveFileDialog.DefaultExt = "jpeg";
        //    imagesaveFileDialog.AddExtension = true;
        //    imagesaveFileDialog.Filter = "BMP Dosyası (*.bmp)|*.bmp|PNG Dosyası (*.png)|*.png|JPEG Dosyası (*.jpeg)|*.jpeg|JPG Dosyası (*.jpg)|*.jpg";


        //    if (imagesaveFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string savePath = imagesaveFileDialog.FileName;
        //        ImageFormat format = ImageFormat.Jpeg;

        //        string extension = Path.GetExtension(savePath).ToLower();
        //        if (extension == ".png")
        //        {
        //            format = ImageFormat.Png;
        //        }

        //        else if (extension == ".bmp")
        //        {
        //            format = ImageFormat.Bmp;
        //        }

        //        else if (extension == ".jpg")
        //        {
        //            format = ImageFormat.Jpeg;
        //        }

        //        image.Save(savePath, format);
        //        MessageBox.Show("Resim başarıyla kaydedildi.");
        //    }
        //}

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
            //if (image == null)
            //{
            //    MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            //}

            //else
            //{
            //    int windowSize = 0;
            //    AdaptiveThresholdingForm adaptiveThresholdingForm = new AdaptiveThresholdingForm();
            //    if (adaptiveThresholdingForm.ShowDialog() == DialogResult.OK)
            //    {
            //        windowSize = adaptiveThresholdingForm.windowMatrixSize;
            //    }
            //    image = AdaptiveThresholding.adaptivethresholdingMean(image, windowSize);
            //    imageBox.Image = image;
            //}
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
                return;
            }
            brightnessModeActive = !brightnessModeActive;
            if (brightnessModeActive)
            {
                panel1.Visible = !panel1.Visible;
                brightnessButton.BackColor = panel1.Visible ? Color.LightGray : Color.Transparent;
                panel1.Dock = DockStyle.Left;
                panel1.BringToFront();
                brightnessTrack.Value = 0;
                if (panel1.Visible)
                {

                    brightnessTrack.Minimum = -255;
                    brightnessTrack.Maximum = 255;
                    brightnessTrack.TickFrequency = 1;
                    brightnessTrack.LargeChange = 1;
                    brightnessTrack.SmallChange = 1;

                    // Olayı tekrar tekrar eklememek için önce çıkar, sonra ekle
                    brightnessTrack.MouseUp -= BrightnessTrack_Scroll;
                    brightnessTrack.MouseUp += BrightnessTrack_Scroll;
                }
                else
                {
                    _originalImage = image;
                    imageBox.Image = _originalImage;
                    brightnessTrack.Value = 0;
                    brightnessLabel.Text = "Seçili Değer: 0";

                }
            }
            else
            {
                image = (Bitmap)imageBox.Image;
                _originalImage = image;
            }

            
        }


        //private void imagehistogramButton_Click(object sender, EventArgs e)
        //{
        //    if (image == null)
        //    {
        //        MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
        //    }

        //    else
        //    {
        //        Histogram histogramChart = new Histogram(image);
        //        histogramChart.ShowDialog();

        //        if (histogramChart.DialogResult == DialogResult.OK)
        //        {
        //            image = histogramChart.resultImage;
        //            imageBox.Image = image;
        //        }

        //    }
        //}

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
                GaussForm gaussForm = new GaussForm();
                if (gaussForm.ShowDialog(this) == DialogResult.OK)
                {
                    int gaussMatrixSize = gaussForm.gaussMatrixSize;
                    bool isEdgeFill = gaussForm.fillEdge;
                    float sigmaValue = gaussForm.sigma;
                    double[,] gaussFilter = ImageFunctions.GaussianFilter(sigmaValue, gaussMatrixSize);
                    image = ImageFunctions.Convolution(image, gaussFilter, isEdgeFill);
                    imageBox.Image = image;
                }
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

        private void meanfilterButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                FilterForm filterForm = new FilterForm();
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    int matrixSize = filterForm.filterMatrixSize;
                    image = Filters.medianFilter(image, matrixSize);
                    imageBox.Image = image;
                }
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
                FilterForm filterForm = new FilterForm();
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    int matrixSize = filterForm.filterMatrixSize;
                    image = Filters.medianFilter(image, matrixSize);
                    imageBox.Image = image;
                }

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

                if (saltpepperForm.ShowDialog(this) == DialogResult.OK)
                {
                    image = SaltPepper.saltpepperNoise(image, saltpepperForm.totalNoiseRatioValue, saltpepperForm.saltRatioValue);
                    imageBox.Image = image;
                }
            }
        }
        bool isImageRotated = false;

        private void imagerotationButton_Click(object sender, EventArgs e)
        {
            //if (image == null)
            //{
            //    MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            //}
            //else
            //{
            //    ImageRotationForm imageRotationForm = new ImageRotationForm();

            //    if (imageRotationForm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        int rotateDegree = imageRotationForm.degreeValue;
            //        if (!isImageRotated)
            //        {
            //            GeometricOperations.OriginalImage(image);
            //            isImageRotated = true;
            //        }
            //        Bitmap newImage = GeometricOperations.ImageRotate(GeometricOperations.originalImage, rotateDegree, GeometricOperations.originalImage.Size);
            //        image = new Bitmap(newImage);
            //        image = newImage;
            //        imageBox.Size = image.Size;
            //        imageBox.Image = image;
            //        CenterPictureBoxInPanel();
            //    }
            //}
        }

        private void blurringButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                FilterForm filterForm = new FilterForm();
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    int matrixSize = filterForm.filterMatrixSize;
                    int[,] blurringMatrix = Filters.createBlurringMatrix(matrixSize);
                    image = Filters.blurringFilter(image, blurringMatrix);
                    imageBox.Image = image;
                }

            }

        }

        private void imageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!zoomModeActive || image == null || !returnModeActive)
                return;

            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.WaitCursor;
                Bitmap tempImage = new Bitmap(imageBox.Image);
                //Yakınlaştırma
                float scaleX = (float)tempImage.Width / imageBox.Width;
                float scaleY = (float)tempImage.Height / imageBox.Height;

                int realX = (int)(e.X * scaleX);
                int realY = (int)(e.Y * scaleY);

                float zoomFactor = 2.0f;
                int zoomWidth = (int)(tempImage.Width / zoomFactor);
                int zoomHeight = (int)(tempImage.Height / zoomFactor);

                int startX = realX - zoomWidth / 2;
                int startY = realY - zoomHeight / 2;

                if (startX < 0) startX = 0;
                if (startY < 0) startY = 0;
                if (startX + zoomWidth > tempImage.Width) startX = tempImage.Width - zoomWidth;
                if (startY + zoomHeight > tempImage.Height) startY = tempImage.Height - zoomHeight;

                Rectangle zoomRect = new Rectangle(startX, startY, zoomWidth, zoomHeight);

                Bitmap zoomed = GeometricOperations.zoomImage(tempImage, zoomRect, imageBox.Size);
                zoomedImageList.Add(zoomed);
                imageBox.Image = zoomed;
                imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (zoomedImageList.Count == 0 || zoomedImageList.Count == 1)
                {
                    imageBox.Image = image;
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    CenterPictureBoxInPanel();
                    zoomedImageList.Clear();
                    return;
                }
                else
                {
                    imageBox.Image = zoomedImageList[zoomedImageList.Count - 2];
                    zoomedImageList.RemoveAt(zoomedImageList.Count - 2);
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    CenterPictureBoxInPanel();
                }

            }

            this.Cursor = Cursors.Cross;
        }

        private void magnifyingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            zoomModeActive = !zoomModeActive;
            returnModeActive = !returnModeActive;
            if (!zoomModeActive)
            {
                // Büyültme modu kapatıldı
                magnifyingButton.BackColor = Color.Transparent;
                image = (Bitmap)imageBox.Image;
                _originalImage = image;
                zoomedImageList.Clear();
            }

            if (zoomModeActive && returnModeActive)
            {
                // Büyültme modu açıldı
                this.Cursor = Cursors.Cross;
                magnifyingButton.BackColor = Color.LightGray;
                imageBox.Image = image;
                imageBox.MouseClick -= imageBox_MouseClick;
                imageBox.MouseClick += imageBox_MouseClick;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                ImageRotationForm imageRotationForm = new ImageRotationForm();

                if (imageRotationForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int rotateDegree = imageRotationForm.degreeValue;
                    if (!isImageRotated)
                    {
                        GeometricOperations.OriginalImage(image);
                        isImageRotated = true;
                    }
                    Bitmap newImage = GeometricOperations.ImageRotate(GeometricOperations.originalImage, rotateDegree, GeometricOperations.originalImage.Size);
                    image = new Bitmap(newImage);
                    image = newImage;
                    imageBox.Size = image.Size;
                    imageBox.Image = image;
                    CenterPictureBoxInPanel();
                    this.Cursor = Cursors.Default;
                }
            }

        }



        private void BrightnessTrack_Scroll(object? sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                brightnessLabel.Text = $"Seçili Değer: {brightnessTrack.Value}";
                brightness = brightnessTrack.Value;
                imageBox.Image = ImageFunctions.brightnessTransformation(_originalImage, brightness);
                prevVal = brightnessTrack.Value;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void histogramButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                Histogram histogramChart = new Histogram(image);
                histogramChart.StartPosition = FormStartPosition.CenterParent;
                histogramChart.ShowDialog();

                if (histogramChart.DialogResult == DialogResult.OK)
                {
                    image = histogramChart.resultImage;
                    imageBox.Image = image;
                }

            }
        }


        

        private void newFileButton_Click(object sender, EventArgs e)
        {
            if (appPanel.Controls.Contains(imageBox))
            {
                appPanel.Controls.Remove(imageBox);
            }
            imageopenFileDialog.Title = "Bir görüntü dosyası seçiniz.";
            imageopenFileDialog.Filter = "Görüntü dosyaları|*.bmp; *.png; *.jpeg; *.jpg";

            if (imageopenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string imagePath = imageopenFileDialog.FileName;
                image = new Bitmap(imagePath);
                _originalImage = new Bitmap(image);


                imageBox.Image = image;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                imageBox.Width = image.Width;
                imageBox.Height = image.Height;
                CenterPictureBoxInPanel();

                appPanel.Controls.Add(imageBox);
                isImageRotated = false;
            }

        }

        private void saveFileButton_Click(object sender, EventArgs e)
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

        private void restartButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
    }
}

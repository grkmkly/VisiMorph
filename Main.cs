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
            this.KeyPreview = true;  // Form'un KeyPreview özelliğini true yap
            this.KeyDown += new KeyEventHandler(Form_KeyDown);  // Bu satırla formun tuş olaylarını dinle


        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.imageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.imageBox_Paint);
            buttons = new List<ToolStripButton> {
                cropButton, magnifyingButton, rotateButton,
                addButton, multiplyButton, grayButton,
                binaryButton, RGBtoHSVButton,RGBtoYCBCRButton, brightnessButton,
                histogramButton, adaptiveThresholdButton, convolutionButton,
                saltpepperButton, meanfilterButton, medianfilterButton,
                blurringButton, sobelButton, dilationButton,
                erosionButton, openingButton, closingButton
            };


        }
        List<ToolStripButton> buttons = new List<ToolStripButton>();
        private PictureBox imageBox = new PictureBox();
        private Bitmap image;
        public Bitmap _originalImage;
        private Size newSize;
        bool zoomModeActive;
        bool returnModeActive;
        private List<Bitmap> zoomedImageList = new List<Bitmap>();
        private List<Bitmap> croppedImageList = new List<Bitmap>();
        private List<Bitmap> hsvImageList = new List<Bitmap>();
        private List<Bitmap> ycbcrImageList = new List<Bitmap>();
        private int prevVal;
        private int brightness;
        bool brightnessModeActive;
        bool isImageRotated = false;
        //Kırpma için gerekli değişkenler
        private Point cropStartPoint;
        private Rectangle cropRect;
        private Point startPoint;
        private bool isCropping = false;
        private bool cropModeActive = false;
        private bool isDragging = false;

        private bool hsvModeActive = false;
        private bool ycbcrModeActive = false;
        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPictureBoxInPanel();
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // CTRL+Z kombinasyonu ile geri alma işlemi
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (cropModeActive)
                    UndoCrop();
                else if (zoomModeActive)
                    UndoZoom();
                else if (hsvModeActive)
                    UndoHSV();
                else if (ycbcrModeActive)
                    UndoYCbCr();
                else
                    MessageBox.Show("Geri alma işlemi için geçerli bir modda değilsiniz.");
            }
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
        //DOSYA KAPATMA KULLANILMIYOR -SME
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
        //DOSYA AÇMA
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
        //RESİM KAYDETME
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
        //UYGULAMAYI YENİDEN BAŞLATMA
        private void restartButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }
        //RESİM KIRPMA
        private void cropButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            ToolStripButton clickedButton = sender as ToolStripButton;


            cropModeActive = !cropModeActive;
            if (cropModeActive)
            {
                DisableOtherButtons(clickedButton);
                cropButton.BackColor = Color.LightGray;
                imageBox.Cursor = Cursors.Cross;
                imageBox.MouseDown -= imageBox_MouseDown;
                imageBox.MouseMove -= imageBox_MouseMove;
                imageBox.MouseUp -= imageBox_MouseUp;
                imageBox.MouseDown += imageBox_MouseDown;
                imageBox.MouseMove += imageBox_MouseMove;
                imageBox.MouseUp += imageBox_MouseUp;
                //Kırpmayı Geri Alma Eventi İçin
                imageBox.MouseClick -= imageBox_MouseClick;
                imageBox.MouseClick += imageBox_MouseClick;
            }
            else
            {
                EnableAllButtons();

                imageBox.Cursor = Cursors.Default;
                cropButton.BackColor = Color.Transparent;
                cropModeActive = false;
                _originalImage = (Bitmap)imageBox.Image;
                croppedImageList.Clear();
                CenterPictureBoxInPanel();
            }
        }
        //YAKINLAŞTIRMA-UZAKLAŞTIRMA
        private void magnifyingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            ToolStripButton clickedButton = sender as ToolStripButton;
            zoomModeActive = !zoomModeActive;
            returnModeActive = !returnModeActive;
            if (!zoomModeActive)
            {
                EnableAllButtons();
                // Büyültme modu kapatıldı
                magnifyingButton.BackColor = Color.Transparent;
                image = (Bitmap)imageBox.Image;
                _originalImage = image;
                zoomedImageList.Clear();
            }

            if (zoomModeActive && returnModeActive)
            {
                DisableOtherButtons(clickedButton);
                // Büyültme modu açıldı
                this.Cursor = Cursors.Cross;
                magnifyingButton.BackColor = Color.LightGray;
                imageBox.Image = _originalImage;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                imageBox.MouseClick -= imageBox_MouseClick;
                imageBox.MouseClick += imageBox_MouseClick;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

        }
        //DÖNDÜRME
        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                ImageRotationForm imageRotationForm = new ImageRotationForm();
                imageRotationForm.StartPosition = FormStartPosition.CenterParent;

                if (imageRotationForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int rotateDegree = imageRotationForm.degreeValue;
                    if (!isImageRotated)
                    {
                        GeometricOperations.OriginalImage(_originalImage);
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
            _originalImage = image;

        }
        //RESİM TOPLAMA
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
                    image = ArithmeticTransforms.AddImage(_originalImage, secondImage);
                    imageBox.Image = image;
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    imageBox.Width = image.Width;
                    imageBox.Height = image.Height;
                    CenterPictureBoxInPanel();
                    appPanel.Controls.Add(imageBox);
                }
            }
            _originalImage = (Bitmap)imageBox.Image;

        }
        //RESİM ÇARPMA
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
                    image = ArithmeticTransforms.MultiplyImage(_originalImage, secondImage);
                    imageBox.Image = image;
                    imageBox.SizeMode = PictureBoxSizeMode.Normal;
                    imageBox.Width = image.Width;
                    imageBox.Height = image.Height;
                    CenterPictureBoxInPanel();
                    appPanel.Controls.Add(imageBox);
                }
            }
            _originalImage = image;

        }
        //RESİM GRİ DÖNÜŞTÜRME
        private void graytransformationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                this.Cursor = Cursors.WaitCursor;
                image = ImageFunctions.grayTransformation(_originalImage);
                imageBox.Image = image;
                this.Cursor = Cursors.Default;
            }
            _originalImage = image;
        }
        //RESİM İKİLİ DÖNÜŞTÜRME
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
                thresholdTrackBar.StartPosition = FormStartPosition.CenterParent;
                if (thresholdTrackBar.ShowDialog() == DialogResult.OK)
                {
                    threshold = thresholdTrackBar.trackbarValue;
                }
                this.Cursor = Cursors.WaitCursor;
                image = ImageFunctions.binaryTransformation(_originalImage, threshold);
                imageBox.Image = image;
                this.Cursor = Cursors.Default;
            }
            _originalImage = image;
        }
        //RESİM RGB'DEN HSV'YE DÖNÜŞTÜRME
        private void RGBtoHSVButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            ToolStripButton clickedButton = sender as ToolStripButton;
            hsvModeActive = !hsvModeActive;
            if (hsvModeActive)
            {
                DisableOtherButtons(clickedButton);
                hsvPanel.Visible = !hsvPanel.Visible;
                RGBtoHSVButton.BackColor = hsvPanel.Visible ? Color.LightGray : Color.Transparent;
                hsvPanel.Dock = DockStyle.Left;
                hsvPanel.BringToFront();
                if (hsvPanel.Visible)
                {
                    DisableOtherButtons(clickedButton);
                    hsvOkButton.MouseClick -= hsvOkButton_MouseUp;
                    hsvOkButton.MouseClick += hsvOkButton_MouseUp;
                    hTrackBar.Scroll -= hsvTrackBar_Scroll;
                    hTrackBar.Scroll += hsvTrackBar_Scroll;
                    sTrackBar.Scroll -= hsvTrackBar_Scroll;
                    sTrackBar.Scroll += hsvTrackBar_Scroll;
                    vTrackBar.Scroll -= hsvTrackBar_Scroll;
                    vTrackBar.Scroll += hsvTrackBar_Scroll;
                }
            }
            else
            {
                EnableAllButtons();
                hLabel.Text = "H: 0";
                sLabel.Text = "S: 0";
                vLabel.Text = "V: 0";
                hTrackBar.Value = 0;
                sTrackBar.Value = 0;
                vTrackBar.Value = 0;
                hsvPanel.Visible = false;
                image = (Bitmap)imageBox.Image;
                RGBtoHSVButton.BackColor = Color.Transparent;
            }


            _originalImage = image;

        }
        //RESİM RGB'DEN YCBCR'YE DÖNÜŞTÜRME
        private void RGBtoYCBCRButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            ToolStripButton clickedButton = sender as ToolStripButton;
            ycbcrModeActive = !ycbcrModeActive;
            if (ycbcrModeActive)
            {
                DisableOtherButtons(clickedButton); 
                ycbcrPanel.Visible = !ycbcrPanel.Visible;
                RGBtoYCBCRButton.BackColor = ycbcrPanel.Visible ? Color.LightGray : Color.Transparent;
                ycbcrPanel.Dock = DockStyle.Left;
                ycbcrPanel.BringToFront();
                if (ycbcrPanel.Visible)
                {
                    DisableOtherButtons(clickedButton);
                    ycbcrOkButton.MouseClick -= ycbcrOkButton_MouseUp;
                    ycbcrOkButton.MouseClick += ycbcrOkButton_MouseUp;
                    yTrackBar.Scroll -= ycbcrTrackBar_Scroll;
                    yTrackBar.Scroll += ycbcrTrackBar_Scroll;
                    cbTrackBar.Scroll -= ycbcrTrackBar_Scroll;
                    cbTrackBar.Scroll += ycbcrTrackBar_Scroll;
                    crTrackBar.Scroll -= ycbcrTrackBar_Scroll;
                    crTrackBar.Scroll += ycbcrTrackBar_Scroll;
                }
            }
            else
            {
                EnableAllButtons();
                yLabel.Text = "Y: 0";
                cbLabel.Text = "Cb: 0";
                crLabel.Text = "Cr: 0";
                yTrackBar.Value = 0;
                cbTrackBar.Value = 0;
                crTrackBar.Value = 0;
                ycbcrPanel.Visible = false;
                image = (Bitmap)imageBox.Image;
                RGBtoYCBCRButton.BackColor = Color.Transparent;
            }
        }


        //PARLAKLIK AYARLAMA
        private void brightnessButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
                return;
            }
            ToolStripButton clickedButton = sender as ToolStripButton;
            brightnessModeActive = !brightnessModeActive;
            if (brightnessModeActive)
            {
                DisableOtherButtons(clickedButton);
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
                    brightnessTrack.MouseUp -= BrightnessTrack_MouseUp;
                    brightnessTrack.MouseUp += BrightnessTrack_MouseUp;
                    brightnessTrack.Scroll -= BrightnessTrack_Scroll;
                    brightnessTrack.Scroll += BrightnessTrack_Scroll;
                }
            }
            else
            {
                EnableAllButtons();
                image = (Bitmap)imageBox.Image;
                _originalImage = image;
                panel1.Visible = false;
                brightnessButton.BackColor = Color.Transparent;
                brightnessTrack.Value = 0;
                brightnessLabel.Text = "Seçili Değer: 0";


            }


        }
        //RESİM HISTOGRAMI
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
                    this.Cursor = Cursors.WaitCursor;
                    image = histogramChart.resultImage;
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }

            }
        }
        //RESİM ADAPTİF EŞİKLEME
        private void adaptiveThresholdButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                int windowSize = 0;
                AdaptiveThresholdingForm adaptiveThresholdingForm = new AdaptiveThresholdingForm();
                adaptiveThresholdingForm.StartPosition = FormStartPosition.CenterParent;
                if (adaptiveThresholdingForm.ShowDialog() == DialogResult.OK)
                {
                    windowSize = adaptiveThresholdingForm.windowMatrixSize;
                }
                else if (adaptiveThresholdingForm.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                image = AdaptiveThresholding.adaptivethresholdingMean(_originalImage, windowSize);
                this.Cursor = Cursors.Default;
                imageBox.Image = image;
            }
            _originalImage = image;
        }
        //RESİM GAUSS FİLTRELEME
        private void convolutionButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                GaussForm gaussForm = new GaussForm();
                gaussForm.StartPosition = FormStartPosition.CenterParent;
                if (gaussForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int gaussMatrixSize = gaussForm.gaussMatrixSize;
                    bool isEdgeFill = gaussForm.fillEdge;
                    float sigmaValue = gaussForm.sigma;
                    double[,] gaussFilter = ImageFunctions.GaussianFilter(sigmaValue, gaussMatrixSize);
                    image = ImageFunctions.Convolution(_originalImage, gaussFilter, isEdgeFill);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM SALT AND PEPPER FİLTRELEME
        private void saltpepperButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                SaltPepperForm saltpepperForm = new SaltPepperForm();
                saltpepperForm.StartPosition = FormStartPosition.CenterParent;

                if (saltpepperForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    image = SaltPepper.saltpepperNoise(_originalImage, saltpepperForm.totalNoiseRatioValue, saltpepperForm.saltRatioValue);
                    this.Cursor = Cursors.Default;
                    imageBox.Image = image;
                }
            }
            _originalImage = image;
        }
        //RESİM MEAN FİLTRELEME
        private void meanfilterButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                FilterForm filterForm = new FilterForm();
                filterForm.StartPosition = FormStartPosition.CenterParent;
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int matrixSize = filterForm.filterMatrixSize;
                    image = Filters.medianFilter(_originalImage, matrixSize);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM MEDYAN FİLTRELEME
        private void medianfilterButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                FilterForm filterForm = new FilterForm();
                filterForm.StartPosition = FormStartPosition.CenterParent;
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int matrixSize = filterForm.filterMatrixSize;
                    image = Filters.medianFilter(_originalImage, matrixSize);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM BLURRING FİLTRELEME
        private void blurringButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                FilterForm filterForm = new FilterForm();
                filterForm.StartPosition = FormStartPosition.CenterParent;
                if (filterForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int matrixSize = filterForm.filterMatrixSize;
                    int[,] blurringMatrix = Filters.createBlurringMatrix(matrixSize);
                    image = Filters.blurringFilter(_originalImage, blurringMatrix);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }

            }
            _originalImage = image;

        }
        //RESİM SOBEL KENAR TESPİT
        private void sobelButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                this.Cursor = Cursors.WaitCursor;
                image = Sobel.sobelEdgeAlgoritm(_originalImage);
                imageBox.Image = image;
                this.Cursor = Cursors.Default;
            }
            _originalImage = image;
        }
        //RESİM GENİŞLETME
        private void dilationButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.StartPosition = FormStartPosition.CenterParent;
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageDilation(_originalImage, kernel);
                    image = newImage;
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM AŞINDIRMA
        private void erosionButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.StartPosition = FormStartPosition.CenterParent;
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageErosion(_originalImage, kernel);
                    image = newImage;
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM AÇMA(MORFOLOJIK)
        private void openingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.StartPosition = FormStartPosition.CenterParent;
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageErosion(_originalImage, kernel);
                    image = Morphology.imageDilation(newImage, kernel);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }
        //RESİM KAPAMA(MORFOLOJIK)
        private void closingButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }

            else
            {
                MorphologyMatrixForm morphologyMatrixForm = new MorphologyMatrixForm();
                morphologyMatrixForm.StartPosition = FormStartPosition.CenterParent;
                morphologyMatrixForm.ShowDialog();

                if (morphologyMatrixForm.DialogResult == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int[,] kernel = morphologyMatrixForm.kernelMatrix;
                    Bitmap newImage = Morphology.imageDilation(_originalImage, kernel);
                    image = Morphology.imageErosion(newImage, kernel);
                    imageBox.Image = image;
                    this.Cursor = Cursors.Default;
                }
            }
            _originalImage = image;
        }

        //EVENTLER

        //RESİM BÜYÜLTME İÇİN GEREKEN EVENT
        private void imageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (image == null)
                return;

            if (e.Button == MouseButtons.Left && zoomModeActive)
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
                this.Cursor = Cursors.Cross;
            }


        }
        //PARLAKLIK AYARLAMA İÇİN GEREKEN EVENT
        private void BrightnessTrack_MouseUp(object? sender, EventArgs e)
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
        //PARLAKLIK LABEL AYARLAMA İÇİN GEREKEN EVEN
        private void BrightnessTrack_Scroll(object? sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                brightnessLabel.Text = $"Seçili Değer: {brightnessTrack.Value}";
            }
        }
        //RESİM KIRPMA İÇİN GEREKEN EVENT
        private void imageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cropModeActive) return;

            isDragging = true;
            startPoint = e.Location;
            cropRect = new Rectangle();
        }
        //RESİM KIRPMA İÇİN GEREKEN EVENT
        private void imageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!cropModeActive || !isDragging) return;

            int x = Math.Min(startPoint.X, e.X);
            int y = Math.Min(startPoint.Y, e.Y);
            int width = Math.Abs(startPoint.X - e.X);
            int height = Math.Abs(startPoint.Y - e.Y);

            cropRect = new Rectangle(x, y, width, height);
            imageBox.Refresh(); // Paint olayını tetikler

        }
        //RESİM KIRPMA İÇİN GEREKEN EVENT
        private void imageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!cropModeActive || !isDragging) return;

            isDragging = false;

            // Kırpma işlemini yap
            var cropped = ArithmeticTransforms.CropImage(imageBox.Image, cropRect, imageBox.Size);
            // Kırpılmış resmi listeye ekle
            croppedImageList.Add(cropped);
            cropRect = Rectangle.Empty;
            imageBox.Invalidate();

            if (cropped != null)
            {
                imageBox.Image = cropped;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                imageBox.Width = cropped.Width;
                imageBox.Height = cropped.Height;
                CenterPictureBoxInPanel();
            }

        }
        //KIRPMA BÖLGESİ SEÇİLEN YER İÇİN GEREKLİ EVENT
        private void imageBox_Paint(object sender, PaintEventArgs e)
        {
            if (cropModeActive && cropRect.Width > 0 && cropRect.Height > 0)
            {
                using (Pen redPen = new Pen(Color.Red, 2))
                {
                    redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(redPen, cropRect);
                }
            }
        }
        //KIRPMA İŞLEMİ GERİ ALMA
        private void UndoCrop()
        {
            if (croppedImageList.Count == 0 || croppedImageList.Count == 1)
            {
                imageBox.Image = _originalImage;
                imageBox.Width = _originalImage.Width;
                imageBox.Height = _originalImage.Height;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                CenterPictureBoxInPanel();
                croppedImageList.Clear();
                return;
            }
            else
            {
                imageBox.Image = croppedImageList[croppedImageList.Count - 2];
                imageBox.Width = croppedImageList[croppedImageList.Count - 2].Width;
                imageBox.Height = croppedImageList[croppedImageList.Count - 2].Height;
                croppedImageList.RemoveAt(croppedImageList.Count - 2);
                imageBox.SizeMode = PictureBoxSizeMode.Normal;

                CenterPictureBoxInPanel();
            }
        }
        //ZOOM İŞLEMİNİ GERİ ALMA
        private void UndoZoom()
        {
            if (zoomedImageList.Count == 0 || zoomedImageList.Count == 1)
            {
                imageBox.Image = _originalImage;
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
        //HSV İŞLEMİNİ GERİ ALMA
        private void UndoHSV()
        {
            if (hsvImageList.Count == 0 || hsvImageList.Count == 1)
            {
                imageBox.Image = _originalImage;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                CenterPictureBoxInPanel();
                hsvImageList.Clear();
                return;
            }
            else
            {
                imageBox.Image = hsvImageList[hsvImageList.Count - 2];
                hsvImageList.RemoveAt(hsvImageList.Count - 2);
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                CenterPictureBoxInPanel();
            }
        }
        //YCbCr İŞLEMİ GERİ ALMA
        private void UndoYCbCr()
        {
            if (ycbcrImageList.Count == 0 || ycbcrImageList.Count == 1)
            {
                imageBox.Image = _originalImage;
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                CenterPictureBoxInPanel();
                ycbcrImageList.Clear();
                return;
            }
            else
            {
                imageBox.Image = ycbcrImageList[ycbcrImageList.Count - 2];
                ycbcrImageList.RemoveAt(ycbcrImageList.Count - 2);
                imageBox.SizeMode = PictureBoxSizeMode.Normal;
                CenterPictureBoxInPanel();
            }
        }
        //TIKLANMAMIŞ BUTONLARI DEVRE DIŞI BIRAKMA
        private void DisableOtherButtons(ToolStripButton activeButton)
        {

            foreach (ToolStripButton button in buttons)
            {
                if (button != activeButton)
                {
                    button.Enabled = false;
                }
            }
        }
        // BUTONLARI AKTİF ETME
        private void EnableAllButtons()
        {
            foreach (ToolStripButton button in buttons)
            {
                button.Enabled = true;
            }
        }
        //HSV OK BUTONU
        private void hsvOkButton_MouseUp(object? sender, MouseEventArgs e)
        {
            double H, S, V;

            H = (hTrackBar.Value / 100.0f);
            S = (sTrackBar.Value / 100.0f);
            V = (vTrackBar.Value / 100.0f);
            imageBox.Image = ImageFunctions.imageRGBtoHSV(_originalImage, H, S, V);
            hsvImageList.Add((Bitmap)imageBox.Image);

        }
        //HSV TRACKBAR DEĞERLERİ
        private void hsvTrackBar_Scroll(object? sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                hLabel.Text = $"H: {hTrackBar.Value / 100.0f}";
                sLabel.Text = $"S: {sTrackBar.Value / 100.0f}";
                vLabel.Text = $"V: {vTrackBar.Value / 100.0f}";
            }
        }
        //YCbCr OK BUTONU
        private void ycbcrOkButton_MouseUp(object? sender, MouseEventArgs e)
        {
            double Y, Cb, Cr;
            Y = (yTrackBar.Value / 100.0f);
            Cb = (cbTrackBar.Value / 100.0f);
            Cr = (crTrackBar.Value / 100.0f);
            imageBox.Image = ImageFunctions.imageRGBtoYCbCr(_originalImage);
            ycbcrImageList.Add((Bitmap)imageBox.Image);
        }
        //YCbCr TRACKBAR DEĞERLERİ
        private void ycbcrTrackBar_Scroll(object? sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Henüz bir resim yüklemediniz, işlem başarısız.");
            }
            else
            {
                yLabel.Text = $"Y: {yTrackBar.Value / 100.0f}";
                cbLabel.Text = $"Cb: {cbTrackBar.Value / 100.0f}";
                crLabel.Text = $"Cr: {crTrackBar.Value / 100.0f}";
            }
        }

        
    }
}

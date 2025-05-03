using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VisiMorph
{
    public partial class Histogram : Form
    {
        public Bitmap originalImage;
        public Bitmap resultImage { get; private set; }
        public int[] histogramArray;

        public Histogram(Bitmap image)
        {
            InitializeComponent();
            originalImage = image;
            resultImage = null;
        }



        private void HistogramStretch_Load(object sender, EventArgs e)
        {
            // Aralık değerleri
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.Interval = 1;
            // X ekseni
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 255;

            // Y ekseni
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 10000;

            // Resim constructor'a parametre olarak gönderildiğinde ilk histogram hesaplanması ve gösterilmesi.
            histogramArray = ImageFunctions.calculateHistogram(originalImage);
            for (int i = 0; i < histogramArray.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, histogramArray[i]);
            }
        }

        private void histogramStretchButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor; 
            Bitmap stretched = ImageFunctions.stretchingHistogram(originalImage);
            resultImage = stretched;

            int[] newHistogramArray = ImageFunctions.calculateHistogram(resultImage);
            chart.Series[0].Points.Clear();
            for (int i = 0; i < newHistogramArray.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, newHistogramArray[i]);
            }
            this.Cursor = Cursors.Default;
        }

        private void histogramExtendButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (histogramRangeMax.Value == histogramRangeMin.Value) 
            { 
                MessageBox.Show("Aralık (range) değerleri, birbirine eşit olamaz.");
                return;
            }
            

            Bitmap extended = ImageFunctions.extendingHistogram(originalImage, (int)histogramRangeMin.Value, (int)histogramRangeMax.Value);
            resultImage = extended;

            int[] newHistogramArray = ImageFunctions.calculateHistogram(resultImage);
            chart.Series[0].Points.Clear();
            for (int i = 0; i < newHistogramArray.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, newHistogramArray[i]);
            }
            this.Cursor = Cursors.Default;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

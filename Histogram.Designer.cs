namespace VisiMorph
{
    partial class Histogram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            histogramExtendButton = new Button();
            histogramRangeMax = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            histogramRangeMin = new NumericUpDown();
            groupBox2 = new GroupBox();
            histogramStretchButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histogramRangeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)histogramRangeMin).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // chart
            // 
            chart.BackColor = Color.LightSteelBlue;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Angle = -90;
            chartArea4.AxisX.LabelStyle.Format = "0";
            chartArea4.AxisX.LabelStyle.Interval = 5D;
            chartArea4.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea4.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea4.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisX.Maximum = 255D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "Renk değerleri";
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Format = "0";
            chartArea4.AxisY.LabelStyle.Interval = 500D;
            chartArea4.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea4.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea4.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.AxisY.Maximum = 10000D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "Renk Frekansı";
            chartArea4.BackColor = Color.FromArgb(64, 64, 64);
            chartArea4.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea4);
            chart.Location = new Point(296, 12);
            chart.Name = "chart";
            series4.ChartArea = "ChartArea1";
            series4.Color = SystemColors.MenuHighlight;
            series4.CustomProperties = "MaxPixelPointWidth=200, MinPixelPointWidth=1, PixelPointWidth=1";
            series4.LabelAngle = -90;
            series4.MarkerColor = Color.White;
            series4.Name = "Series1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chart.Series.Add(series4);
            chart.Size = new Size(961, 580);
            chart.TabIndex = 1;
            chart.Text = "chart1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(histogramExtendButton);
            groupBox1.Controls.Add(histogramRangeMax);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(histogramRangeMin);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(253, 157);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Histogram Genişletme";
            // 
            // histogramExtendButton
            // 
            histogramExtendButton.ForeColor = Color.Black;
            histogramExtendButton.Location = new Point(18, 113);
            histogramExtendButton.Name = "histogramExtendButton";
            histogramExtendButton.Size = new Size(201, 38);
            histogramExtendButton.TabIndex = 7;
            histogramExtendButton.Text = "Histogramı Genişlet";
            histogramExtendButton.UseVisualStyleBackColor = true;
            histogramExtendButton.Click += histogramExtendButton_Click;
            // 
            // histogramRangeMax
            // 
            histogramRangeMax.Location = new Point(156, 70);
            histogramRangeMax.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            histogramRangeMax.Name = "histogramRangeMax";
            histogramRangeMax.Size = new Size(91, 30);
            histogramRangeMax.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 72);
            label2.Name = "label2";
            label2.Size = new Size(142, 23);
            label2.TabIndex = 2;
            label2.Text = "Maksimum aralık:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 36);
            label1.Name = "label1";
            label1.Size = new Size(132, 23);
            label1.TabIndex = 1;
            label1.Text = "Minimum aralık:";
            // 
            // histogramRangeMin
            // 
            histogramRangeMin.Location = new Point(156, 34);
            histogramRangeMin.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            histogramRangeMin.Name = "histogramRangeMin";
            histogramRangeMin.Size = new Size(91, 30);
            histogramRangeMin.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(histogramStretchButton);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(253, 74);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Histogram Germe";
            // 
            // histogramStretchButton
            // 
            histogramStretchButton.ForeColor = Color.Black;
            histogramStretchButton.Location = new Point(18, 29);
            histogramStretchButton.Name = "histogramStretchButton";
            histogramStretchButton.Size = new Size(201, 38);
            histogramStretchButton.TabIndex = 8;
            histogramStretchButton.Text = "Histogramı Ger";
            histogramStretchButton.UseVisualStyleBackColor = true;
            histogramStretchButton.Click += histogramStretchButton_Click;
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 554);
            okButton.Name = "okButton";
            okButton.Size = new Size(130, 38);
            okButton.TabIndex = 9;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(160, 554);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 38);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // Histogram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1269, 604);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(chart);
            Name = "Histogram";
            Text = "Histogram İşlemleri";
            Load += HistogramStretch_Load;
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)histogramRangeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)histogramRangeMin).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private GroupBox groupBox1;
        private Label label1;
        private NumericUpDown histogramRangeMin;
        private NumericUpDown histogramRangeMax;
        private Label label2;
        private GroupBox groupBox2;
        private Button histogramExtendButton;
        private Button histogramStretchButton;
        private Button okButton;
        private Button cancelButton;
    }
}
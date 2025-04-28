namespace VisiMorph
{
    partial class RGBtoHSVTrackBar
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
            hLabel = new Label();
            sLabel = new Label();
            vLabel = new Label();
            hTrackBar = new TrackBar();
            sTrackBar = new TrackBar();
            vTrackBar = new TrackBar();
            okButton = new Button();
            closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)hTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vTrackBar).BeginInit();
            SuspendLayout();
            // 
            // hLabel
            // 
            hLabel.AutoSize = true;
            hLabel.BackColor = Color.Transparent;
            hLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            hLabel.ForeColor = Color.White;
            hLabel.Location = new Point(10, 12);
            hLabel.Name = "hLabel";
            hLabel.Size = new Size(40, 23);
            hLabel.TabIndex = 2;
            hLabel.Text = "H: 0";
            // 
            // sLabel
            // 
            sLabel.AutoSize = true;
            sLabel.BackColor = Color.Transparent;
            sLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sLabel.ForeColor = Color.White;
            sLabel.Location = new Point(10, 55);
            sLabel.Name = "sLabel";
            sLabel.Size = new Size(37, 23);
            sLabel.TabIndex = 3;
            sLabel.Text = "S: 0";
            // 
            // vLabel
            // 
            vLabel.AutoSize = true;
            vLabel.BackColor = Color.Transparent;
            vLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            vLabel.ForeColor = Color.White;
            vLabel.Location = new Point(10, 99);
            vLabel.Name = "vLabel";
            vLabel.Size = new Size(39, 23);
            vLabel.TabIndex = 4;
            vLabel.Text = "V: 0";
            // 
            // hTrackBar
            // 
            hTrackBar.Location = new Point(57, 12);
            hTrackBar.Maximum = 360;
            hTrackBar.Name = "hTrackBar";
            hTrackBar.Size = new Size(215, 56);
            hTrackBar.TabIndex = 5;
            hTrackBar.Scroll += hTrackBar_Scroll;
            // 
            // sTrackBar
            // 
            sTrackBar.Location = new Point(57, 55);
            sTrackBar.Maximum = 100;
            sTrackBar.Name = "sTrackBar";
            sTrackBar.Size = new Size(215, 56);
            sTrackBar.TabIndex = 6;
            sTrackBar.Scroll += sTrackBar_Scroll;
            // 
            // vTrackBar
            // 
            vTrackBar.Location = new Point(57, 99);
            vTrackBar.Maximum = 100;
            vTrackBar.Name = "vTrackBar";
            vTrackBar.Size = new Size(215, 56);
            vTrackBar.TabIndex = 7;
            vTrackBar.Scroll += vTrackBar_Scroll;
            // 
            // okButton
            // 
            okButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            okButton.Location = new Point(12, 161);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 8;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            closeButton.Location = new Point(178, 161);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 9;
            closeButton.Text = "İptal";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // RGBtoHSV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(284, 199);
            Controls.Add(closeButton);
            Controls.Add(okButton);
            Controls.Add(vTrackBar);
            Controls.Add(sTrackBar);
            Controls.Add(hTrackBar);
            Controls.Add(vLabel);
            Controls.Add(sLabel);
            Controls.Add(hLabel);
            Name = "RGBtoHSV";
            Text = "RGB to HSV";
            ((System.ComponentModel.ISupportInitialize)hTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)sTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)vTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hLabel;
        private Label sLabel;
        private Label vLabel;
        private TrackBar hTrackBar;
        private TrackBar sTrackBar;
        private TrackBar vTrackBar;
        private Button okButton;
        private Button closeButton;
    }
}
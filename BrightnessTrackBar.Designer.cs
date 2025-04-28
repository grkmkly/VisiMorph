namespace VisiMorph
{
    partial class BrightnessTrackBar
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
            trackbarLabel = new Label();
            brightTrackBar = new TrackBar();
            brightnessLabel = new Label();
            okButton = new Button();
            closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)brightTrackBar).BeginInit();
            SuspendLayout();
            // 
            // trackbarLabel
            // 
            trackbarLabel.AutoSize = true;
            trackbarLabel.BackColor = Color.Transparent;
            trackbarLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            trackbarLabel.ForeColor = Color.White;
            trackbarLabel.Location = new Point(12, 9);
            trackbarLabel.Name = "trackbarLabel";
            trackbarLabel.Size = new Size(312, 23);
            trackbarLabel.TabIndex = 2;
            trackbarLabel.Text = "-255 ile +255 arasında bir değer seçiniz.";
            // 
            // brightTrackBar
            // 
            brightTrackBar.Location = new Point(12, 35);
            brightTrackBar.Maximum = 255;
            brightTrackBar.Minimum = -255;
            brightTrackBar.Name = "brightTrackBar";
            brightTrackBar.Size = new Size(307, 56);
            brightTrackBar.TabIndex = 3;
            brightTrackBar.Scroll += brightTrackBar_Scroll;
            // 
            // brightnessLabel
            // 
            brightnessLabel.AutoSize = true;
            brightnessLabel.BackColor = Color.Transparent;
            brightnessLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            brightnessLabel.ForeColor = Color.White;
            brightnessLabel.Location = new Point(12, 78);
            brightnessLabel.Name = "brightnessLabel";
            brightnessLabel.Size = new Size(117, 23);
            brightnessLabel.TabIndex = 4;
            brightnessLabel.Text = "Seçili Değer: 0";
            // 
            // okButton
            // 
            okButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            okButton.Location = new Point(12, 112);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 5;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            closeButton.Location = new Point(225, 112);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 6;
            closeButton.Text = "İptal";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // BrightnessTrackBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(331, 153);
            Controls.Add(closeButton);
            Controls.Add(okButton);
            Controls.Add(brightnessLabel);
            Controls.Add(brightTrackBar);
            Controls.Add(trackbarLabel);
            Name = "BrightnessTrackBar";
            Text = "Parlaklık Ayarı";
            ((System.ComponentModel.ISupportInitialize)brightTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label trackbarLabel;
        private TrackBar brightTrackBar;
        private Label brightnessLabel;
        private Button okButton;
        private Button closeButton;
    }
}
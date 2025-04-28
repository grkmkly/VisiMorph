namespace VisiMorph
{
    partial class ThresholdTrackBar
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
            tobinaryTrackBar = new TrackBar();
            trackbarLabel = new Label();
            okButton = new Button();
            closeButton = new Button();
            label1 = new Label();
            valueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)tobinaryTrackBar).BeginInit();
            SuspendLayout();
            // 
            // tobinaryTrackBar
            // 
            tobinaryTrackBar.Location = new Point(12, 35);
            tobinaryTrackBar.Maximum = 255;
            tobinaryTrackBar.Name = "tobinaryTrackBar";
            tobinaryTrackBar.Size = new Size(255, 56);
            tobinaryTrackBar.TabIndex = 0;
            tobinaryTrackBar.Scroll += tobinaryTrackBar_Scroll;
            // 
            // trackbarLabel
            // 
            trackbarLabel.AutoSize = true;
            trackbarLabel.BackColor = Color.Transparent;
            trackbarLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            trackbarLabel.ForeColor = Color.White;
            trackbarLabel.Location = new Point(12, 9);
            trackbarLabel.Name = "trackbarLabel";
            trackbarLabel.Size = new Size(255, 23);
            trackbarLabel.TabIndex = 1;
            trackbarLabel.Text = "0-255 arasında bir değer seçiniz.";
            // 
            // okButton
            // 
            okButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            okButton.Location = new Point(12, 112);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 2;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            closeButton.Location = new Point(169, 112);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 3;
            closeButton.Text = "İptal";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 78);
            label1.Name = "label1";
            label1.Size = new Size(103, 23);
            label1.TabIndex = 4;
            label1.Text = "Seçili Değer:";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(113, 78);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(19, 23);
            valueLabel.TabIndex = 5;
            valueLabel.Text = "0";
            // 
            // ThresholdTrackBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(275, 153);
            Controls.Add(valueLabel);
            Controls.Add(label1);
            Controls.Add(closeButton);
            Controls.Add(okButton);
            Controls.Add(trackbarLabel);
            Controls.Add(tobinaryTrackBar);
            Name = "ThresholdTrackBar";
            Text = "Eşik Değeri";
            ((System.ComponentModel.ISupportInitialize)tobinaryTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tobinaryTrackBar;
        private Label trackbarLabel;
        private Button okButton;
        private Button closeButton;
        private Label label1;
        private Label valueLabel;
    }
}
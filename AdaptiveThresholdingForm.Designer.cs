namespace VisiMorph
{
    partial class AdaptiveThresholdingForm
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
            windowsizeInput = new NumericUpDown();
            label1 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)windowsizeInput).BeginInit();
            SuspendLayout();
            // 
            // windowsizeInput
            // 
            windowsizeInput.Location = new Point(204, 16);
            windowsizeInput.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            windowsizeInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            windowsizeInput.Name = "windowsizeInput";
            windowsizeInput.Size = new Size(91, 27);
            windowsizeInput.TabIndex = 1;
            windowsizeInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(185, 23);
            label1.TabIndex = 2;
            label1.Text = "Pencere Matris Boyutu:";
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 55);
            okButton.Name = "okButton";
            okButton.Size = new Size(130, 38);
            okButton.TabIndex = 10;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(165, 55);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 38);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // AdaptiveThresholdingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(307, 105);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            Controls.Add(windowsizeInput);
            Name = "AdaptiveThresholdingForm";
            Text = "AdaptiveThresholdingForm";
            ((System.ComponentModel.ISupportInitialize)windowsizeInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown windowsizeInput;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
    }
}
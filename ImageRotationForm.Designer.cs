namespace VisiMorph
{
    partial class ImageRotationForm
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
            label1 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            degreeInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)degreeInput).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 32);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 15;
            label1.Text = "Döndürme Açısı (°):";
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 96);
            okButton.Name = "okButton";
            okButton.Size = new Size(130, 38);
            okButton.TabIndex = 16;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(169, 96);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 38);
            cancelButton.TabIndex = 17;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // degreeInput
            // 
            degreeInput.Location = new Point(190, 32);
            degreeInput.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            degreeInput.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            degreeInput.Name = "degreeInput";
            degreeInput.Size = new Size(96, 27);
            degreeInput.TabIndex = 18;
            degreeInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ImageRotationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(311, 146);
            Controls.Add(degreeInput);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            Name = "ImageRotationForm";
            Text = "ImageRotationForm";
            ((System.ComponentModel.ISupportInitialize)degreeInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button okButton;
        private Button cancelButton;
        private NumericUpDown degreeInput;
    }
}
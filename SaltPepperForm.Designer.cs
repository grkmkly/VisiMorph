namespace VisiMorph
{
    partial class SaltPepperForm
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
            saltpepperRatioInput = new NumericUpDown();
            label2 = new Label();
            saltRatioInput = new NumericUpDown();
            label3 = new Label();
            pepperRatioInput = new NumericUpDown();
            okButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)saltpepperRatioInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saltRatioInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pepperRatioInput).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 29);
            label1.Name = "label1";
            label1.Size = new Size(226, 23);
            label1.TabIndex = 3;
            label1.Text = "Toplam Tuz Biber Oranı (%): ";
            // 
            // saltpepperRatioInput
            // 
            saltpepperRatioInput.Location = new Point(252, 29);
            saltpepperRatioInput.Name = "saltpepperRatioInput";
            saltpepperRatioInput.Size = new Size(96, 27);
            saltpepperRatioInput.TabIndex = 4;
            saltpepperRatioInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 64);
            label2.Name = "label2";
            label2.Size = new Size(228, 23);
            label2.TabIndex = 5;
            label2.Text = "Tuz (Beyaz Piksel) Oranı (%): ";
            // 
            // saltRatioInput
            // 
            saltRatioInput.Location = new Point(252, 64);
            saltRatioInput.Name = "saltRatioInput";
            saltRatioInput.Size = new Size(96, 27);
            saltRatioInput.TabIndex = 6;
            saltRatioInput.Value = new decimal(new int[] { 50, 0, 0, 0 });
            saltRatioInput.ValueChanged += saltRatio_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 102);
            label3.Name = "label3";
            label3.Size = new Size(236, 23);
            label3.TabIndex = 7;
            label3.Text = "Biber (Siyah Piksel) Oranı (%): ";
            // 
            // pepperRatioInput
            // 
            pepperRatioInput.Location = new Point(252, 102);
            pepperRatioInput.Name = "pepperRatioInput";
            pepperRatioInput.Size = new Size(96, 27);
            pepperRatioInput.TabIndex = 8;
            pepperRatioInput.Value = new decimal(new int[] { 50, 0, 0, 0 });
            pepperRatioInput.ValueChanged += pepperRatio_ValueChanged;
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 170);
            okButton.Name = "okButton";
            okButton.Size = new Size(130, 38);
            okButton.TabIndex = 11;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(218, 170);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 38);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // SaltPepperForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(360, 220);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(pepperRatioInput);
            Controls.Add(label3);
            Controls.Add(saltRatioInput);
            Controls.Add(label2);
            Controls.Add(saltpepperRatioInput);
            Controls.Add(label1);
            Name = "SaltPepperForm";
            Text = "Tuz & Biber (Salt & Pepper) Gürültüsü";
            ((System.ComponentModel.ISupportInitialize)saltpepperRatioInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)saltRatioInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)pepperRatioInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown saltpepperRatioInput;
        private Label label2;
        private NumericUpDown saltRatioInput;
        private Label label3;
        private NumericUpDown pepperRatioInput;
        private Button okButton;
        private Button cancelButton;
    }
}
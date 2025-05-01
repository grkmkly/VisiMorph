namespace VisiMorph
{
    partial class GaussForm
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
            okButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            gausssizeInput = new NumericUpDown();
            groupBox1 = new GroupBox();
            notfillRadioButton = new RadioButton();
            fillRadioButton = new RadioButton();
            label2 = new Label();
            sigmaInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)gausssizeInput).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sigmaInput).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 149);
            okButton.Name = "okButton";
            okButton.Size = new Size(95, 38);
            okButton.TabIndex = 13;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(123, 149);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(95, 38);
            cancelButton.TabIndex = 14;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 15;
            label1.Text = "Gauss Matris Boyutu:";
            // 
            // gausssizeInput
            // 
            gausssizeInput.Location = new Point(163, 12);
            gausssizeInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gausssizeInput.Name = "gausssizeInput";
            gausssizeInput.Size = new Size(55, 27);
            gausssizeInput.TabIndex = 16;
            gausssizeInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            gausssizeInput.ValueChanged += flltermatrixInput_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(notfillRadioButton);
            groupBox1.Controls.Add(fillRadioButton);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(206, 61);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kenar Doldurma Ayarları";
            // 
            // notfillRadioButton
            // 
            notfillRadioButton.AutoSize = true;
            notfillRadioButton.ForeColor = Color.White;
            notfillRadioButton.Location = new Point(103, 31);
            notfillRadioButton.Name = "notfillRadioButton";
            notfillRadioButton.Size = new Size(97, 24);
            notfillRadioButton.TabIndex = 19;
            notfillRadioButton.TabStop = true;
            notfillRadioButton.Text = "Doldurma";
            notfillRadioButton.UseVisualStyleBackColor = true;
            // 
            // fillRadioButton
            // 
            fillRadioButton.AutoSize = true;
            fillRadioButton.ForeColor = Color.White;
            fillRadioButton.Location = new Point(6, 31);
            fillRadioButton.Name = "fillRadioButton";
            fillRadioButton.Size = new Size(76, 24);
            fillRadioButton.TabIndex = 18;
            fillRadioButton.TabStop = true;
            fillRadioButton.Text = "Doldur";
            fillRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(31, 47);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 18;
            label2.Text = "Sigma Büyüklüğü:";
            // 
            // sigmaInput
            // 
            sigmaInput.DecimalPlaces = 1;
            sigmaInput.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            sigmaInput.Location = new Point(163, 45);
            sigmaInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            sigmaInput.Name = "sigmaInput";
            sigmaInput.Size = new Size(55, 27);
            sigmaInput.TabIndex = 19;
            sigmaInput.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // GaussForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(230, 199);
            Controls.Add(sigmaInput);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(gausssizeInput);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Name = "GaussForm";
            Text = "GaussForm";
            ((System.ComponentModel.ISupportInitialize)gausssizeInput).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sigmaInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private Label label1;
        private NumericUpDown gausssizeInput;
        private GroupBox groupBox1;
        private RadioButton notfillRadioButton;
        private RadioButton fillRadioButton;
        private Label label2;
        private NumericUpDown sigmaInput;
    }
}
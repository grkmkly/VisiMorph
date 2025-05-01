namespace VisiMorph
{
    partial class FilterForm
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
            flltermatrixInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)flltermatrixInput).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.ForeColor = Color.Black;
            okButton.Location = new Point(12, 96);
            okButton.Name = "okButton";
            okButton.Size = new Size(130, 38);
            okButton.TabIndex = 12;
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
            cancelButton.TabIndex = 13;
            cancelButton.Text = "İptal";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(162, 23);
            label1.TabIndex = 14;
            label1.Text = "Filtre Matris Boyutu:";
            // 
            // flltermatrixInput
            // 
            flltermatrixInput.Location = new Point(190, 25);
            flltermatrixInput.Name = "flltermatrixInput";
            flltermatrixInput.Size = new Size(96, 27);
            flltermatrixInput.TabIndex = 15;
            flltermatrixInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(311, 146);
            Controls.Add(flltermatrixInput);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Name = "FilterForm";
            Text = "FilterForm";
            ((System.ComponentModel.ISupportInitialize)flltermatrixInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private Label label1;
        private NumericUpDown flltermatrixInput;
    }
}
namespace VisiMorph
{
    partial class MorphologyMatrixForm
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
            groupBox2 = new GroupBox();
            matrixheightInput = new NumericUpDown();
            matrixwidthInput = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            okButton = new Button();
            creatematrixButton = new Button();
            closeButton = new Button();
            matrixDataGridView = new DataGridView();
            rowaddButton = new Button();
            rowdeleteButton = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)matrixheightInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matrixwidthInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matrixDataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(matrixheightInput);
            groupBox2.Controls.Add(matrixwidthInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(12, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(371, 146);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Çekirdek (Kernel) Matris Ayarları";
            // 
            // matrixheightInput
            // 
            matrixheightInput.Location = new Point(276, 86);
            matrixheightInput.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            matrixheightInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixheightInput.Name = "matrixheightInput";
            matrixheightInput.Size = new Size(89, 30);
            matrixheightInput.TabIndex = 9;
            matrixheightInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // matrixwidthInput
            // 
            matrixwidthInput.Location = new Point(276, 47);
            matrixwidthInput.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            matrixwidthInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixwidthInput.Name = "matrixwidthInput";
            matrixwidthInput.Size = new Size(89, 30);
            matrixwidthInput.TabIndex = 8;
            matrixwidthInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(6, 90);
            label2.Name = "label2";
            label2.Size = new Size(261, 20);
            label2.TabIndex = 3;
            label2.Text = "Maksimum Matris Yüksekliği (Height): ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(19, 51);
            label1.Name = "label1";
            label1.Size = new Size(248, 20);
            label1.TabIndex = 2;
            label1.Text = "Maksimum Matris Genişliği (Width): ";
            // 
            // okButton
            // 
            okButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            okButton.Location = new Point(12, 713);
            okButton.Name = "okButton";
            okButton.Size = new Size(219, 41);
            okButton.TabIndex = 9;
            okButton.Text = "Tamam";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // creatematrixButton
            // 
            creatematrixButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            creatematrixButton.Location = new Point(389, 40);
            creatematrixButton.Name = "creatematrixButton";
            creatematrixButton.Size = new Size(269, 41);
            creatematrixButton.TabIndex = 10;
            creatematrixButton.Text = "Matrisi Oluştur";
            creatematrixButton.UseVisualStyleBackColor = true;
            creatematrixButton.Click += creatematrixButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            closeButton.Location = new Point(439, 713);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(219, 41);
            closeButton.TabIndex = 11;
            closeButton.Text = "İptal";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // matrixDataGridView
            // 
            matrixDataGridView.AllowUserToAddRows = false;
            matrixDataGridView.AllowUserToDeleteRows = false;
            matrixDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrixDataGridView.Location = new Point(12, 192);
            matrixDataGridView.Name = "matrixDataGridView";
            matrixDataGridView.RowHeadersWidth = 51;
            matrixDataGridView.Size = new Size(646, 502);
            matrixDataGridView.TabIndex = 12;
            matrixDataGridView.CellValidating += matrixDataGridView_CellValidating;
            // 
            // rowaddButton
            // 
            rowaddButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rowaddButton.Location = new Point(389, 133);
            rowaddButton.Name = "rowaddButton";
            rowaddButton.Size = new Size(132, 41);
            rowaddButton.TabIndex = 13;
            rowaddButton.Text = "Satır Ekle";
            rowaddButton.UseVisualStyleBackColor = true;
            rowaddButton.Click += rowaddButton_Click;
            // 
            // rowdeleteButton
            // 
            rowdeleteButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rowdeleteButton.Location = new Point(526, 133);
            rowdeleteButton.Name = "rowdeleteButton";
            rowdeleteButton.Size = new Size(132, 41);
            rowdeleteButton.TabIndex = 14;
            rowdeleteButton.Text = "Satır Sil";
            rowdeleteButton.UseVisualStyleBackColor = true;
            rowdeleteButton.Click += rowdeleteButton_Click;
            // 
            // MorphologyMatrixForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(670, 766);
            Controls.Add(rowdeleteButton);
            Controls.Add(rowaddButton);
            Controls.Add(matrixDataGridView);
            Controls.Add(closeButton);
            Controls.Add(creatematrixButton);
            Controls.Add(okButton);
            Controls.Add(groupBox2);
            Name = "MorphologyMatrixForm";
            Text = "MorphologyMatrixForm";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)matrixheightInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)matrixwidthInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)matrixDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private NumericUpDown matrixheightInput;
        private NumericUpDown matrixwidthInput;
        private Label label2;
        private Label label1;
        private Button okButton;
        private Button creatematrixButton;
        private Button closeButton;
        private DataGridView matrixDataGridView;
        private Button rowaddButton;
        private Button rowdeleteButton;
    }
}
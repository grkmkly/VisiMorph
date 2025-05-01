namespace VisiMorph
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imageopenFileDialog = new OpenFileDialog();
            navbarFile = new ToolStripDropDownButton();
            fileopenButton = new ToolStripMenuItem();
            filecloseButton = new ToolStripMenuItem();
            filesaveButton = new ToolStripMenuItem();
            navbarTransformations = new ToolStripDropDownButton();
            geometrictransformationButton = new ToolStripMenuItem();
            imagerotationButton = new ToolStripMenuItem();
            imagecroppingButton = new ToolStripMenuItem();
            imagezoomingButton = new ToolStripMenuItem();
            arithmetictransformationButton = new ToolStripMenuItem();
            addimageButton = new ToolStripMenuItem();
            multiplyimageButton = new ToolStripMenuItem();
            colortransformationButton = new ToolStripMenuItem();
            graytransformationButton = new ToolStripMenuItem();
            binarytransformationButton = new ToolStripMenuItem();
            colorspaceButton = new ToolStripMenuItem();
            RGBtoHSVButton = new ToolStripMenuItem();
            brightnessButton = new ToolStripMenuItem();
            navbarHistogram = new ToolStripDropDownButton();
            imagehistogramButton = new ToolStripMenuItem();
            navbarThresholding = new ToolStripDropDownButton();
            adaptiveButton = new ToolStripMenuItem();
            navbarFilterNoise = new ToolStripDropDownButton();
            convolutionButton = new ToolStripMenuItem();
            addnoiseButton = new ToolStripMenuItem();
            saltpepperButton = new ToolStripMenuItem();
            removenoiseButton = new ToolStripMenuItem();
            meanfilterButton = new ToolStripMenuItem();
            medianfilterButton = new ToolStripMenuItem();
            blurringButton = new ToolStripMenuItem();
            navbarEdge = new ToolStripDropDownButton();
            sobelButton = new ToolStripMenuItem();
            navbarMenu = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            navbarMorphology = new ToolStripDropDownButton();
            dilationButton = new ToolStripMenuItem();
            erosionButton = new ToolStripMenuItem();
            openingButton = new ToolStripMenuItem();
            closingButton = new ToolStripMenuItem();
            appPanel = new Panel();
            imagesaveFileDialog = new SaveFileDialog();
            navbarMenu.SuspendLayout();
            SuspendLayout();
            // 
            // navbarFile
            // 
            navbarFile.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarFile.DropDownItems.AddRange(new ToolStripItem[] { fileopenButton, filecloseButton, filesaveButton });
            navbarFile.ImageTransparentColor = Color.Magenta;
            navbarFile.Name = "navbarFile";
            navbarFile.Size = new Size(74, 28);
            navbarFile.Text = "Dosya";
            // 
            // fileopenButton
            // 
            fileopenButton.Name = "fileopenButton";
            fileopenButton.Size = new Size(148, 28);
            fileopenButton.Text = "Aç";
            fileopenButton.Click += fileopenButton_Click;
            // 
            // filecloseButton
            // 
            filecloseButton.Name = "filecloseButton";
            filecloseButton.Size = new Size(148, 28);
            filecloseButton.Text = "Kapat";
            filecloseButton.Click += filecloseButton_Click;
            // 
            // filesaveButton
            // 
            filesaveButton.Name = "filesaveButton";
            filesaveButton.Size = new Size(148, 28);
            filesaveButton.Text = "Kaydet";
            filesaveButton.Click += filesaveButton_Click;
            // 
            // navbarTransformations
            // 
            navbarTransformations.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarTransformations.DropDownItems.AddRange(new ToolStripItem[] { geometrictransformationButton, arithmetictransformationButton, colortransformationButton, brightnessButton });
            navbarTransformations.ImageTransparentColor = Color.Magenta;
            navbarTransformations.Name = "navbarTransformations";
            navbarTransformations.Size = new Size(121, 28);
            navbarTransformations.Text = "Dönüşümler";
            // 
            // geometrictransformationButton
            // 
            geometrictransformationButton.DropDownItems.AddRange(new ToolStripItem[] { imagerotationButton, imagecroppingButton, imagezoomingButton });
            geometrictransformationButton.Name = "geometrictransformationButton";
            geometrictransformationButton.Size = new Size(278, 28);
            geometrictransformationButton.Text = "Geometrik Dönüşümler";
            // 
            // imagerotationButton
            // 
            imagerotationButton.Name = "imagerotationButton";
            imagerotationButton.Size = new Size(359, 28);
            imagerotationButton.Text = "Görüntü Döndürme";
            imagerotationButton.Click += imagerotationButton_Click;
            // 
            // imagecroppingButton
            // 
            imagecroppingButton.Name = "imagecroppingButton";
            imagecroppingButton.Size = new Size(359, 28);
            imagecroppingButton.Text = "Görüntü Kırpma";
            // 
            // imagezoomingButton
            // 
            imagezoomingButton.Name = "imagezoomingButton";
            imagezoomingButton.Size = new Size(359, 28);
            imagezoomingButton.Text = "Görüntü Yaklaştırma/Uzaklaştırma";
            imagezoomingButton.Click += imagezoomingButton_Click;
            // 
            // arithmetictransformationButton
            // 
            arithmetictransformationButton.DropDownItems.AddRange(new ToolStripItem[] { addimageButton, multiplyimageButton });
            arithmetictransformationButton.Name = "arithmetictransformationButton";
            arithmetictransformationButton.Size = new Size(278, 28);
            arithmetictransformationButton.Text = "Aritmetik Dönüşümler";
            // 
            // addimageButton
            // 
            addimageButton.Name = "addimageButton";
            addimageButton.Size = new Size(208, 28);
            addimageButton.Text = "Resim Ekleme";
            addimageButton.Click += addimageButton_Click;
            // 
            // multiplyimageButton
            // 
            multiplyimageButton.Name = "multiplyimageButton";
            multiplyimageButton.Size = new Size(208, 28);
            multiplyimageButton.Text = "Resim Çarpma";
            multiplyimageButton.Click += multiplyimageButton_Click;
            // 
            // colortransformationButton
            // 
            colortransformationButton.DropDownItems.AddRange(new ToolStripItem[] { graytransformationButton, binarytransformationButton, colorspaceButton });
            colortransformationButton.Name = "colortransformationButton";
            colortransformationButton.Size = new Size(278, 28);
            colortransformationButton.Text = "Renk Dönüşümleri";
            // 
            // graytransformationButton
            // 
            graytransformationButton.Name = "graytransformationButton";
            graytransformationButton.Size = new Size(285, 28);
            graytransformationButton.Text = "Gri (Gray) Dönüşüm";
            graytransformationButton.Click += graytransformationButton_Click;
            // 
            // binarytransformationButton
            // 
            binarytransformationButton.Name = "binarytransformationButton";
            binarytransformationButton.Size = new Size(285, 28);
            binarytransformationButton.Text = "İkili (Binary) Dönüşüm";
            binarytransformationButton.Click += binarytransformationButton_Click;
            // 
            // colorspaceButton
            // 
            colorspaceButton.DropDownItems.AddRange(new ToolStripItem[] { RGBtoHSVButton });
            colorspaceButton.Name = "colorspaceButton";
            colorspaceButton.Size = new Size(285, 28);
            colorspaceButton.Text = "Renk Uzayı Dönüşümleri";
            // 
            // RGBtoHSVButton
            // 
            RGBtoHSVButton.Name = "RGBtoHSVButton";
            RGBtoHSVButton.Size = new Size(178, 28);
            RGBtoHSVButton.Text = "RGB - HSV";
            RGBtoHSVButton.Click += RGBtoHSVButton_Click;
            // 
            // brightnessButton
            // 
            brightnessButton.Name = "brightnessButton";
            brightnessButton.Size = new Size(278, 28);
            brightnessButton.Text = "Parlaklık Ayarı";
            brightnessButton.Click += brightnessButton_Click;
            // 
            // navbarHistogram
            // 
            navbarHistogram.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarHistogram.DropDownItems.AddRange(new ToolStripItem[] { imagehistogramButton });
            navbarHistogram.ImageTransparentColor = Color.Magenta;
            navbarHistogram.Name = "navbarHistogram";
            navbarHistogram.Size = new Size(108, 28);
            navbarHistogram.Text = "Histogram";
            // 
            // imagehistogramButton
            // 
            imagehistogramButton.Name = "imagehistogramButton";
            imagehistogramButton.Size = new Size(284, 28);
            imagehistogramButton.Text = "Histogram Dönüşümleri";
            imagehistogramButton.Click += imagehistogramButton_Click;
            // 
            // navbarThresholding
            // 
            navbarThresholding.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarThresholding.DropDownItems.AddRange(new ToolStripItem[] { adaptiveButton });
            navbarThresholding.ImageTransparentColor = Color.Magenta;
            navbarThresholding.Name = "navbarThresholding";
            navbarThresholding.Size = new Size(92, 28);
            navbarThresholding.Text = "Eşikleme";
            // 
            // adaptiveButton
            // 
            adaptiveButton.Name = "adaptiveButton";
            adaptiveButton.Size = new Size(226, 28);
            adaptiveButton.Text = "Adaptif Eşikleme";
            adaptiveButton.Click += adaptiveButton_Click;
            // 
            // navbarFilterNoise
            // 
            navbarFilterNoise.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarFilterNoise.DropDownItems.AddRange(new ToolStripItem[] { convolutionButton, addnoiseButton, removenoiseButton, blurringButton });
            navbarFilterNoise.ImageTransparentColor = Color.Magenta;
            navbarFilterNoise.Name = "navbarFilterNoise";
            navbarFilterNoise.Size = new Size(148, 28);
            navbarFilterNoise.Text = "Filtre ve Gürültü";
            // 
            // convolutionButton
            // 
            convolutionButton.Name = "convolutionButton";
            convolutionButton.Size = new Size(288, 28);
            convolutionButton.Text = "Konvolüsyon (Gauss)";
            convolutionButton.Click += convolutionButton_Click;
            // 
            // addnoiseButton
            // 
            addnoiseButton.DropDownItems.AddRange(new ToolStripItem[] { saltpepperButton });
            addnoiseButton.Name = "addnoiseButton";
            addnoiseButton.Size = new Size(288, 28);
            addnoiseButton.Text = "Gürültü Ekleme";
            // 
            // saltpepperButton
            // 
            saltpepperButton.Name = "saltpepperButton";
            saltpepperButton.Size = new Size(195, 28);
            saltpepperButton.Text = "Salt - Pepper";
            saltpepperButton.Click += saltpepperButton_Click;
            // 
            // removenoiseButton
            // 
            removenoiseButton.DropDownItems.AddRange(new ToolStripItem[] { meanfilterButton, medianfilterButton });
            removenoiseButton.Name = "removenoiseButton";
            removenoiseButton.Size = new Size(288, 28);
            removenoiseButton.Text = "Gürültü Temizleme";
            // 
            // meanfilterButton
            // 
            meanfilterButton.Name = "meanfilterButton";
            meanfilterButton.Size = new Size(285, 28);
            meanfilterButton.Text = "Ortalama (Mean) Filtresi";
            meanfilterButton.Click += meanfilterButton_Click;
            // 
            // medianfilterButton
            // 
            medianfilterButton.Name = "medianfilterButton";
            medianfilterButton.Size = new Size(285, 28);
            medianfilterButton.Text = "Ortanca (Median) Filtresi";
            medianfilterButton.Click += medianfilterButton_Click;
            // 
            // blurringButton
            // 
            blurringButton.Name = "blurringButton";
            blurringButton.Size = new Size(288, 28);
            blurringButton.Text = "Bulanıklaştırma (Blurring)";
            blurringButton.Click += blurringButton_Click;
            // 
            // navbarEdge
            // 
            navbarEdge.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarEdge.DropDownItems.AddRange(new ToolStripItem[] { sobelButton });
            navbarEdge.ImageTransparentColor = Color.Magenta;
            navbarEdge.Name = "navbarEdge";
            navbarEdge.Size = new Size(122, 28);
            navbarEdge.Text = "Kenar Tespiti";
            // 
            // sobelButton
            // 
            sobelButton.Name = "sobelButton";
            sobelButton.Size = new Size(262, 28);
            sobelButton.Text = "Sobel Kenar Algılama";
            sobelButton.Click += sobelButton_Click;
            // 
            // navbarMenu
            // 
            navbarMenu.BackColor = Color.Transparent;
            navbarMenu.Font = new Font("Segoe UI Variable Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            navbarMenu.ImageScalingSize = new Size(20, 20);
            navbarMenu.Items.AddRange(new ToolStripItem[] { toolStripLabel1, navbarFile, navbarTransformations, navbarHistogram, navbarThresholding, navbarFilterNoise, navbarEdge, navbarMorphology });
            navbarMenu.LayoutStyle = ToolStripLayoutStyle.Flow;
            navbarMenu.Location = new Point(0, 0);
            navbarMenu.Name = "navbarMenu";
            navbarMenu.Size = new Size(911, 31);
            navbarMenu.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.BackgroundImageLayout = ImageLayout.Center;
            toolStripLabel1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripLabel1.Image = Properties.Resources.visimorph1;
            toolStripLabel1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripLabel1.Margin = new Padding(0, 5, 0, 0);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(80, 20);
            // 
            // navbarMorphology
            // 
            navbarMorphology.DisplayStyle = ToolStripItemDisplayStyle.Text;
            navbarMorphology.DropDownItems.AddRange(new ToolStripItem[] { dilationButton, erosionButton, openingButton, closingButton });
            navbarMorphology.ImageTransparentColor = Color.Magenta;
            navbarMorphology.Name = "navbarMorphology";
            navbarMorphology.Size = new Size(97, 28);
            navbarMorphology.Text = "Morfoloji";
            // 
            // dilationButton
            // 
            dilationButton.Name = "dilationButton";
            dilationButton.Size = new Size(251, 28);
            dilationButton.Text = "Genişleme (Dilation)";
            dilationButton.Click += dilationButton_Click;
            // 
            // erosionButton
            // 
            erosionButton.Name = "erosionButton";
            erosionButton.Size = new Size(251, 28);
            erosionButton.Text = "Aşınma (Erosion)";
            erosionButton.Click += erosionButton_Click;
            // 
            // openingButton
            // 
            openingButton.Name = "openingButton";
            openingButton.Size = new Size(251, 28);
            openingButton.Text = "Açma (Opening)";
            openingButton.Click += openingButton_Click;
            // 
            // closingButton
            // 
            closingButton.Name = "closingButton";
            closingButton.Size = new Size(251, 28);
            closingButton.Text = "Kapama (Closing)";
            closingButton.Click += closingButton_Click;
            // 
            // appPanel
            // 
            appPanel.AutoScroll = true;
            appPanel.BackColor = Color.FromArgb(64, 64, 64);
            appPanel.Dock = DockStyle.Fill;
            appPanel.Location = new Point(0, 31);
            appPanel.Margin = new Padding(501, 500, 501, 500);
            appPanel.Name = "appPanel";
            appPanel.Size = new Size(911, 588);
            appPanel.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(911, 619);
            Controls.Add(appPanel);
            Controls.Add(navbarMenu);
            Name = "Main";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VisiMorph";
            navbarMenu.ResumeLayout(false);
            navbarMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog imageopenFileDialog;
        private ToolStripDropDownButton navbarFile;
        private ToolStripMenuItem fileopenButton;
        private ToolStripMenuItem filecloseButton;
        private ToolStripMenuItem filesaveButton;
        private ToolStripDropDownButton navbarTransformations;
        private ToolStripMenuItem geometrictransformationButton;
        private ToolStripMenuItem imagerotationButton;
        private ToolStripMenuItem imagecroppingButton;
        private ToolStripMenuItem imagezoomingButton;
        private ToolStripMenuItem arithmetictransformationButton;
        private ToolStripMenuItem addimageButton;
        private ToolStripMenuItem multiplyimageButton;
        private ToolStripMenuItem colortransformationButton;
        private ToolStripMenuItem graytransformationButton;
        private ToolStripMenuItem binarytransformationButton;
        private ToolStripMenuItem colorspaceButton;
        private ToolStripMenuItem brightnessButton;
        private ToolStripDropDownButton navbarHistogram;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripDropDownButton navbarThresholding;
        private ToolStripMenuItem adaptiveButton;
        private ToolStripDropDownButton navbarFilterNoise;
        private ToolStripDropDownButton navbarEdge;
        private ToolStripMenuItem sobelButton;
        private ToolStrip navbarMenu;
        private ToolStripDropDownButton navbarMorphology;
        private ToolStripMenuItem dilationButton;
        private ToolStripMenuItem erosionButton;
        private ToolStripMenuItem openingButton;
        private ToolStripMenuItem closingButton;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem convolutionButton;
        private ToolStripMenuItem addnoiseButton;
        private ToolStripMenuItem saltpepperButton;
        private ToolStripMenuItem removenoiseButton;
        private ToolStripMenuItem meanfilterButton;
        private ToolStripMenuItem medianfilterButton;
        private ToolStripMenuItem blurringButton;
        private Panel appPanel;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem imagehistogramButton;
        private ToolStripLabel toolStripLabel1;
        private SaveFileDialog imagesaveFileDialog;
        private ToolStripMenuItem RGBtoHSVButton;
    }
}

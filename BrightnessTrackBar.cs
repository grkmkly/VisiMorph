using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisiMorph
{
    public partial class BrightnessTrackBar : Form
    {
        public BrightnessTrackBar()
        {
            InitializeComponent();
        }
        public int trackbarValue = 0;
        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            trackbarValue = brightTrackBar.Value;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brightTrackBar_Scroll(object sender, EventArgs e)
        {
            brightnessLabel.Text = $"Seçili Değer: {brightTrackBar.Value}";
        }
    }
}

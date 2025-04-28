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
    public partial class RGBtoHSVTrackBar : Form
    {
        public RGBtoHSVTrackBar()
        {
            InitializeComponent();
        }

        public double H;
        public double S;
        public double V;
        private void okButton_Click(object sender, EventArgs e)
        {
            H = hTrackBar.Value;
            S = (sTrackBar.Value / 100.0);
            V = (vTrackBar.Value / 100.0);
            this.DialogResult = DialogResult.OK;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hTrackBar_Scroll(object sender, EventArgs e)
        {
            hLabel.Text = hTrackBar.Value.ToString();
        }

        private void sTrackBar_Scroll(object sender, EventArgs e)
        {
            sLabel.Text = ((float)sTrackBar.Value / 100).ToString();
        }

        private void vTrackBar_Scroll(object sender, EventArgs e)
        {
            vLabel.Text = ((float)vTrackBar.Value / 100).ToString();
        }
    }
}

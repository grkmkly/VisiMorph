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
    public partial class ThresholdTrackBar : Form
    {
        public ThresholdTrackBar()
        {
            InitializeComponent();
        }

        public int trackbarValue = 0;
        private void tobinaryTrackBar_Scroll(object sender, EventArgs e)
        {
            valueLabel.Text = tobinaryTrackBar.Value.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            trackbarValue = tobinaryTrackBar.Value;
        }
    }
}

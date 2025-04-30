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
    public partial class SaltPepperForm : Form
    {
        public SaltPepperForm()
        {
            InitializeComponent();
        }

        public int totalNoiseRatioValue;
        public int saltRatioValue;

        private void saltRatio_ValueChanged(object sender, EventArgs e)
        {
            pepperRatioInput.Value = (100 - saltRatioInput.Value);
        }

        private void pepperRatio_ValueChanged(object sender, EventArgs e)
        {
            saltRatioInput.Value = (100 - pepperRatioInput.Value);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            totalNoiseRatioValue = (int)saltpepperRatioInput.Value;
            saltRatioValue = (int)saltRatioInput.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

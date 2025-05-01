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
    public partial class GaussForm : Form
    {
        public GaussForm()
        {
            InitializeComponent();
        }

        public int gaussMatrixSize;
        public float sigma;
        public bool fillEdge;
        private void okButton_Click(object sender, EventArgs e)
        {
            if (fillRadioButton.Checked)
            {
                fillEdge = true;
            }

            else if (notfillRadioButton.Checked)
            {
                fillEdge = false;
            }

            else { fillEdge = false; }

            sigma = (float)sigmaInput.Value;
            gaussMatrixSize = (int)gausssizeInput.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void flltermatrixInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

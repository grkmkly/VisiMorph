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
    public partial class ImageRotationForm : Form
    {
        public ImageRotationForm()
        {
            InitializeComponent();
        }

        public int degreeValue;
        private void okButton_Click(object sender, EventArgs e)
        {
            degreeValue = (int)degreeInput.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

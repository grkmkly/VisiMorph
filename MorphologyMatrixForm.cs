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
    public partial class MorphologyMatrixForm : Form
    {
        public MorphologyMatrixForm()
        {
            InitializeComponent();
        }

        private void creatematrixButton_Click(object sender, EventArgs e)
        {
            int matrixWidth = (int)matrixwidthInput.Value;
            int matrixHeight = (int)matrixheightInput.Value;
            matrixDataGridView.Columns.Clear();

            for (int i = 0; i < matrixWidth; i++) 
            {
                matrixDataGridView.Columns.Add($"matrix{i}column", $"{i}. sütun");
            }


            /*
            int[,] kernelMatrix = new int[matrixWidth, matrixHeight];

            for (int y = 0; y < matrixHeight; y++)
            {
                for (int x = 0; x < matrixWidth; x++)
                {
                    kernelMatrix[x, y] = 0; 
                }
            }
            */
        }
    }
}

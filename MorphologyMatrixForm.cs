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
        int matrixWidth;
        int matrixHeight;
        public int[,] kernelMatrix { get; private set; }
        private void creatematrixButton_Click(object sender, EventArgs e)
        {
            matrixWidth = (int)matrixwidthInput.Value;
            matrixHeight = (int)matrixheightInput.Value;
            matrixDataGridView.Columns.Clear();

            for (int i = 0; i < matrixWidth; i++)
            {
                matrixDataGridView.Columns.Add($"matrix{i + i}column", $"{i + 1}. sütun");
            }

        }

        private void rowaddButton_Click(object sender, EventArgs e)
        {
            if (matrixDataGridView.Rows.Count < matrixHeight)
            {
                matrixDataGridView.Rows.Add();
            }

            else
            {
                MessageBox.Show("Maksimum satır sayısına ulaştınız.");
            }
        }

        private void rowdeleteButton_Click(object sender, EventArgs e)
        {
            int lastRowIndex = matrixDataGridView.Rows.Count - 1;

            if (lastRowIndex >= 0)
            {
                matrixDataGridView.Rows.RemoveAt(lastRowIndex);
                lastRowIndex--;
            }

            else
            {
                MessageBox.Show("Silinecek satır bulunamadı.");
            }
        }

        private bool isWarned = false;

        private void matrixDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string cellInputValue = e.FormattedValue.ToString();
            // Satır yeni ekleniyorsa ve boşsa validasyonu atla
            if (matrixDataGridView.Rows[e.RowIndex].IsNewRow) return;

            // Boş bırakma kontrolü istenmiyorsa aşağıdaki satırı kaldırabilirsin
            if (string.IsNullOrWhiteSpace(cellInputValue))
            {
                if (!isWarned)
                {
                    MessageBox.Show("Hücre boş bırakılamaz.");
                    isWarned = true;
                }

                e.Cancel = false;
            }
            else
            {
                isWarned = false; // geçerli değer girildiğinde uyarı hakkını sıfırla
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            int emptyCellCounter = 0;
            foreach (DataGridViewRow row in matrixDataGridView.Rows)
            {
                if (row.IsNewRow) continue;
                emptyCellCounter = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var value = cell.Value?.ToString();

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        emptyCellCounter++;
                    }
                }
            }
            if (emptyCellCounter > 0)
            {
                MessageBox.Show("Boş hücre bıraktınız, lütfen doldurun.");
            }

            else
            {
                int[,] convertedKernelMatrix = new int[matrixHeight, matrixWidth];
                int rowCounter = 0;
                int cellCounter = 0;
                foreach (DataGridViewRow row in matrixDataGridView.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        var value = Convert.ToInt32(cell.Value);
                        convertedKernelMatrix[rowCounter, cellCounter] = value;
                        cellCounter++;
                    }
                    cellCounter = 0;
                    rowCounter++;
                }
                kernelMatrix = convertedKernelMatrix;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

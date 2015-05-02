using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace numerical_analysis
{
    public partial class FormNumericalAnalysis : Form
    {
        public const int samplesXIndex = 0;
        public const int samplesYIndex = 1;
        public FormNumericalAnalysis()
        {
            InitializeComponent();
        }

        private void dataGridViewSamplesInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dataGridViewSamplesInput_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() == string.Empty)
            {
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Required";
                e.Cancel = true;
            }
            string newValue = (string)e.FormattedValue;

            // try to see if this is still a double
            double value = 0;
            if (!double.TryParse(newValue, out value))
            {
                // if this isn't a double then clear the cell
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Not Valid Number";
                e.Cancel = true;
            }
            else
            {
                // else set this cell to the new filtered value
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void dataGridViewSamplesInput_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView currentView = (DataGridView)sender;

            DataGridViewRow currentRow = currentView.Rows[e.RowIndex];
            if (currentRow.IsNewRow) return;

            bool AllCellsFromPrevRowHasVal = true;
            for (int i = 0; i < currentRow.Cells.Count; i++)
            {
                string cellVal = (string)currentRow.Cells[i].Value;
                if (cellVal == null || cellVal == "")
                {
                    AllCellsFromPrevRowHasVal = false;
                    break;
                }
            }
            if (!AllCellsFromPrevRowHasVal)
            {
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Required";
                e.Cancel = true;
            }
            else
            {
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }

        }



    }
}

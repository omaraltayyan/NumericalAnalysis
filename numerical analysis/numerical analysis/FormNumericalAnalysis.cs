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
<<<<<<< HEAD

        private void dataGridViewSamplesInput_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() == string.Empty)
            {
                dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Required";
                e.Cancel = true;
            }
            string newValue = (string)e.FormattedValue;
=======

        private void dataGridViewSamplesInput_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.

            if (dataGridViewSamplesInput.Rows[e.RowIndex].IsNewRow) { return; }

            // go through all columns, if one of them has a value then so must be this one
            for (int i = 0; i < dataGridViewSamplesInput.ColumnCount; i++)
            {
                if (i != e.ColumnIndex)
                {
                    if (e.FormattedValue.ToString() == "" && (dataGridViewSamplesInput[i, e.RowIndex].FormattedValue.ToString() != null &&
                        dataGridViewSamplesInput[i, e.RowIndex].FormattedValue.ToString() != ""))
                    {
                        dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Required";
                        e.Cancel = true;
                        return;
                    }
                }
            }

            // copy the formatted value
            string newValue = new string(e.FormattedValue.ToString().ToCharArray());

            // clear all .'s other than the first
            bool isfirstdot = true;
            for (int i = 0; i < newValue.Length; i++)
            {
                if (newValue[i] == '.')
                {
                    if (isfirstdot)
                    {
                        isfirstdot = false;
                    }
                    else
                    {
                        newValue = newValue.Remove(i, 1);
                        dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].Value = newValue;
                        i--;
                    }
                }
            }



>>>>>>> corrected some UI behaviour

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
<<<<<<< HEAD
        {
            DataGridView currentView = (DataGridView)sender;

            DataGridViewRow currentRow = currentView.Rows[e.RowIndex];
            if (currentRow.IsNewRow) return;

=======
        {  
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.

            if (dataGridViewSamplesInput.Rows[e.RowIndex].IsNewRow) { return; }

            DataGridView currentView = (DataGridView)sender;

            DataGridViewRow currentRow = currentView.Rows[e.RowIndex];
            if (currentRow.IsNewRow) return;

>>>>>>> corrected some UI behaviour
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

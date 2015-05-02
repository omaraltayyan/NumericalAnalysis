using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using numerical_analysis.Method_classes;


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
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.

            if (dataGridViewSamplesInput.Rows[e.RowIndex].IsNewRow) { return; }

            // go through all columns, if one of them has a value then so must be this one
            for (int i = 0; i < dataGridViewSamplesInput.ColumnCount; i++)
            {
                if (i != e.ColumnIndex)
                {
                    if ((string)dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].Value == "" && (dataGridViewSamplesInput[i, e.RowIndex].FormattedValue.ToString() != null &&
                        dataGridViewSamplesInput[i, e.RowIndex].FormattedValue.ToString() != ""))
                    {
                        dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].ErrorText = "Required";
                        e.Cancel = true;
                        return;
                    }
                }
            }

            // copy the formatted value
            string newValue = new string(e.FormattedValue.ToString().ToCharArray()).Trim();

            // clear all .'s other than the first
            bool isfirstdot = true;
            for (int i = 0; i < newValue.Length; i++)
            {
                if (newValue[i] == '.')
                {
                    // if this isn't the first dot we encounter then or their is no 
                    // other characters after it then delete it
                    if (i == newValue.Length || !isfirstdot)
                    {
                        newValue = newValue.Remove(i, 1);
                        dataGridViewSamplesInput[e.ColumnIndex, e.RowIndex].Value = newValue;
                        dataGridViewSamplesInput.RefreshEdit();
                        i--;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            i++;
                            newValue = newValue.Insert(0, "0");
                        }
                        isfirstdot = false;
                    }
                }
            }


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

            updateSolutions();
        }

        private void updateSolutions()
        {
            dataGridViewSamplesInput.EndEdit();
            // check if the input is complete
            bool haveCompleteInput = true;
            int rowsCounter = 0;
            for (int i = 0; i < dataGridViewSamplesInput.Rows.Count; i++)
            {
                DataGridViewRow currentRow = dataGridViewSamplesInput.Rows[i];
                    // if only one of the cells in the row has a value and the other doesn't
                if ((currentRow.Cells[samplesXIndex].Value == null || (string)currentRow.Cells[samplesXIndex].Value == "") ^ 
                     (currentRow.Cells[samplesYIndex].Value == null ||(string) currentRow.Cells[samplesYIndex].Value == ""))
                {
                    haveCompleteInput = false;
                }
                // if the row is not empty then count it
                if (currentRow.Cells[samplesXIndex].Value != null && (string)currentRow.Cells[samplesXIndex].Value != "")
                {
                    rowsCounter++;
                }
                
            }


            // make sure that the input we have is full before we start to collect samples
            if (haveCompleteInput && rowsCounter > 0)
            {
                double[,] interpolationSamples = new double[2, rowsCounter];


                // collect samples from the grid view
                for (int i = 0; i < dataGridViewSamplesInput.Rows.Count; i++)
                {
                    DataGridViewRow currentRow = dataGridViewSamplesInput.Rows[i];
                    if (currentRow.Cells[samplesXIndex].Value != null && (string)currentRow.Cells[samplesXIndex].Value != "")
                    {
                        interpolationSamples[samplesXIndex, i] = double.Parse((string)currentRow.Cells[samplesXIndex].Value);
                        interpolationSamples[samplesYIndex, i] = double.Parse((string)currentRow.Cells[samplesYIndex].Value);
                    }
                }

                // clear results view
                textBoxOutputResults.Clear();


                // General Method Code
                GeneralMethodFunction generalMethod = new GeneralMethodFunction(interpolationSamples);
                if (generalMethod.isSolvable && checkBoxGeneralMethod.Checked)
                {
                    textBoxOutputResults.AppendText("General Method's Solution: \n\n" + generalMethod.FunctionString);
                }







#warning add your method calling code here


            }
        }

        private void dataGridViewSamplesInput_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridViewSamplesInput.Rows[e.RowIndex].IsNewRow) { return; }

            DataGridView currentView = (DataGridView)sender;

            DataGridViewRow currentRow = currentView.Rows[e.RowIndex];
            if (currentRow.IsNewRow) return;

            bool AllCellsFromPrevRowHasVal = true;
            int cellIndex = e.ColumnIndex;
            for (int i = 0; i < currentRow.Cells.Count; i++)
            {
                string cellVal = (string)currentRow.Cells[i].Value;
                if (cellVal == null || cellVal == "")
                {
                    cellIndex = i;
                    AllCellsFromPrevRowHasVal = false;
                    break;
                }
            }
            if (!AllCellsFromPrevRowHasVal)
            {
                dataGridViewSamplesInput[cellIndex, e.RowIndex].ErrorText = "Required";
                e.Cancel = true;
            }
            else
            {
                dataGridViewSamplesInput[cellIndex, e.RowIndex].ErrorText = string.Empty;
            }

        }



    }
}

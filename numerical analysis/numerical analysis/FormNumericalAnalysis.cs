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
        public const int samplesYDerivativeIndex = 2;
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

            DataGridView currentView = (DataGridView)sender;

            DataGridViewCell currentCell = currentView[e.ColumnIndex, e.RowIndex];

            DataGridViewRow currentRow = currentView.Rows[e.RowIndex];

            DataGridViewColumnCollection allColumns = currentView.Columns;

            DataGridViewRowCollection allRows = currentView.Rows;

            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.



            if (allRows[e.RowIndex].IsNewRow) { return; }
            if (allColumns[e.ColumnIndex].ReadOnly) return;

            bool allOtherEnabledCellsHaveValue = true;
            // go through all columns, if one of them has a value then so must be this one
            for (int i = 0; i < allColumns.Count; i++)
            {
                // if the current column is enabled
                if (!allColumns[i].ReadOnly && i != e.ColumnIndex)
                {
                    DataGridViewCell comparedCell = currentView[i, e.RowIndex];

                    if (cellDoesntHaveValue(comparedCell))
                    {
                        allOtherEnabledCellsHaveValue = false;  
                    }
                }
            }
            if (allOtherEnabledCellsHaveValue && cellDoesntHaveValue(currentCell))
            {
                currentCell.ErrorText = "Required";
                e.Cancel = true;
                return;
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
                        currentCell.Value = newValue;
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
                currentCell.ErrorText = "Not Valid Number";
                e.Cancel = true;
            }
            else
            {
                // else set this cell to the new filtered value
                currentCell.ErrorText = string.Empty;
            }

            updateSolutions();
        }

        private void updateSolutions()
        {
            // make the grid view apply it's changes to it's data cache
            dataGridViewSamplesInput.EndEdit();

            clearDataGridDuplicateEnteries();

            List<DataGridViewRow> validRows = new List<DataGridViewRow>();
            for (int i = 0; i < dataGridViewSamplesInput.Rows.Count; i++)
            {
                if (dataGridViewSamplesInput.Rows[i].Visible)
                {
                    validRows.Add(dataGridViewSamplesInput.Rows[i]);
                }
            }

            // check if the input is complete
            bool twoColumnsCompleteInput = true;
            int twoColumnsCompleteRowsCounter = 0;
            for (int i = 0; i < validRows.Count; i++)
            {
                DataGridViewRow currentRow = validRows[i];
                // if only one of the cells in the row has a value and the other doesn't
                if (cellDoesntHaveValue(currentRow.Cells[samplesXIndex]) ^ cellDoesntHaveValue(currentRow.Cells[samplesYIndex]))
                {
                    twoColumnsCompleteInput = false;
                }
                // if the row is not empty then count it
                if (cellHasValue(currentRow.Cells[samplesXIndex]))
                {
                    twoColumnsCompleteRowsCounter++;
                }

            }


            // make sure that the input we have is full before we start to collect samples
            if (twoColumnsCompleteInput && twoColumnsCompleteRowsCounter > 0)
            {
                double[,] twoColumnsInterpolationSamples = new double[2, twoColumnsCompleteRowsCounter];


                // collect samples from the grid view
                for (int i = 0; i < validRows.Count; i++)
                {
                    DataGridViewRow currentRow = validRows[i];
                    if (cellHasValue(currentRow.Cells[samplesXIndex]))
                    {
                        twoColumnsInterpolationSamples[samplesXIndex, i] = double.Parse(currentRow.Cells[samplesXIndex].Value.ToString());
                        twoColumnsInterpolationSamples[samplesYIndex, i] = double.Parse(currentRow.Cells[samplesYIndex].Value.ToString());
                    }
                }

                // clear results view
                textBoxOutputResults.Clear();

                // General Method Code
                GeneralMethodFunction generalMethod = new GeneralMethodFunction(twoColumnsInterpolationSamples);
                if (generalMethod.isSolvable && checkBoxGeneralMethod.Checked)
                {
                    textBoxOutputResults.AppendText("General Method's Solution:");
                    textBoxOutputResults.Text += "\r\n\r\n";
                    textBoxOutputResults.AppendText(generalMethod.FunctionString);
                    if (stringNotEmpty(textBoxPerdictValue.Text))
                    {
                        textBoxOutputResults.Text += "\r\n\r\n";
                        textBoxOutputResults.AppendText(generalMethod.YForXString(textBoxPerdictValue.Text));
                    }
                    textBoxOutputResults.Text += "\r\n\r\n";
                }
                // end of general method


                // Lagrange method code
                LagrangeMethod lagrangeMethod = new LagrangeMethod(twoColumnsInterpolationSamples);
                if (lagrangeMethod.isSolvable && checkBoxLagrangeMethod.Checked)
                {
                    textBoxOutputResults.AppendText("Lagrange Method's Solution:");
                    textBoxOutputResults.Text += "\r\n\r\n";
                    textBoxOutputResults.AppendText(lagrangeMethod.FunctionString);
                    if (stringNotEmpty(textBoxPerdictValue.Text))
                    {
                        textBoxOutputResults.Text += "\r\n\r\n";
                        textBoxOutputResults.AppendText(lagrangeMethod.YForXString(textBoxPerdictValue.Text));
                        if (stringNotEmpty(textBoxLagrangeDifferential.Text))
                        {
                            textBoxOutputResults.Text += "\r\n\r\n";
                            textBoxOutputResults.AppendText(lagrangeMethod.ErrorStringForX(textBoxPerdictValue.Text, textBoxLagrangeDifferential.Text));
                        }
                    }
                    textBoxOutputResults.Text += "\r\n\r\n";
                }


                // end of Lagrange method's code

                // Lagrange differentiation method code
                LagrangeMethod lagrangeDifferentialMethod = new LagrangeMethod(twoColumnsInterpolationSamples);
                if (lagrangeDifferentialMethod.isSolvable && checkBoxLagrangeDifferentiation.Checked)
                {
                    textBoxOutputResults.AppendText("Lagrange's differential Method's Solution:");
                    textBoxOutputResults.Text += "\r\n\r\n";
                    textBoxOutputResults.AppendText(lagrangeDifferentialMethod.FunctionString);
                    if (stringNotEmpty(textBoxPerdictValue.Text))
                    {
                        textBoxOutputResults.Text += "\r\n\r\n";
                        textBoxOutputResults.AppendText(lagrangeDifferentialMethod.YForXString(textBoxPerdictValue.Text));
                    }
                    textBoxOutputResults.Text += "\r\n\r\n";
                }


                // end of Lagrange differentiation method's code


#warning add your two columns (x, y) method calling code here

                // hermit method code
                bool ThreeColumnsInputComplete = true;
                int ThreeColumnCompleteRowsCounter = 0;
                if (!checkBoxHermitMethod.Checked) ThreeColumnsInputComplete = false;
                else
                {
                    // check the y' column for complete input
                    for (int i = 0; i < validRows.Count; i++)
                    {
                        DataGridViewRow currentRow = validRows[i];
                        DataGridViewCell currentCell = currentRow.Cells[samplesYDerivativeIndex];
                        DataGridViewCell comparedRandomCell = currentRow.Cells[samplesXIndex];

                        // since at this point we are sure we have a complete input for methods other that hermit
                        // (i.e X's and Y's columns are complete) we only need to check one cell other that the Y' cell
                        // to see if that row has any values
                        if (cellDoesntHaveValue(currentCell) ^ cellDoesntHaveValue(comparedRandomCell))
                        {
                            ThreeColumnsInputComplete = false;
                        }
                        if (cellHasValue(currentCell))
                        {
                            ThreeColumnCompleteRowsCounter++;
                        }
                    }
                }


                if (ThreeColumnsInputComplete && ThreeColumnCompleteRowsCounter > 0)
                {
                    double[,] threeColumnsInterpolationSamples = new double[3, twoColumnsCompleteRowsCounter];

                    // collect samples for hermit from the grid view
                    for (int i = 0; i < validRows.Count; i++)
                    {
                        DataGridViewRow currentRow = validRows[i];
                        if (cellHasValue(currentRow.Cells[samplesXIndex]))
                        {
                            threeColumnsInterpolationSamples[samplesXIndex, i] = double.Parse(currentRow.Cells[samplesXIndex].Value.ToString());
                            threeColumnsInterpolationSamples[samplesYIndex, i] = double.Parse(currentRow.Cells[samplesYIndex].Value.ToString());
                            threeColumnsInterpolationSamples[samplesYDerivativeIndex, i] = double.Parse(currentRow.Cells[samplesYDerivativeIndex].Value.ToString());
                        }
                    }

#warning add your three columns (x, y, y') method calling code here


                    HermitMethod hermitMethod = new HermitMethod(threeColumnsInterpolationSamples);
                    if (hermitMethod.isSolvable)
                    {
                        textBoxOutputResults.AppendText("Hermit Method's Solution:");
                        textBoxOutputResults.Text += "\r\n\r\n";
                        textBoxOutputResults.AppendText(hermitMethod.FunctionString);
                        if (stringNotEmpty(textBoxPerdictValue.Text))
                        {
                            textBoxOutputResults.Text += "\r\n\r\n";
                            textBoxOutputResults.AppendText(hermitMethod.YForXString(textBoxPerdictValue.Text));
                            textBoxOutputResults.Text += "\r\n\r\n";
                            if (stringNotEmpty(textBoxHermitDifferential.Text))
                            {
                                textBoxOutputResults.AppendText(hermitMethod.ErrorStringForX(textBoxPerdictValue.Text, textBoxHermitDifferential.Text));
                            }
                        }
                        textBoxOutputResults.Text += "\r\n\r\n";
                    }

                }

                // end of hermit's code

                //Spline Method Code
                SplineMethod splinemethod = new SplineMethod(twoColumnsInterpolationSamples);
                if (splinemethod.isSolvable && checkBoxSplineMethod.Checked)
                {
                    textBoxOutputResults.AppendText("Spline Method's Solution:");
                    textBoxOutputResults.Text += "\r\n\r\n";
                    textBoxOutputResults.AppendText(splinemethod.FunctionString);
                    if (textBoxPerdictValue.Text != null && textBoxPerdictValue.Text != "")
                    {
                        textBoxOutputResults.Text += "\r\n\r\n";
                        textBoxOutputResults.AppendText(splinemethod.YForXString(textBoxPerdictValue.Text.Trim()));
                    }
                }

                //end of spline's method

            }
        }
        private void clearDataGridDuplicateEnteries()
        {
            // convenience local variables
            DataGridViewRowCollection allRows = dataGridViewSamplesInput.Rows;

            // begin from the second row
            // check if all x's are unique, if not, make the last one override
            // the ones before it
            for (int i = allRows.Count - 1; i > 0; i--)
            {
                if (allRows[i].Visible == true) // if the row has not been staged for removal before
                {
                    double currentVal;
                    object currentObject = allRows[i].Cells[samplesXIndex].Value;

                    if (currentObject != null && double.TryParse(currentObject.ToString(), out currentVal))
                    {
                        // check all rows before this one
                        for (int j = 0; j < i; j++)
                        {
                            if (allRows[j].Visible == true) // if the row has not been staged for removal before
                            {
                                double comparedVal;
                                object comparedObject = allRows[j].Cells[samplesXIndex].Value;
                                if (comparedObject != null && double.TryParse(comparedObject.ToString(), out comparedVal))
                                {
                                    if (doublesEqual(comparedVal, currentVal)) // duplicate found
                                    {
                                        // stage the row for removal
                                        allRows[j].Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
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

            DataGridViewColumnCollection allColumns = currentView.Columns;

            bool AllCellsFromPrevRowHasVal = true;
            int cellIndex = e.ColumnIndex;
            for (int i = 0; i < currentRow.Cells.Count; i++)
            {
                // if this column is enabled and the cell is empty
                if (!allColumns[i].ReadOnly && cellDoesntHaveValue(currentRow.Cells[i]))
                {
                    // preserve the cell's index and set the input to be not complete
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

        private void textBoxPerdictValue_TextChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }

        private void checkBoxHermitMethod_CheckedChanged(object sender, EventArgs e)
        {
            // if the hermit method is checked then enable the derivative column, else disable it
            var yDerivativeColumn = dataGridViewSamplesInput.Columns[samplesYDerivativeIndex];
            yDerivativeColumn.Visible = yDerivativeColumn.ReadOnly = checkBoxHermitMethod.Checked;
            updateSolutions();
        }

        private void checkBoxGeneralMethod_CheckedChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }
        private void checkBoxLagrangeMethod_CheckedChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }

        private void checkBoxLagrangeDifferentiation_CheckedChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }

        private bool stringNotEmpty(string str)
        {
            return (str != null && str != "");
        }
        private bool stringEmpty(string str)
        {
            return (str == null || str == "");
        }

        private bool cellHasValue(DataGridViewCell cell)
        {
            return (cell.Value != null && cell.Value.ToString() != "")
                || (cell.EditedFormattedValue != null && cell.EditedFormattedValue.ToString() != "");
        }

        private bool cellDoesntHaveValue(DataGridViewCell cell)
        {
            return (cell.EditedFormattedValue == null || cell.EditedFormattedValue.ToString() == "")
                        &&(cell.Value == null || cell.Value.ToString() == "");
        }

        private void textBoxHermitDifferential_TextChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }

        private void textBoxLagrangeDifferential_TextChanged(object sender, EventArgs e)
        {
            updateSolutions();
        }
        private bool doublesEqual(double a, double b)
        {
           
            double difference = Math.Abs(a * .00000001);

            // Compare the values
            return Math.Abs(a - b) <= difference;
            
        }

            //for (int i = 0; i < dataGridViewSamplesInput.Rows.Count; i++)
            //{
            //    if (dataGridViewSamplesInput.Rows[i].Visible == false)
            //    {
            //        dataGridViewSamplesInput.Rows.RemoveAt(i);
            //        i--;
            //    }
            //}

    }
}

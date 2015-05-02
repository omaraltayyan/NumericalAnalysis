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

        private void dataGridViewSamplesInput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentView = (DataGridView)sender;

            // the control is sending negative values sometimes which may cause exceptions
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            DataGridViewCell currentCell = currentView[e.ColumnIndex, e.RowIndex];
            string newValue = (string)currentCell.Value;


            // remove characters other than numbers and '.' from the string
            if (newValue == null) return;
            for (int i = 0; i < newValue.Length; i++)
            {
                if (!Char.IsDigit(newValue[i]) && !(newValue[i] == '.'))
                {
                    newValue = newValue.Remove(i, 1); i--;
                }
            }
            // try to see if this is still a double
            double value = 0;
            if (!double.TryParse(newValue, out value))
            {
                // if this isn't a double then clear the cell
                currentCell.Value = null;
            }
            else
            {
                // else set this cell to the new filtered value
                currentCell.Value = value.ToString().Trim();
            }



            for (int j = 0; j < currentView.Rows.Count; j++)
            {

                DataGridViewRow currentRow = currentView.Rows[j];
                if (currentRow.IsNewRow) continue;

                bool anyCellFromPrevRowHasVal = false;
                for (int i = 0; i < currentRow.Cells.Count; i++)
                {
                    string cellVal = (string)currentRow.Cells[i].Value;
                    if (cellVal != null && cellVal != "")
                    {
                        anyCellFromPrevRowHasVal = true;
                        break;
                    }
                }
                if (!anyCellFromPrevRowHasVal)
                {
                    currentView.Rows.RemoveAt(j);
                    j--;
                }
            }
        }


    }
}

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
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void buttonIntegration_Click(object sender, EventArgs e)
        {
            FormIntegration FI = new FormIntegration();
            FI.ShowDialog();
        }

        private void buttonInterpolation_Click(object sender, EventArgs e)
        {
            FormNumericalAnalysis fnm = new FormNumericalAnalysis();
            fnm.ShowDialog();
        }
    }
}

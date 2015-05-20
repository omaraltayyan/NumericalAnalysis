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
            FormIntegration formIntegration = new FormIntegration();
            this.Visible = false;
            formIntegration.ShowDialog();
            this.Visible = true;
        }

        private void buttonInterpolation_Click(object sender, EventArgs e)
        {
            FormNumericalAnalysis formNumericalAnalysis = new FormNumericalAnalysis();
            this.Visible = false;
            formNumericalAnalysis.ShowDialog();
            this.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForApp aboutBox = new AboutBoxForApp();
            this.Visible = false;
            aboutBox.ShowDialog();
            this.Visible = true;
        }
    }
}

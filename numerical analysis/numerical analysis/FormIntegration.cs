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
    public partial class FormIntegration : Form
    {
        public FormIntegration()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartingForm strf = new StartingForm();
            strf.Show();
        }
    }
}

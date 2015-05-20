namespace numerical_analysis
{
    partial class StartingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonIntegration = new System.Windows.Forms.Button();
            this.buttonInterpolation = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonIntegration
            // 
            this.buttonIntegration.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonIntegration.Location = new System.Drawing.Point(0, 28);
            this.buttonIntegration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonIntegration.Name = "buttonIntegration";
            this.buttonIntegration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonIntegration.Size = new System.Drawing.Size(117, 67);
            this.buttonIntegration.TabIndex = 0;
            this.buttonIntegration.Text = "Integration";
            this.buttonIntegration.UseVisualStyleBackColor = true;
            this.buttonIntegration.Click += new System.EventHandler(this.buttonIntegration_Click);
            // 
            // buttonInterpolation
            // 
            this.buttonInterpolation.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonInterpolation.Location = new System.Drawing.Point(194, 28);
            this.buttonInterpolation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInterpolation.Name = "buttonInterpolation";
            this.buttonInterpolation.Size = new System.Drawing.Size(115, 67);
            this.buttonInterpolation.TabIndex = 1;
            this.buttonInterpolation.Text = "Interpoation";
            this.buttonInterpolation.UseVisualStyleBackColor = true;
            this.buttonInterpolation.Click += new System.EventHandler(this.buttonInterpolation_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(309, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 95);
            this.Controls.Add(this.buttonInterpolation);
            this.Controls.Add(this.buttonIntegration);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartingForm";
            this.Text = "StartingForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIntegration;
        private System.Windows.Forms.Button buttonInterpolation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}
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
            this.SuspendLayout();
            // 
            // buttonIntegration
            // 
            this.buttonIntegration.Location = new System.Drawing.Point(2, 1);
            this.buttonIntegration.Name = "buttonIntegration";
            this.buttonIntegration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonIntegration.Size = new System.Drawing.Size(100, 23);
            this.buttonIntegration.TabIndex = 0;
            this.buttonIntegration.Text = "Integration";
            this.buttonIntegration.UseVisualStyleBackColor = true;
            this.buttonIntegration.Click += new System.EventHandler(this.buttonIntegration_Click);
            // 
            // buttonInterpolation
            // 
            this.buttonInterpolation.Location = new System.Drawing.Point(108, 1);
            this.buttonInterpolation.Name = "buttonInterpolation";
            this.buttonInterpolation.Size = new System.Drawing.Size(99, 23);
            this.buttonInterpolation.TabIndex = 1;
            this.buttonInterpolation.Text = "Interpoation";
            this.buttonInterpolation.UseVisualStyleBackColor = true;
            this.buttonInterpolation.Click += new System.EventHandler(this.buttonInterpolation_Click);
            // 
            // IntegrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 25);
            this.Controls.Add(this.buttonInterpolation);
            this.Controls.Add(this.buttonIntegration);
            this.Name = "IntegrationForm";
            this.Text = "StartingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonIntegration;
        private System.Windows.Forms.Button buttonInterpolation;
    }
}
namespace numerical_analysis
{
    partial class FormIntegration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIntegration));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVariable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUpperBound = new System.Windows.Forms.TextBox();
            this.textBoxLowerBound = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFunctionFormula = new System.Windows.Forms.TextBox();
            this.richTextBoxFunctions = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lower Bound :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Upper Bound :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Variable used :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "hint : use paranthsis ( )   for more Accuracy and use the functions on the right " +
    "for more complicated operations\r\nExample : pow(x,2)/(1 + 2*exp(x)) wich means  x" +
    "^2/(1 + 2e^x)";
            // 
            // textBoxVariable
            // 
            this.textBoxVariable.Location = new System.Drawing.Point(79, 33);
            this.textBoxVariable.Name = "textBoxVariable";
            this.textBoxVariable.Size = new System.Drawing.Size(38, 20);
            this.textBoxVariable.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Examples : x,y,z,etc...";
            // 
            // textBoxUpperBound
            // 
            this.textBoxUpperBound.Location = new System.Drawing.Point(79, 96);
            this.textBoxUpperBound.Name = "textBoxUpperBound";
            this.textBoxUpperBound.Size = new System.Drawing.Size(69, 20);
            this.textBoxUpperBound.TabIndex = 6;
            // 
            // textBoxLowerBound
            // 
            this.textBoxLowerBound.Location = new System.Drawing.Point(79, 64);
            this.textBoxLowerBound.Name = "textBoxLowerBound";
            this.textBoxLowerBound.Size = new System.Drawing.Size(69, 20);
            this.textBoxLowerBound.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "f(x) = ";
            // 
            // textBoxFunctionFormula
            // 
            this.textBoxFunctionFormula.Location = new System.Drawing.Point(47, 130);
            this.textBoxFunctionFormula.Name = "textBoxFunctionFormula";
            this.textBoxFunctionFormula.Size = new System.Drawing.Size(194, 20);
            this.textBoxFunctionFormula.TabIndex = 9;
            // 
            // richTextBoxFunctions
            // 
            this.richTextBoxFunctions.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFunctions.Location = new System.Drawing.Point(674, 30);
            this.richTextBoxFunctions.Name = "richTextBoxFunctions";
            this.richTextBoxFunctions.ReadOnly = true;
            this.richTextBoxFunctions.Size = new System.Drawing.Size(327, 436);
            this.richTextBoxFunctions.TabIndex = 10;
            this.richTextBoxFunctions.Text = resources.GetString("richTextBoxFunctions.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Usable functions and operators";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxResult.Location = new System.Drawing.Point(5, 209);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(663, 257);
            this.richTextBoxResult.TabIndex = 12;
            this.richTextBoxResult.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Result :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(655, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(582, 154);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 15;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStripReturn";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "&Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // FormIntegration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 469);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBoxFunctions);
            this.Controls.Add(this.textBoxFunctionFormula);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLowerBound);
            this.Controls.Add(this.textBoxUpperBound);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxVariable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormIntegration";
            this.Text = "FormIntegration";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVariable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUpperBound;
        private System.Windows.Forms.TextBox textBoxLowerBound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFunctionFormula;
        private System.Windows.Forms.RichTextBox richTextBoxFunctions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
    }
}
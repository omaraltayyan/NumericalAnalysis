namespace numerical_analysis
{
    partial class FormNumericalAnalysis
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
            this.dataGridViewSamplesInput = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yderivative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxGeneralMethod = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSplineMethod = new System.Windows.Forms.CheckBox();
            this.checkBoxLagrangeDifferentiation = new System.Windows.Forms.CheckBox();
            this.checkBoxLagrangeMethod = new System.Windows.Forms.CheckBox();
            this.checkBoxHermitMethod = new System.Windows.Forms.CheckBox();
            this.textBoxOutputResults = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPerdictValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHermitDifferential = new System.Windows.Forms.TextBox();
            this.textBoxLagrangeDifferential = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSamplesInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSamplesInput
            // 
            this.dataGridViewSamplesInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewSamplesInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSamplesInput.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewSamplesInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSamplesInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Yderivative});
            this.dataGridViewSamplesInput.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewSamplesInput.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewSamplesInput.Name = "dataGridViewSamplesInput";
            this.dataGridViewSamplesInput.RowTemplate.Height = 26;
            this.dataGridViewSamplesInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewSamplesInput.Size = new System.Drawing.Size(362, 426);
            this.dataGridViewSamplesInput.TabIndex = 0;
            this.dataGridViewSamplesInput.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewSamplesInput_CellValidating);
            this.dataGridViewSamplesInput.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSamplesInput_RowValidating);
            this.dataGridViewSamplesInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewSamplesInput_KeyPress);
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X.ToolTipText = "The x\'s input";
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y.ToolTipText = "The y\'s column";
            // 
            // Yderivative
            // 
            this.Yderivative.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Yderivative.HeaderText = "Y\'";
            this.Yderivative.Name = "Yderivative";
            this.Yderivative.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Yderivative.ToolTipText = "The derivative of y\'s column";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "enter you samples to start interpolating";
            // 
            // checkBoxGeneralMethod
            // 
            this.checkBoxGeneralMethod.AutoSize = true;
            this.checkBoxGeneralMethod.Checked = true;
            this.checkBoxGeneralMethod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGeneralMethod.Location = new System.Drawing.Point(6, 23);
            this.checkBoxGeneralMethod.Name = "checkBoxGeneralMethod";
            this.checkBoxGeneralMethod.Size = new System.Drawing.Size(125, 21);
            this.checkBoxGeneralMethod.TabIndex = 2;
            this.checkBoxGeneralMethod.Text = "General Method";
            this.checkBoxGeneralMethod.UseVisualStyleBackColor = true;
            this.checkBoxGeneralMethod.CheckedChanged += new System.EventHandler(this.checkBoxGeneralMethod_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSplineMethod);
            this.groupBox1.Controls.Add(this.checkBoxLagrangeDifferentiation);
            this.groupBox1.Controls.Add(this.checkBoxLagrangeMethod);
            this.groupBox1.Controls.Add(this.checkBoxHermitMethod);
            this.groupBox1.Controls.Add(this.checkBoxGeneralMethod);
            this.groupBox1.Location = new System.Drawing.Point(371, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 300);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Numerical Methods";
            // 
            // checkBoxSplineMethod
            // 
            this.checkBoxSplineMethod.AutoSize = true;
            this.checkBoxSplineMethod.Location = new System.Drawing.Point(7, 132);
            this.checkBoxSplineMethod.Name = "checkBoxSplineMethod";
            this.checkBoxSplineMethod.Size = new System.Drawing.Size(115, 21);
            this.checkBoxSplineMethod.TabIndex = 6;
            this.checkBoxSplineMethod.Text = "Spline Method";
            this.checkBoxSplineMethod.UseVisualStyleBackColor = true;
            // 
            // checkBoxLagrangeDifferentiation
            // 
            this.checkBoxLagrangeDifferentiation.AutoSize = true;
            this.checkBoxLagrangeDifferentiation.Checked = true;
            this.checkBoxLagrangeDifferentiation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLagrangeDifferentiation.Location = new System.Drawing.Point(7, 105);
            this.checkBoxLagrangeDifferentiation.Name = "checkBoxLagrangeDifferentiation";
            this.checkBoxLagrangeDifferentiation.Size = new System.Drawing.Size(225, 21);
            this.checkBoxLagrangeDifferentiation.TabIndex = 5;
            this.checkBoxLagrangeDifferentiation.Text = "Lagrange Differentiation Method";
            this.checkBoxLagrangeDifferentiation.UseVisualStyleBackColor = true;
            this.checkBoxLagrangeDifferentiation.CheckedChanged += new System.EventHandler(this.checkBoxLagrangeDifferentiation_CheckedChanged);
            // 
            // checkBoxLagrangeMethod
            // 
            this.checkBoxLagrangeMethod.AutoSize = true;
            this.checkBoxLagrangeMethod.Checked = true;
            this.checkBoxLagrangeMethod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLagrangeMethod.Location = new System.Drawing.Point(7, 78);
            this.checkBoxLagrangeMethod.Name = "checkBoxLagrangeMethod";
            this.checkBoxLagrangeMethod.Size = new System.Drawing.Size(137, 21);
            this.checkBoxLagrangeMethod.TabIndex = 4;
            this.checkBoxLagrangeMethod.Text = "Lagrange Method";
            this.checkBoxLagrangeMethod.UseVisualStyleBackColor = true;
            this.checkBoxLagrangeMethod.CheckedChanged += new System.EventHandler(this.checkBoxLagrangeMethod_CheckedChanged);
            // 
            // checkBoxHermitMethod
            // 
            this.checkBoxHermitMethod.AutoSize = true;
            this.checkBoxHermitMethod.Checked = true;
            this.checkBoxHermitMethod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHermitMethod.Location = new System.Drawing.Point(6, 50);
            this.checkBoxHermitMethod.Name = "checkBoxHermitMethod";
            this.checkBoxHermitMethod.Size = new System.Drawing.Size(120, 21);
            this.checkBoxHermitMethod.TabIndex = 3;
            this.checkBoxHermitMethod.Text = "Hermit Method";
            this.checkBoxHermitMethod.UseVisualStyleBackColor = true;
            this.checkBoxHermitMethod.CheckedChanged += new System.EventHandler(this.checkBoxHermitMethod_CheckedChanged);
            // 
            // textBoxOutputResults
            // 
            this.textBoxOutputResults.AcceptsReturn = true;
            this.textBoxOutputResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputResults.CausesValidation = false;
            this.textBoxOutputResults.HideSelection = false;
            this.textBoxOutputResults.Location = new System.Drawing.Point(658, 0);
            this.textBoxOutputResults.Multiline = true;
            this.textBoxOutputResults.Name = "textBoxOutputResults";
            this.textBoxOutputResults.ReadOnly = true;
            this.textBoxOutputResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutputResults.Size = new System.Drawing.Size(318, 457);
            this.textBoxOutputResults.TabIndex = 4;
            this.textBoxOutputResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "estimate Value";
            // 
            // textBoxPerdictValue
            // 
            this.textBoxPerdictValue.Location = new System.Drawing.Point(523, 353);
            this.textBoxPerdictValue.Name = "textBoxPerdictValue";
            this.textBoxPerdictValue.Size = new System.Drawing.Size(129, 24);
            this.textBoxPerdictValue.TabIndex = 7;
            this.textBoxPerdictValue.TextChanged += new System.EventHandler(this.textBoxPerdictValue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hermit\'s Differential";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lagrange\'s Differential";
            // 
            // textBoxHermitDifferential
            // 
            this.textBoxHermitDifferential.Location = new System.Drawing.Point(523, 387);
            this.textBoxHermitDifferential.Name = "textBoxHermitDifferential";
            this.textBoxHermitDifferential.Size = new System.Drawing.Size(129, 24);
            this.textBoxHermitDifferential.TabIndex = 10;
            // 
            // textBoxLagrangeDifferential
            // 
            this.textBoxLagrangeDifferential.Location = new System.Drawing.Point(523, 418);
            this.textBoxLagrangeDifferential.Name = "textBoxLagrangeDifferential";
            this.textBoxLagrangeDifferential.Size = new System.Drawing.Size(129, 24);
            this.textBoxLagrangeDifferential.TabIndex = 11;
            // 
            // FormNumericalAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 457);
            this.Controls.Add(this.textBoxLagrangeDifferential);
            this.Controls.Add(this.textBoxHermitDifferential);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPerdictValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOutputResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSamplesInput);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(994, 504);
            this.Name = "FormNumericalAnalysis";
            this.Text = "Numerical Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSamplesInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSamplesInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGeneralMethod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHermitMethod;
        private System.Windows.Forms.TextBox textBoxOutputResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPerdictValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yderivative;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHermitDifferential;
        private System.Windows.Forms.TextBox textBoxLagrangeDifferential;
        private System.Windows.Forms.CheckBox checkBoxLagrangeDifferentiation;
        private System.Windows.Forms.CheckBox checkBoxLagrangeMethod;
        private System.Windows.Forms.CheckBox checkBoxSplineMethod;
    }
}


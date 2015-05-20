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
    public partial class FormIntegration : Form
    {
        static string ErrorList;
        public FormIntegration()
        {
            InitializeComponent();
        }
        public string StringModifier(string fx)
        {
            string new_str = fx;
            new_str = new_str.ToLower();
            new_str = new_str.Replace("sin", "Sin");
            new_str = new_str.Replace("cos", "Cos");
            new_str = new_str.Replace("tan", "Tan");
            new_str = new_str.Replace("asin", "Asin");
            new_str = new_str.Replace("acos", "Acos");
            new_str = new_str.Replace("atan", "Atan");
            new_str = new_str.Replace("pow", "Pow");
            new_str = new_str.Replace("sqrt", "Sqrt");
            new_str = new_str.Replace("abs", "Abs");
            new_str = new_str.Replace("log", "Log");           
            new_str = new_str.Replace("exp", "Exp");
            return new_str;
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Clear();
            if(ValidateAll())
            {
                try
                {
                    string modifiedformula = StringModifier(textBoxFunctionFormula.Text.Trim());
                    double lowerbound = double.Parse(textBoxLowerBound.Text.Trim());
                    double upperbound = double.Parse(textBoxUpperBound.Text.Trim());
                    Integration I;
                    if (lowerbound < upperbound)
                        I = new Integration(modifiedformula, lowerbound, upperbound, textBoxVariable.Text.Trim());
                    else
                        I = new Integration(modifiedformula, upperbound, lowerbound, textBoxVariable.Text.Trim());
                    double rectagleresult = Math.Round(I.RectanglesMethod(), 12);
                    richTextBoxResult.AppendText("Rectangles Method :\nI = ");
                    richTextBoxResult.AppendText(rectagleresult.ToString() + "\n");
                    richTextBoxResult.AppendText("-------------------------------------------\n");
                    double trapezoidresult = Math.Round(I.TrapezoidMethod(), 12);
                    richTextBoxResult.AppendText("Trapzoids Method :\nI = ");
                    richTextBoxResult.AppendText(trapezoidresult.ToString() + "\n");
                    richTextBoxResult.AppendText("-------------------------------------------\n");
                    double simpsonresult = Math.Round(I.SimpsonMethod(), 12);                                     
                    richTextBoxResult.AppendText("Simpson Method :\nI = ");
                    richTextBoxResult.AppendText(simpsonresult.ToString() + "\n");

                }
                catch(DivideByZeroException)
                {
                    MessageBox.Show("This integration will cause to divide by zero which is a case\nnot handled in this methods");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(ErrorList);
            }
        }
        public bool ValidateAll()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("The operation couldn't be completed due to the following error(s) :");
            int cnt = 1;
            double low, hi;
            bool Validated = true;
            if (textBoxVariable.Text.Trim() == string.Empty)
            {
                builder.AppendLine(cnt + " - You didn't choose a variable");
                cnt++;
                Validated = false;
            }
            if (textBoxLowerBound.Text.Trim() == string.Empty || textBoxUpperBound.Text.Trim() == string.Empty)
            {
                builder.AppendLine(cnt + " - Lower bound or Upper bound or both values are empty please check again");
                cnt++;
                Validated = false;
            }
            if (textBoxFunctionFormula.Text.Trim() == string.Empty)
            {
                builder.AppendLine(cnt + " - You didn't input the function to integrate");
                cnt++;
                Validated = false;
            }
            if (textBoxLowerBound.Text.Trim() != string.Empty && !double.TryParse(textBoxLowerBound.Text.Trim(), out low))
            {
                builder.AppendLine(cnt + " - The value you input in the lower bound is not a valid number please check it");
                cnt++;
                Validated = false;
            }
            if (textBoxUpperBound.Text.Trim() != string.Empty && !double.TryParse(textBoxUpperBound.Text.Trim(), out hi))
            {
                builder.AppendLine(cnt + " - The value you input in the upper bound is not a valid number please check it");
                cnt++;
                Validated = false;
            }
            builder.AppendLine();
            ErrorList = builder.ToString();
            return Validated;
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

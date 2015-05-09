using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class LagrangeMethod : AnalysisMethod
    {
        public LagrangeMethod(double[,] samplesToInterpolate)
            : base(samplesToInterpolate)
        {
            if (samplesRowsLength != 2)
            {
                throw new Exception("samples rows must be 2");
            }
            // checking if it's solvable
            isSolvable = true;
            for (int j = 0; j < samplesColumnLength; j++)
            {
                for (int i = 0; i < samplesColumnLength; i++)
                {
                    if (i != j)
                    {
                        // if one of the (xj - xi)'s is 0 then we have a divide by zero in one of lagrange's polynomials
                        // and the result is unsolvable
                        if ((interpolationSamples[samplesXIndex, j] - interpolationSamples[samplesXIndex, i]) == 0)
                        {
                            isSolvable = false;
                        }
                    }
                }
            }

            if (isSolvable)
            {
                FunctionString = buildFunctionString();
            }
            polynomialDegree = samplesColumnLength - 1;
        }


        private string buildFunctionString()
        {

            StringBuilder builder = new StringBuilder("F" + polynomialDegree + "(x) = ");
            for (int j = 0; j < samplesColumnLength; j++)
            {
                double currentX = interpolationSamples[samplesXIndex, j];
                double currentY = interpolationSamples[samplesYIndex, j];
                if (currentY == 0) continue;
                if (j != 0)
                {
                    builder.Append(currentY >= 0 ? '-' : '+');
                }
                if (UIDoubleAbs(currentY) != 1 || samplesColumnLength != 1) builder.Append(UIDoubleAbs(currentY));
                string lagString = langrangeString(j);
                if (lagString != "")
                {
                    builder.Append("(" + lagString + ")");
                }
            }
            return builder.ToString();
        }
        protected override double YForX(double x)
        {
            double result = 0;

            for (int i = 0; i < samplesColumnLength; i++)
            {
                result += interpolationSamples[samplesYIndex, i] * langrangeForX(i, x);
            }
            return result;
        }



        // the simple formula for Lagrange's function
        public static double langrangeForX(int lagrangeIndex, double x, double[,] Samples)
        {

            int samplesRowsLength = Samples.GetUpperBound(0) + 1;
            int samplesColumnLength = Samples.GetUpperBound(1) + 1;

            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (Samples[samplesXIndex, lagrangeIndex] - Samples[samplesXIndex, i]);
                }
            }


            // calculate the nominator part
            double nominator = 1;

            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (x - xi) from the lectures
                    nominator *= (x - Samples[samplesXIndex, i]);
                }
            }
            return nominator / denominator;
        }




        // strings generating functions

        public static string langrangeString(int lagrangeIndex, double[,] Samples)
        {

            int samplesRowsLength = Samples.GetUpperBound(0) + 1;
            int samplesColumnLength = Samples.GetUpperBound(1) + 1;

            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (Samples[samplesXIndex, lagrangeIndex] - Samples[samplesXIndex, i]);
                }
            }


            // calculate the nominator part
            StringBuilder nominatorBuilder = new StringBuilder();

            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (x - xi) from the lectures
                    double currentXi = Samples[samplesXIndex, i];
                    char currentXiReversedSign = currentXi >= 0 ? '-' : '+';
                    if (UIDoubleAbs(currentXi) == 0)
                    {
                        nominatorBuilder.Append("(x)");
                    }
                    else
                    {
                        nominatorBuilder.Append("(x " + currentXiReversedSign + " " + UIDoubleAbs(currentXi) + ")");
                    }
                }
            }
            if (UIDouble(denominator) != 0 && UIDouble(denominator) != 1)
            {
                nominatorBuilder.Append("/" + UIDouble(denominator));
            }
            return nominatorBuilder.ToString();
        }

        // local versions of the methods above for use within this class that 
        // call them with the right arguments

        private string langrangeString(int lagrangeIndex)
        {
            return langrangeString(lagrangeIndex, interpolationSamples);
        }
        private double langrangeForX(int lagrangeIndex, double x)
        {
            return langrangeForX(lagrangeIndex, x, interpolationSamples);
        }

    }
}

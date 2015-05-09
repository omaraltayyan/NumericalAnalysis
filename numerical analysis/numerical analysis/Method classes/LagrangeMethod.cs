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
            polynomialDegree = samplesColumnLength - 1;

            // checking if it's solvable
            isSolvable = true;
            for (int j = 0; j < samplesColumnLength; j++)
            {
                for (int i = 0; i < samplesColumnLength; i++)
                {
                    if (i != j)
                    {
                        // if one of the (xj - xi)'s is 0 then we have a divide by zero in one of Lagrange's polynomials
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
                if (UIDoubleAbs(currentY) != 1 || samplesColumnLength == 1) builder.Append(UIDoubleAbs(currentY));
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

        /**
         * lagrange's error formula: e(x) = [f(m)(n+1)/(n+1)!] * Π(x-xi)
         * 
        **/
        public string ErrorStringForX(string x, string lagrangeDefferntial)
        {
            double lDifferential;
            double xValue;
            if (!double.TryParse(x, out xValue) || !double.TryParse(lagrangeDefferntial, out lDifferential))
            {
                return "";
            }

            // calculate the (n+1)!
            double denominator = 1;
            int factorialLevel = samplesColumnLength + 1;// n+1
            for (int i = 2; i <= factorialLevel; i++)
            {
                denominator *= i;
            }

            // check to see if in the samples
            bool inSamples = false;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (interpolationSamples[samplesXIndex, i] == xValue)
                {
                    inSamples = true;
                }
            }

            if (inSamples || denominator == 0)
            {
                return "the calculation for " + x + " is 100% accurate";
            }

            // calculate  Π(x-xi)
            double product = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                product *= xValue - interpolationSamples[samplesXIndex, i];
            }

            // calculate  [Π(x-xi)] / (n+1)!
            double steadyPart = product / denominator;

            double maximalError = steadyPart * lDifferential;
            return "Error for " + x + " is less than " + maximalError;
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

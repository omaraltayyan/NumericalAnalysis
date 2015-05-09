using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class LagrangeDiffrentiationMethod : AnalysisMethod
    {


        public LagrangeDiffrentiationMethod(double[,] samplesToInterpolate)
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

        }

        private string buildFunctionString()
        {

            StringBuilder builder = new StringBuilder("F\'" + polynomialDegree + "(x) = ");
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
                string lagString = lagrangeDerivativeString(j);
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
                result += interpolationSamples[samplesYIndex, i] * lagrangeDerivative(i, x);
            }
            return result;
        }

        /**
         * the way we calculate the derivative of Lagrange:
         * first we notice that the denominator is a constant number that
         * can be easily calculated on the fly (i.e no need to store array of tokens or anything)
         * so we calculate it and get it out of the differentiation process
         * next we are left with a function of the form (x - a1)(x - a2)(x-a3).......(x-an)
         * and we wanna differentiate it using the ***General product rule***:
         * ( f1 f2...fn)' = f1'f2...fn + f1 f2'...fn + ... + f1 f2...fn'.
         * we also not that the derivative of any function of the form (x - a) is 1
         * so the formula becomes like this
         * ( f1 f2...fn)' = f2 f3...fn + f1 f3...fn + ... + f1 f2...fn-1.
         * and then we divide the answer from the above formula by the denominator we calculated
         * previously to get the final answer.
         * 
         * lagrangeIndex: the j in the formula for Lagrange
        **/
        public static double lagrangeDerivative(int lagrangeIndex, double x, double[,] Samples)
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

            // calculate the value on the derivative
            double derivativeValue = 0;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    double localMultiplication = 1;
                    for (int j = 0; j < samplesColumnLength; j++)
                    {
                        if (j != lagrangeIndex && i != j)
                        {
                            localMultiplication *= (x - Samples[samplesXIndex, j]);
                        }
                    }
                    derivativeValue += localMultiplication;
                }
            }
            return derivativeValue / denominator;
        }


        public static string lagrangeDerivativeString(int lagrangeIndex, double[,] Samples)
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

            // calculate the value on the derivative
            StringBuilder derivativeValueBuilder = new StringBuilder();
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    for (int j = 0; j < samplesColumnLength; j++)
                    {
                        if (j != lagrangeIndex && i != j)
                        {
                            double currentXi = Samples[samplesXIndex, j];
                            char currentXiReversedSign = currentXi >= 0 ? '-' : '+';
                            if (UIDoubleAbs(currentXi) == 0)
                            {
                                derivativeValueBuilder.Append("(x)");
                            }
                            else derivativeValueBuilder.Append("(x " + currentXiReversedSign + " " + UIDoubleAbs(currentXi) + ")");
                        }
                    }
                    if (i != samplesColumnLength - 1)
                    {
                        derivativeValueBuilder.Append(" + ");
                    }
                }
            }

            if (UIDouble(denominator) != 0 && UIDouble(denominator) != 1) derivativeValueBuilder.Append("/" + UIDouble(denominator));
            return derivativeValueBuilder.ToString();
        }


        // local versions of the methods above for use within this class that 
        // call them with the right arguments
        private double lagrangeDerivative(int lagrangeIndex, double x)
        {
            return lagrangeDerivative(lagrangeIndex, x, interpolationSamples);
        }

        private string lagrangeDerivativeString(int lagrangeIndex)
        {
            return lagrangeDerivativeString(lagrangeIndex, interpolationSamples);
        }

    }
}

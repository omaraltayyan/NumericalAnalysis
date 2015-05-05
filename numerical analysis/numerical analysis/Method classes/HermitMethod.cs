using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class HermitMethod : AnalysisMethod
    {
        private double[,] interpolationSamples;
        private int samplesRowsLength;
        private int samplesColumnLength;
        
        public HermitMethod(double[,] samplesToInterpolate)
        {
            
            samplesRowsLength = samplesToInterpolate.GetUpperBound(0) + 1;
            samplesColumnLength = samplesToInterpolate.GetUpperBound(1) + 1;
        
            if (samplesRowsLength != 3)
            {
                throw new Exception("samples rows must be 3");
            }
            interpolationSamples = samplesToInterpolate;

            polynomialDegree = samplesColumnLength * 2 + 1;


            // build the function string
            StringBuilder builder = new StringBuilder("H" + polynomialDegree + "(x) = ");
            for (int j = 0; j < samplesColumnLength; j++)
            {
                double currentX = interpolationSamples[samplesXIndex,j];
                double currentY = interpolationSamples[samplesYIndex,j];
                if(currentY == 0) continue;
                if (j != 0)
                {
                    builder.Append(currentY >= 0 ? '-' : '+');
                }
                builder.Append(Math.Abs(currentY) + "(");
                builder.Append(HjStringForX(j) + ")");
            }
            builder.Append(" + ");
            for (int j = 0; j < samplesColumnLength; j++)
            {
                double currentX = interpolationSamples[samplesXIndex, j];
                double currentYDerivative = interpolationSamples[samplesYDerivativeIndex, j];
                if (currentYDerivative == 0) continue;
                if (j != 0)
                {
                    builder.Append(currentYDerivative >= 0 ? '-' : '+');
                }
                builder.Append(Math.Abs(currentYDerivative) + "(");
                builder.Append(HchapeaujStringForX(j) + ")");
            }
            isSolvable = true;
            FunctionString = builder.ToString();
        }

        // H^j(x) part of the formula
        // which is H^j(x) = (x-xj)*l2j(x)
        // the jIndex is the j of the formula (surprise!!!)
        // and x is the argument of the function 
        private double HchapeaujX(int jIndex, double x)
        {
            // the (x-xj) part
            double leftPart = (x - interpolationSamples[samplesXIndex,jIndex]);

            // the l2j(x) part
            double rightPart = Math.Pow(langrangeForX(jIndex,x),2);

            return leftPart * rightPart;
        }

        // Hj(x) part of the formula
        // which is Hj(x) = [1-2(x-xj)*l'j(xj)]*l2j(x)
        // the jIndex is the j of the formula (surprise!!!)
        // and x is the argument of the function
        private double HjX(int jIndex, double x)
        {
            // the [1-2(x-xj)*l'j(xj)] part
            double leftPart = 0;

            // the l'j(xj) part
            double lagDerivative = lagrangeDerivative(jIndex);

            leftPart = (1 - (2 * (x - interpolationSamples[samplesXIndex, jIndex]) * lagDerivative));

            // the l2j(x) part
            double rightPart = Math.Pow(langrangeForX(jIndex,x),2);

            return leftPart * rightPart;
        }

        // the simple formula for Lagrange's function
        private double langrangeForX(int lagrangeIndex, double x)
        {

            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (interpolationSamples[samplesXIndex,lagrangeIndex] - interpolationSamples[samplesXIndex,i]);
                }
            }


            // calculate the nominator part
            double nominator = 1;

            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (x - xi) from the lectures
                    nominator *= (x - interpolationSamples[samplesXIndex,i]);
                }
            }
            return nominator / denominator;
        }


        /**
         * Hermit's error formula: e(x) = [f(m)^(2n+2)/(2n+2)!] * Π(x-xi)^2
         * 
         * in order to calculate the error for hermit
         * we need to "guess" if the function is generally increasing
         * or decreasing , we can never do this with absolute
         * accuracy, since this is an interpolation operation).
         * to do this we will consider a function whose difference
         * between yn to y0 is positive to be an increasing function
         * and it is decreasing otherwise
        **/
        public override string ErrorStringForX(string x)
        {
            double parsedX;

            if (!double.TryParse(x,out parsedX))
            {
                return "";
            }

            bool isIncreasing = interpolationSamples[samplesYIndex, samplesColumnLength - 1] - interpolationSamples[samplesYIndex, 0] > 0;

            // calculate the (2n+2)!
            double denominator = 1;
            int factorialLevel = polynomialDegree + 1;// 2n+2
            for (int i = 2; i <= factorialLevel; i++)
            {
                denominator *= i;
            }

            // calculate  Π(x-xi)^2
            double product = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                product *= Math.Pow(parsedX - interpolationSamples[samplesXIndex, i], 2);
            }


            // calculate  [Π(x-xi)^2] / (2n+2)!
            double steadyPart = product / denominator;


            // now we calculate f(m)^(2n+2) for x0 and xn as it says in the lecture notes
            double mForX0 = Math.Pow(interpolationSamples[samplesYIndex,0],factorialLevel);
            double mForXn = Math.Pow(interpolationSamples[samplesYIndex, samplesColumnLength - 1], factorialLevel);

            double minimalError = mForX0 * steadyPart;
            double maximalError = mForXn * steadyPart;

            if (!isIncreasing)
            {
                // swap the minimal and maximal errors
                double temp = minimalError;
                minimalError = maximalError;
                maximalError = temp;
            }
                        
            return "Error for " + x + " is between " + minimalError + " and " + maximalError;
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
         * note here we don't need to pass x, since x is in the same index as Lagrange's index
         * in this chunk of hermit formula 
        **/
        private double lagrangeDerivative(int lagrangeIndex)
        {
            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (interpolationSamples[samplesXIndex, lagrangeIndex] - interpolationSamples[samplesXIndex,i]);
                }
            }

            // calculate the value on the derivative
            double derivativeValue = 0;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                double localMultiplication = 1;
                for (int j = 0; j < samplesColumnLength; j++)
                {
                    if (j != lagrangeIndex && i != j)
                    {
                        localMultiplication *= (interpolationSamples[samplesXIndex,lagrangeIndex] - interpolationSamples[samplesXIndex,j]);
                    }
                }
                derivativeValue += localMultiplication;
            }
            return derivativeValue / denominator;
        }


        public override double YForX(double x)
        {
            // remember hermit's formula 
            // H2n+1(x) = Σ[yj * hj(x)] + Σ[y'j * H^j(x)]


            // Σ[yj * hj(x)]
            double firstSummation = 0;
            for (int j = 0; j < samplesColumnLength; j++)
            {
                firstSummation += interpolationSamples[samplesYIndex, j] * HjX(j, x);
            }


            // Σ[y'j * H^j(x)] 
            double secondSummation = 0;
            for (int j = 0; j < samplesColumnLength; j++)
            {
                secondSummation += interpolationSamples[samplesYDerivativeIndex, j] * HchapeaujX(j, x);
            }


            return firstSummation + secondSummation;
        }



        // strings generating functions


        private string langrangeString(int lagrangeIndex)
        {
            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (interpolationSamples[samplesXIndex, lagrangeIndex] - interpolationSamples[samplesXIndex, i]);
                }
            }


            // calculate the nominator part
            StringBuilder nominatorBuilder = new StringBuilder();

            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (x - xi) from the lectures
                    double currentXi = interpolationSamples[samplesXIndex, i];
                    char currentXiReversedSign = currentXi >= 0 ? '-' : '+';

                    nominatorBuilder.Append("(x " + currentXiReversedSign + " " + Math.Abs(currentXi) + ")");
                }
            }
            nominatorBuilder.Append("/" + denominator);
            return nominatorBuilder.ToString();
        }


        // note here we consider the x to be unknown instead of xj like the double version
        private string lagrangeDerivativeString(int lagrangeIndex)
        {
            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (interpolationSamples[samplesXIndex, lagrangeIndex] - interpolationSamples[samplesXIndex, i]);
                }
            }



            // calculate the value on the derivative
            StringBuilder derivativeValueBuilder = new StringBuilder();
            for (int i = 0; i < samplesColumnLength; i++)
            {
                for (int j = 0; j < samplesColumnLength; j++)
                {
                    if (j != lagrangeIndex && i != j)
                    {
                         double currentXi = interpolationSamples[samplesXIndex, j];
                        char currentXiReversedSign = currentXi >= 0 ? '-' : '+';

                        derivativeValueBuilder.Append("(x " + currentXiReversedSign + " " + Math.Abs(currentXi) + ")");
                    }
                }
                if (i != samplesColumnLength - 1)
                {
                    derivativeValueBuilder.Append(" + ");
                }
            }
            derivativeValueBuilder.Append("/" + denominator);
            return derivativeValueBuilder.ToString();
        }


        private string HchapeaujStringForX(int jIndex)
        {
            
            double currentXi = interpolationSamples[samplesXIndex, jIndex];
            char currentXiReversedSign = currentXi >= 0 ? '-' : '+';


            // the (x-xj) part
            StringBuilder builder = new StringBuilder("(x " + currentXiReversedSign + " " + Math.Abs(currentXi) + ")");

            // the l2j(x) part
            builder.Append("[" + langrangeString(jIndex) + "]");

            return builder.ToString();
        }


        private string HjStringForX(int jIndex)
        {

            double currentXi = interpolationSamples[samplesXIndex, jIndex];

            // the [1-2(x-xj)*l'j(xj)] part            


            // build Hj(x) string

            // first the [1-2(x-xj)*l'j(xj)]
            // note that the Hj(x) formula can be changed from 
            // [1-2(x-xj)*l'j(xj)]*l2j(x) to [a*x - b]* l2j(x)
            // where a = 2 * l'j(xj) and b = a * xj + 1
            double a = 2 * lagrangeDerivative(jIndex);
            double b = a * currentXi + 1;
            char bInversedSign = b >= 0 ? '-' : '+';
            StringBuilder builder = new StringBuilder("[" + a + "x " + bInversedSign + " " + Math.Abs(b) + "]");


            // the l2j(x) part
            builder.Append("(" + langrangeString(jIndex) + ")^2");

            return builder.ToString();
        }

    }
}

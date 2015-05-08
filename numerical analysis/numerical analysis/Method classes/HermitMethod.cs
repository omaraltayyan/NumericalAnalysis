using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class HermitMethod : AnalysisMethod
    {
        public HermitMethod(double[,] samplesToInterpolate) : base(samplesToInterpolate)
        {
            if (samplesRowsLength != 3)
            {
                throw new Exception("samples rows must be 3");
            }
            interpolationSamples = samplesToInterpolate;

            polynomialDegree = (samplesColumnLength-1) * 2 + 1;


            isSolvable = true;
            FunctionString = buildFunctionString();
        }

        // build the function string
        private string buildFunctionString()
        {

            StringBuilder builder = new StringBuilder("H" + polynomialDegree + "(x) = ");
            for (int j = 0; j < samplesColumnLength; j++)
            {
                double currentX = interpolationSamples[samplesXIndex, j];
                double currentY = interpolationSamples[samplesYIndex, j];
                if (currentY == 0) continue;
                if (j != 0)
                {
                    builder.Append(currentY >= 0 ? '-' : '+');
                }
                if (UIDoubleAbs(currentY) != 1) builder.Append(UIDoubleAbs(currentY) + "(");
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
                if (UIDoubleAbs(currentYDerivative) != 1) builder.Append(UIDoubleAbs(currentYDerivative) + "(");
                builder.Append(HchapeaujStringForX(j) + ")");
            }
            return builder.ToString();
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
            double rightPart = Math.Pow(LagrangeMethod.langrangeForX(jIndex, x, interpolationSamples), 2);

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
            double lagDerivative = LagrangeDiffrentiationMethod.lagrangeDerivative(jIndex,interpolationSamples[samplesXIndex,jIndex], interpolationSamples);

            leftPart = (1 - (2 * (x - interpolationSamples[samplesXIndex, jIndex]) * lagDerivative));

            // the l2j(x) part
            double rightPart = Math.Pow(LagrangeMethod.langrangeForX(jIndex, x, interpolationSamples), 2);

            return leftPart * rightPart;
        }



        /**
         * Hermit's error formula: e(x) = [f(m)(2n+2)/(2n+2)!] * Π(x-xi)^2
         * 
        **/
        protected override string ErrorStringForX(double x)
        {

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
                product *= Math.Pow(x - interpolationSamples[samplesXIndex, i], 2);
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

        protected override double YForX(double x)
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



        // H^j(x) part of the formula
        // which is H^j(x) = (x-xj)*l2j(x)
        // the jIndex is the j of the formula (surprise!!!)
        // and x is the argument of the function 
        private string HchapeaujStringForX(int jIndex)
        {
            
            double currentXi = interpolationSamples[samplesXIndex, jIndex];
            char currentXiReversedSign = currentXi >= 0 ? '-' : '+';


            // the (x-xj) part
            StringBuilder builder = new StringBuilder();

            if (UIDoubleAbs(currentXi) == 0) builder.Append("(x)");

            else builder.Append("(x " + currentXiReversedSign + " " + UIDoubleAbs(currentXi) + ")");

            // the l2j(x) part
            builder.Append("[" +LagrangeMethod.langrangeString(jIndex, interpolationSamples) + "]^2");

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
            double a = 2 * LagrangeDiffrentiationMethod.lagrangeDerivative(jIndex, interpolationSamples[samplesXIndex, jIndex], interpolationSamples);
            double b = a * currentXi + 1;
            char bInversedSign = b >= 0 ? '-' : '+';
            StringBuilder builder = new StringBuilder("[" + UIDoubleAbs(a) + "x " + bInversedSign + " " + UIDoubleAbs(b) + "]");


            // the l2j(x) part
            builder.Append("(" +LagrangeMethod.langrangeString(jIndex, interpolationSamples) + ")^2");

            return builder.ToString();
        }

    }
}

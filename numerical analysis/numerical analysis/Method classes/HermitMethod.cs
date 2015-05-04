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
        **/
        private double langrangeDerivativeForX(int lagrangeIndex)
        {


            // calculate the denominator
            double denominator = 1;
            for (int i = 0; i < samplesColumnLength; i++)
            {
                if (i != lagrangeIndex)
                {
                    // (xj - xi) from the lectures
                    denominator *= (interpolationSamples[lagrangeIndex, samplesXIndex] - interpolationSamples[i, samplesXIndex]);
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
                        localMultiplication *= (interpolationSamples[lagrangeIndex, samplesXIndex] - interpolationSamples[j, samplesXIndex]);
                    }
                }
                derivativeValue += localMultiplication;
            }
            double totalResult = derivativeValue / denominator;
            return totalResult;
        }
        public override double YForX(double x)
        {

            return 0;
        }
    }
}

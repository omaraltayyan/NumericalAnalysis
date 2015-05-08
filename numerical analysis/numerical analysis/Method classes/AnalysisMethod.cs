using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    abstract class AnalysisMethod
    {

        // a convenient rename to shorten the terms for use in 
        // subclasses (so that you don't have to write FormNumericalAnalysis.samplesXIndex every time
        // u wanna reference these constants
        public const int samplesXIndex = FormNumericalAnalysis.samplesXIndex;
        public const int samplesYIndex = FormNumericalAnalysis.samplesYIndex;
        public const int samplesYDerivativeIndex = FormNumericalAnalysis.samplesYDerivativeIndex;

        public AnalysisMethod(double[,] samplesToInterpolate)
        {
            interpolationSamples = samplesToInterpolate;
            samplesRowsLength = samplesToInterpolate.GetUpperBound(0) + 1;
            samplesColumnLength = samplesToInterpolate.GetUpperBound(1) + 1;
        }


        protected double[,] interpolationSamples;
        protected int samplesRowsLength;
        protected int samplesColumnLength;
        

        protected static double UIDouble(double x)
        {
            return Math.Round(x, 3);
        }

        protected static double UIDoubleAbs(double x)
        {
            return Math.Abs(UIDouble(x));
        }

        protected int polynomialDegree = 0;

        public bool isSolvable { get; protected set; }

        protected abstract double YForX(double x);


        public virtual string FunctionString { get; protected set; }


        public string ErrorStringForX(string x)
        {
            double parsedX;

            if (!double.TryParse(x, out parsedX))
            {
                return "";
            }
            return ErrorStringForX(parsedX);
        }

        protected virtual string ErrorStringForX(double x)
        {
            return "";
        }

        public string YForXString(string x)
        {
            if (!isSolvable) return "";

            double sentVal;

            if (!double.TryParse(x, out sentVal)) return "";

            double yForFx = YForX(sentVal);
            return "P" + polynomialDegree + "(" + sentVal + ")" + " = " + yForFx;
        }

    }
}

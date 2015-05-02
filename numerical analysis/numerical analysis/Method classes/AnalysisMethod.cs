using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    abstract class AnalysisMethod
    {

        // a convinient rename to shorten the terms for use in 
        // subclasses (so that you don't have to write FormNumericalAnalysis.samplesXIndex every time
        // u wanna reference these constants
        public const int samplesXIndex = FormNumericalAnalysis.samplesXIndex;
        public const int samplesYIndex = FormNumericalAnalysis.samplesYIndex;

        public bool isSolvable { get;protected set; }

        public abstract double YForX(double x);

        public virtual string errorStringForX(double x)
        {
            return "";
        }

        public virtual string FunctionString()
        {
            return "";
        }
    }
}

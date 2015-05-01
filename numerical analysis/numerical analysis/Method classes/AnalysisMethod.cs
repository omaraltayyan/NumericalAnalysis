using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    abstract class AnalysisMethod
    {
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

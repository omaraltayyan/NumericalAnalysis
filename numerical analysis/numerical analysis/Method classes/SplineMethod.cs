using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class SplineMethod : AnalysisMethod
    {
        public static int value_index = -1;
        public SplineMethod(double[,] samplesToInterpolate)
            : base(samplesToInterpolate)
        {
            if (samplesRowsLength != 2)
            {
                throw new Exception("samples rows must be 2");
            }
            isSolvable = true;
            for (int i = 0; i < samplesColumnLength - 1; i++)
            {

                // if one of the (xj - xi)'s is 0 then we have a divide by zero in one of the equqtions
                // and the result is unsolvable
                if ((interpolationSamples[samplesXIndex, i + 1] - interpolationSamples[samplesXIndex, i]) == 0)
                {
                    isSolvable = false;
                }
            }
            if (samplesColumnLength <= 1)
                isSolvable = false;

            polynomialDegree = 1;
        }
        protected override double YForX(double x)
        {
            double result = 0;
            int ind = -1;
            if (x <= interpolationSamples[samplesXIndex, 0]) ind = 0;
            else if (x >= interpolationSamples[samplesXIndex, samplesColumnLength - 1]) ind = samplesColumnLength - 2;
            else
            {
                for (int i = 0; i < samplesColumnLength - 1; i++)
                {
                    if (x >= interpolationSamples[samplesXIndex, i] && x <= interpolationSamples[samplesXIndex, i + 1])
                    {
                        ind = i;
                        break;
                    }
                }
            }

            result = interpolationSamples[samplesYIndex, ind] + (((interpolationSamples[samplesYIndex, ind + 1] - interpolationSamples[samplesYIndex, ind]) / (interpolationSamples[samplesXIndex, ind + 1] - interpolationSamples[samplesXIndex, ind])) * (x - interpolationSamples[samplesXIndex, ind]));
            value_index = ind;
            return result;
        }
        public  string YForXString(string x)
        {
            if (!isSolvable) return "";

            double sentVal;

            if (!double.TryParse(x, out sentVal)) return "";
          
            double yForFx = Math.Round(YForX(sentVal), 13);
            return "S" + value_index + "(" + sentVal + ")" + " = " + yForFx;
        }
        public override string FunctionString
        {
            get
            {
                StringBuilder builder = new StringBuilder("");
                if (isSolvable && samplesColumnLength > 1)
                {
                    for (int i = 0; i < samplesColumnLength - 1; i++)
                    {
                        double fraction = ((interpolationSamples[samplesYIndex, i + 1] - interpolationSamples[samplesYIndex, i]) / (interpolationSamples[samplesXIndex, i + 1] - interpolationSamples[samplesXIndex, i]));
                        builder.Append("S" + i + "(x) = ");
                        builder.Append(fraction + "x ");
                        double number = fraction * ((-1) * (interpolationSamples[samplesXIndex, i]));
                        number = interpolationSamples[samplesYIndex, i] + number;
                        string signal = number < 0 ? "- " : "+ ";
                        if (number < 0) number *= -1;
                        builder.AppendLine(signal + number);
                        builder.AppendLine();

                    }
                }
                return builder.ToString();
            }
            protected set
            {
                base.FunctionString = value;
            }
        }
    }
}

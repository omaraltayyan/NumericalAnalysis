using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class NewtonDividedDifferences
    {
        public enum DifferncesType
        {
            Progressive,Regressive 
        }
        private const int Xi = 0;
        private const int Yi = 1;
        public double[,] SamplesToInterpolate { get; set; }
        public DifferncesType MethodType { get; set; }
        public NewtonDividedDifferences(DifferncesType typ , double[,] samplesArray)
        {
            SamplesToInterpolate = samplesArray;
            MethodType = typ;
        }
        public static double DividedDifferences(double X0, double X1, double Y0, double Y1)
        {
            return (Y1 - Y0) / (X1 - X0);
        }

        public double[,] MakeDifferencesTable()
        {
            return new double[1, 1];
        }
        public void ProgressiveDividedDifferences()
        {
            int numberOfSamples = SamplesToInterpolate.GetLength(Xi);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace numerical_analysis.Method_classes
{
    class Integration
    {
        string function, variable;

        public string Variable
        {
            get { return variable; }
            set { variable = value; }
        }
        double lowerbound, upperbound;

        public double Lowerbound
        {
            get { return lowerbound; }
            set { lowerbound = value; }
        }
        public string Function
        {
            get { return function; }
            set { function = value; }
        }
        public double Upperbound
        {
            get { return upperbound; }
            set { upperbound = value; }
        }

        public Integration(string fx, double lbound, double ubound, string var)
        {
            function = fx;
            lowerbound = lbound;
            upperbound = ubound;
            variable = var;
        }

        public double RectanglesMethod()
        {
            Expression formula = new Expression(function);
            if (formula.HasErrors())
                throw new Exception("The formula you entered is not valid please check it again");
            double h = (upperbound - lowerbound) / 100000.0;
            double value = lowerbound;
            double result = 0.0;
            while (value < upperbound)
            {
                formula.Parameters[variable] = value;
                result += (double)formula.Evaluate();
                value += h;

            }
            return h * result;
        }
        public double TrapezoidMethod()
        {
            Expression formula = new Expression(function);
            if (formula.HasErrors())
                throw new Exception("The formula you entered is not valid please check it again");
            double h = (upperbound - lowerbound) / 100000.0;
            double value = lowerbound;
            double result = 0.0;
            while (value <= upperbound)
            {
                double multiple = (value == lowerbound || value == upperbound) ? 1 : 2;
                formula.Parameters[variable] = value;
                result += (double)formula.Evaluate() * multiple;
                value += h;

            }
            return (h / 2) * result;
        }
        public double SimpsonMethod()
        {
            Expression formula = new Expression(function);
            if (formula.HasErrors())
                throw new Exception("The formula you entered is not valid please check it again");
            double h = (upperbound - lowerbound) / 1000000.0;
            double value = lowerbound;
            double result = 0.0; int cnt = 0;
            while (value <= upperbound)
            {
                double multiple = 0.0;
                if (cnt == 0 || cnt == 1000000)
                    multiple = 1.0;
                else if (cnt % 2 != 0) multiple = 4.0;
                else
                    multiple = 2;
                formula.Parameters[variable] = value;
                result += (double)formula.Evaluate() * multiple;
                value += h;
                cnt++;

            }
            return (h / 3) * result; ;
        }
    }
}

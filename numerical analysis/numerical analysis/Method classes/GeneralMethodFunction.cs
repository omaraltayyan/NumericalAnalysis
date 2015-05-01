using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class GeneralMethodFunction : AnalysisMethod
    {
        private double WendermondDeterminant = 1;

        /// <summary>
        /// pass the 2-row n-column array of sample values to interpolate
        /// </summary>
        /// <param name="samplesToInterpolate"> the samples 2 by n grid</param>
        GeneralMethodFunction(double[][] samplesToInterpolate)
        {
            if (samplesToInterpolate.Length != 2)
                throw new Exception("samples rows must be exactly 2");
            for (int j = 0; j < samplesToInterpolate[0].Length - 1; j++)
            {
                for (int k = j + 1; k < samplesToInterpolate[0].Length; k++)
                {
                    WendermondDeterminant *= samplesToInterpolate[0][k] - samplesToInterpolate[0][j];
                }
            }

            // it is solvable if the determinant is not 0
            isSolvable = WendermondDeterminant != 0;

        }

        public override double YForX(double x)
        {
#warning TODO: Implement this
            return 0.0;
        }

        public override string errorStringForX(double x)
        {
#warning TODO: Implement this

            return "";
        }

        public override string FunctionString()
        {
#warning TODO: Implement this
            return ""; // 
        }

        // this method solves
        private double matrixDeterminantByGauss(double[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            double determinant = 1;
            int columnsCounter = 0;
            for (int rowsCounter = 0; rowsCounter < matrix.Length; rowsCounter++)
            {
                if (columnsCounter >= matrix[0].Length) break;
                int firstNonZeroValueRowIndex = -1;
                int firstNonZeroValueColumnIndex = -1;
                bool isValueFound = false;
                // iterate the columns of the matrix to find the first non-zero column
                for (int i = columnsCounter; i < matrix[0].Length; i++) // col
                {
                    for (int j = rowsCounter; j < matrix.Length; j++)
                    {
                        if (matrix[j][i] != 0)
                        {
                            isValueFound = true;
                            firstNonZeroValueRowIndex = j;
                            firstNonZeroValueColumnIndex = i;
                            break;
                        }
                    }
                    if (isValueFound) break;
                }
                // if it's not found this means that the values in the matrix are all zeros
                if (!isValueFound) return 0;
                columnsCounter = firstNonZeroValueColumnIndex + 1;
                // short hands for the long names
                int rowIdx = firstNonZeroValueRowIndex;
                int colIdx = firstNonZeroValueColumnIndex;

                if (rowIdx != rowsCounter) // if this isn't the top current row in the matrix
                {
                    // multiply the determinant by -1 (flip the sign)
                    determinant = -determinant;

                    // swap this found row with the first row
                    double[] temp = matrix[rowsCounter];
                    matrix[rowsCounter] = matrix[rowIdx];
                    matrix[rowIdx] = temp;
                }



                if (matrix[rowIdx][colIdx] != 1)
                {
                    // divid the determinate by the found value (we're taking the common value out from the row)
                    determinant *= matrix[rowIdx][colIdx];

                    // divid the row in the matrix by this number
                    for (int i = columnsCounter; i < matrix[rowIdx].Length; i++)
                    {
                        matrix[rowIdx][i] /= matrix[rowIdx][colIdx];
                    }
                }
                for (int i = rowIdx + 1; i < matrix.Length; i++)
                {
                    if (matrix[i][colIdx] != 0)
                    {
                        for (int j = colIdx + 1; j < matrix[0].Length; j++)
                        {
                            matrix[i][j] = (-matrix[i][colIdx] * matrix[rowIdx][j]) + matrix[i][j];
                        }
                        matrix[i][colIdx] = 0;
                    }
                }
            }
            return determinant;

        }
    }
}

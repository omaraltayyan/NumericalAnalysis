using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numerical_analysis.Method_classes
{
    class GeneralMethodFunction
    {
        private bool _isSolvable;

        public bool isSolvable
        {
            get { return _isSolvable; }
            set { _isSolvable = value; }
        }

        private double wendermondDeterminant = 1;

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
                    wendermondDeterminant *= samplesToInterpolate[0][k] - samplesToInterpolate[0][j];
                }
            }

            // it is solvable if the determinant is not 0
            isSolvable = wendermondDeterminant != 0;

        }


        // this method solves
        private double matrixDeterminantByGauss(double[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            double determinant = 1;
            for (int rowsCounter = 0; rowsCounter < matrix.Length; rowsCounter++)
            {
                int firstNonZeroValueRowIndex = -1;
                int firstNonZeroValueColumnIndex = -1;
                bool isValueFound = false;
                // iterate the columns of the matrix to find the first non-zero column
                for (int i = 0; i < matrix[0].Length; i++) // col
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

                // short hands for the long names
                int rowIdx = firstNonZeroValueRowIndex;
                int colIdx = firstNonZeroValueColumnIndex;

                if (rowIdx != 0) // if this isn't the first row in the matrix
                {
                    // multiply the determinant by -1 (flip the sign)
                    determinant = -determinant;

                    // swap this found row with the first row
                    double[] temp = matrix[0];
                    matrix[0] = matrix[rowIdx];
                    matrix[rowIdx] = temp;
                }



                if (matrix[rowIdx][colIdx] != 1)
                {
                    // divid the determinate by the found value (we're taking the common value out from the row)
                    determinant /= matrix[rowIdx][colIdx];

                    // divid the row in the matrix by this number
                    for (int i = 0; i < matrix[rowIdx].Length; i++)
                    {
                        matrix[rowIdx][i] /= matrix[rowIdx][colIdx];
                    }
                }
                for (int i = rowIdx + 1; i < matrix[rowIdx].Length; i++)
                {
                    if (matrix[i][colIdx] != 0)
                    {
                        for (int j = colIdx + 1; j < matrix.Length; j++)
                        {
                            matrix[i][j] = (matrix[i][colIdx] * matrix[rowIdx][j]) - matrix[i][j];
                        }
                        matrix[i][colIdx] = 0;
                    }
                }
            }
            return determinant;

        }
    }
}

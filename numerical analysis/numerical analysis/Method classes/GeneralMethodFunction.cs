using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace numerical_analysis.Method_classes
{
    class GeneralMethodFunction : AnalysisMethod
    {
        private double WendermondDeterminant = 1;

        private double[] interpolationConstants;
        /// <summary>
        /// pass the 2-row n-column array of sample values to interpolate
        /// </summary>
        /// <param name="samplesToInterpolate"> the samples 2 by n grid</param>
        GeneralMethodFunction(double[,] samplesToInterpolate)
        {

            int samplesRowsLength = samplesToInterpolate.GetUpperBound(0) + 1;
            int samplesColumnLength = samplesToInterpolate.GetUpperBound(1) + 1;

            if (samplesRowsLength != 2)
                throw new Exception("samples rows must be exactly 2");



            // calculate Wendermond's Determinant
            for (int i = 0; i < samplesColumnLength - 1; i++)
            {
                for (int j = i + 1; j < samplesColumnLength; j++)
                {
                    WendermondDeterminant *= samplesToInterpolate[0, j] - samplesToInterpolate[0, i];
                }
            }

            // it is solvable if the determinant is not 0
            isSolvable = WendermondDeterminant != 0;


            // continue extracting the interpolation function
            if (isSolvable)
            {

                // this array has some weird dimentions, you need to check the rules for the general methods
                // to know why this is the case.
                int gaussMatrixRows = samplesColumnLength;
                int gaussMatrixColumns = samplesColumnLength;
                double[,] gaussMatrix = new double[gaussMatrixRows, gaussMatrixColumns];


                // fill the gauss linear equation solving matrix
                for (int i = 0; i < gaussMatrixRows; i++)
                {
                    for (int j = 0; j < gaussMatrixColumns; j++)
                    {
                        gaussMatrix[i, j] = Math.Pow(samplesToInterpolate[0, i], j);
                    }
                }

                interpolationConstants = new double[gaussMatrixColumns];


                for (int j = 0; j < gaussMatrixColumns; j++)
                {
                    // replace each column with the y's from the samples  
                    for (int i = 0; i < gaussMatrixRows; i++)
                    {
                        gaussMatrix[i, j] = samplesToInterpolate[1, i];
                    }

                    // calculate the determinant and put it in the coefficients (or constants) array
                    interpolationConstants[j] = matrixDeterminantByGauss(gaussMatrix) / WendermondDeterminant;

                    // restore the matrix to it's state
                    for (int i = 0; i < gaussMatrixRows; i++)
                    {
                        gaussMatrix[i, j] = Math.Pow(samplesToInterpolate[0, i], j);
                    }
                }

            }
        }

        public override double YForX(double x)
        {
            if (isSolvable)
            {
                double answer = 0;
                for (int i = 0; i < interpolationConstants.Length; i++)
                {
                    answer += interpolationConstants[i] * Math.Pow(x,i);
                }
                return answer;
            }
            return 0.0;
        }

        public override string errorStringForX(double x)
        {
#warning TODO: Implement this

            return "";
        }

        public override string FunctionString()
        {
            if (isSolvable)
            {
                StringBuilder builder = new StringBuilder("Pn(x) = ");
                for (int i = 0; i < interpolationConstants.Length; i++)
                {
                    if (interpolationConstants[i] != 0)
                    {
                        if(i == 0) builder.Append(Math.Round(interpolationConstants[i],3));
                        else
                        {
                            builder.Append(Math.Abs(Math.Round(interpolationConstants[i], 3)));
                            builder.Append("x");
                        }
                        if (i > 1) builder.Append("^" + i);
                        if(i != interpolationConstants.Length - 1 && interpolationConstants[i+1] != 0)
                            builder.Append(interpolationConstants[i + 1] > 0 ? " + " : " - ");
                    }
                }
                return builder.ToString();
            }
            return ""; // 
        }

        // this method solves
        private double matrixDeterminantByGauss(double[,] matrix)
        {

            int matrixRowsLength = matrix.GetUpperBound(0) + 1;
            int matrixColumnLength = matrix.GetUpperBound(1) + 1;

            // we should work on a copy of the matrix so that we don't alter the original one
            double[,] matrixCopy = new double[matrixRowsLength,matrixColumnLength];
            for (int i = 0; i < matrixRowsLength; i++)
            {
                for (int j = 0; j < matrixColumnLength; j++)
                {
                    matrixCopy[i, j] = matrix[i, j];
                }
            }


            
            if (matrixRowsLength == 0 || matrixColumnLength == 0)
            {
                return 0;
            }

            double determinant = 1;
            int columnsCounter = 0;
            for (int rowsCounter = 0; rowsCounter < matrixRowsLength; rowsCounter++)
            {
                if (columnsCounter >= matrixColumnLength) break;
                int firstNonZeroValueRowIndex = -1;
                int firstNonZeroValueColumnIndex = -1;
                bool isValueFound = false;
                // iterate the columns of the matrix to find the first non-zero column
                for (int i = columnsCounter; i < matrixColumnLength; i++) // col
                {
                    for (int j = rowsCounter; j < matrixRowsLength; j++)
                    {
                        if (matrixCopy[j, i] != 0)
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
                    for (int i = 0; i < matrixColumnLength; i++)
                    {

                        double temp = matrixCopy[rowsCounter, i];
                        matrixCopy[rowsCounter, i] = matrixCopy[rowIdx, i];
                        matrixCopy[rowIdx, i] = temp;
                    }
                }



                if (matrixCopy[rowIdx, colIdx] != 1)
                {
                    // divid the determinate by the found value (we're taking the common value out from the row)
                    determinant *= matrixCopy[rowIdx, colIdx];

                    // divid the row in the matrix by this number
                    for (int i = columnsCounter; i < matrixColumnLength; i++)
                    {
                        matrixCopy[rowIdx, i] /= matrixCopy[rowIdx, colIdx];
                    }
                }
                for (int i = rowIdx + 1; i < matrixRowsLength; i++)
                {
                    if (matrixCopy[i, colIdx] != 0)
                    {
                        for (int j = colIdx + 1; j < matrixColumnLength; j++)
                        {
                            matrixCopy[i, j] = (-matrixCopy[i, colIdx] * matrixCopy[rowIdx, j]) + matrixCopy[i, j];
                        }
                        matrixCopy[i, colIdx] = 0;
                    }
                }
            }
            return determinant;

        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace MatrixGenerator.Domain.Services
{
    /// <summary>Handles the operations for generating a matrix.</summary>
    public class MatrixService
    {
        /// <summary>Generates a matrix as a string.</summary>
        /// <param name="dataValues">Data values for calculating cell values.</param>
        /// <param name="c">Value of c.</param>
        /// <param name="n">Value of N.</param>
        /// <returns>A string containing a matrix.</returns>
        public string GenerateMatrix(double[] dataValues, int c, int n)
        {
            ValidateGenerateMatrix(dataValues, c, n);

            var stringBuilder = new StringBuilder();
            int k = 0, j = 0, i = c;

            for (var x = 0; x < Math.Pow((c + 1), 2); x++)
            {
                // Perform the sigma summation to get the cell value.
                var cellValue = Enumerable.Range(i, (n - c)).Sum(y => (dataValues[y - k] * dataValues[y - j]));

                /*
                 * Output the cell value rounded to the required precision.
                 * Add a leading space for positive values to produce a correctly aligned matrix for both positive and negative values.
                 */
                stringBuilder.Append(string.Format("{0}{1}", (cellValue > 0 ? " " : ""), cellValue.ToString("0.000000 ")));

                // If at the end of the current row, go and produce the next row of the matrix.
                if (j == c)
                {
                    k++;
                    j = 0;
                    stringBuilder.AppendLine();
                    continue;
                }

                // Else go and calculate the next cell value.
                j++;
            }

            return stringBuilder.ToString();
        }

        /// <summary>Validates the parameters sent to GenerateMatrix method.</summary>
        /// <param name="dataValues">Data values for calculating cell values.</param>
        /// <param name="c">Value of c.</param>
        /// <param name="n">Value of N.</param>
        /// <exception cref="System.ArgumentException">
        /// No data values were provided.
        /// or
        /// Value of \"N\" must be greater than or equal to (\"c\" + 1) to generate the matrix.
        /// or
        /// Value of \"N\" must be less than or equal to the number of input data values to generate the matrix.
        /// or
        /// Value of \"c\" must be greater than or equal to zero to generate the matrix.
        /// </exception>
        private static void ValidateGenerateMatrix(double[] dataValues, int c, int n)
        {
            if (dataValues == null || dataValues.Length == 0)
            {
                throw new ArgumentException("No data values were provided.");
            }

            // This must be true to perform the sigma summation to generate the cell values.
            if ((c + 1) > n)
            {
                throw new ArgumentException("Value of \"N\" must be greater than or equal to (\"c\" + 1) to generate the matrix.");
            }

            // This must be true or the system will fail to find a data value.
            if (n > dataValues.LongLength)
            {
                throw new ArgumentException("Value of \"N\" must be less than or equal to the number of input data values to generate the matrix.");
            }

            // This must be true or it will not be possible generate a matrix of c + 1, c + 1.
            if (c < 0)
            {
                throw new ArgumentException("Value of \"c\" must be greater than or equal to zero to generate the matrix.");
            }
        }
    }
}
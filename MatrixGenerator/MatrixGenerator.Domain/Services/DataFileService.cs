using System;
using System.IO;
using System.Linq;

namespace MatrixGenerator.Domain.Services
{
    /// <summary>Handles read operations of text files.</summary>
    public class DataFileService
    {
        /// <summary>Reads the lines of a text file as a floating point number.</summary>
        /// <param name="filePath">Fully qualified text file path.</param>
        /// <returns>An array of data file values.</returns>
        /// <exception cref="System.FormatException">Data file contains invalid or empty values.</exception>
        /// <exception cref="System.OverflowException">"Data file contains too small or too large floating point numbers."</exception>
        public double[] ReadDataFile(string filePath)
        {
            ValidateReadDataFile(filePath);

            try
            {
                return File.ReadAllLines(filePath).Select(x => double.Parse(x)).ToArray();
            }
            catch (FormatException)
            {
                throw new FormatException("Data file contains invalid or empty values.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Data file contains too small or too large floating point numbers.");
            }
        }

        /// <summary>Validates the parameters sent to ReadDataFile method.</summary>
        /// <param name="filePath">Fully qualified text file path.</param>
        /// <exception cref="System.ArgumentException">Data file path is invalid or no such file exists.</exception>
        private static void ValidateReadDataFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException("Data file path is invalid or no such file exists.");
            }
        }
    }
}
using System;

namespace MatrixGenerator.Console.Tests.ValidatorTests
{
    /// <summary>Handles the validation for command line parameters.</summary>
    public static class ParameterValidator
    {
        /// <summary>Validates the command line arguments for generating a matrix.</summary>
        /// <param name="args">The command line arguments.</param>
        /// <param name="c">The value of c.</param>
        /// <param name="n">The value of N.</param>
        /// <exception cref="System.ArgumentException">
        /// Invalid parameters; data file path, value of \"c\" and value of \"N\" are required.
        /// or
        /// A data file path was not provided.
        /// or
        /// Value of \"c\" is required and must be an integer.
        /// or
        /// Value of \"N\" is required and must be an integer.
        /// </exception>
        public static void ValidateMatrixParameters(string[] args, out int c, out int n)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Invalid parameters; data file path, value of \"c\" and value of \"N\" are required.");
            }

            if (string.IsNullOrEmpty(args[0]))
            {
                throw new ArgumentException("A data file path was not provided.");
            }

            if (string.IsNullOrEmpty(args[1]) || !int.TryParse(args[1], out c))
            {
                throw new ArgumentException("Value of \"c\" is required and must be an integer.");
            }

            if (string.IsNullOrEmpty(args[2]) || !int.TryParse(args[2], out n))
            {
                throw new ArgumentException("Value of \"N\" is required and must be an integer.");
            }
        }
    }
}
using System;
using System.Diagnostics;
using MatrixGenerator.Console.Validators;
using MatrixGenerator.Domain.Services;

namespace MatrixGenerator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            System.Console.WriteLine("Running... Please wait! \n");
            stopwatch.Start();

            try
            {
                ParameterValidator.ValidateMatrixParameters(args, out var c, out var n);
                var dataValues = new DataFileService().ReadDataFile(args[0]);
                var matrixString = new MatrixService().GenerateMatrix(dataValues, c, n);
                System.Console.WriteLine(matrixString);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error : {0} \n", e.Message);
            }

            stopwatch.Stop();
            System.Console.WriteLine("Finished running!");
            System.Console.WriteLine("Time taken: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
            System.Console.ReadKey();
        }
    }
}
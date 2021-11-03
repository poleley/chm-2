using System;
using System.IO;

namespace chm_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
            var matrixA = Utils.MatrixFromFile(inputFile);
            var x = Utils.VectorFromFile(inputFile);
            var f = Utils.VectorFromFile(inputFile);
            var w = Utils.ReadDouble(inputFile);
            var maxIterations = Utils.ReadInt(inputFile);
            var eps = Utils.ReadDouble(inputFile);

            Utils.Pprint(matrixA);
            Utils.Pprint(f);
            Console.WriteLine("\n");

            for (var i = 0; i < maxIterations; i++)
            {
                var residual = Methods.RelativeResidual(matrixA, x, f);

                if (residual < eps)
                {
                    break;
                }

                Console.WriteLine($"Iteration: {i} Residual: {residual} ");
                Console.Write($"x{i} = ( ");
                Utils.Pprint(x);
                Console.WriteLine(")");
                Console.WriteLine();
                x = Methods.Iterate(x, matrixA, w, f);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            var residualAns = Methods.RelativeResidual(matrixA, x, f);
            Console.WriteLine($"Residual: {residualAns} ");
            Utils.Pprint(x);
        }
    }
}
using System;
using System.IO;

namespace chm_2;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputFile = new StreamReader("input.txt");

        var matrix = Utils.MatrixFromFile(inputFile);
        var xGS = Utils.VectorFromFile(inputFile);

        var f = Utils.VectorFromFile(inputFile);

        var w = Utils.ReadDouble(inputFile);

        var maxIterations = Utils.ReadInt(inputFile);
        var eps = Utils.ReadDouble(inputFile);
        var diffEps = eps / 200.0;

        var xJacobi = new double[xGS.Length];
        xGS.AsSpan().CopyTo(xJacobi);

        //var xNextGS = new double[xGS.Length];

        Console.ForegroundColor = ConsoleColor.Red;

        for (int i = 0; i < matrix.N; i++)
        {
            Console.WriteLine($"TEST: {LinAlg.GSLowScalarProd(i, matrix, f) + LinAlg.GSUpScalarProd(i, matrix, f)}");
        }

        Console.ResetColor();

        Console.WriteLine();

        // Here is Gauss-Seidel method
        for (var i = 0; i < maxIterations; i++)
        {
            var residual = Methods.RelativeResidual(matrix, xGS, f);

            if (residual < eps)
            {
                break;
            }

            Console.WriteLine($"Iteration: {i + 1} Residual: {residual} ");
            var xNextGS = new double[xGS.Length];
            xGS = Methods.Iterate(xGS, xNextGS, matrix, w, f);
        }

        Console.WriteLine("Result by GS:");
        Utils.Pprint(xGS);
        Console.WriteLine();

        // Here is Jacobi method
        for (var i = 0; i < maxIterations; i++)
        {
            var residual = Methods.RelativeResidual(matrix, xJacobi, f);

            if (residual < eps)
            {
                break;
            }

            Console.WriteLine($"Iteration: {i + 1} Residual: {residual} ");
            xJacobi = Methods.Iterate(xJacobi, xJacobi, matrix, w, f);
        }

        Console.WriteLine("Result by Jacobi:");
        Utils.Pprint(xJacobi);

        // Utils.SaveToCSV(CSVName);
        // Utils.SaveToFile(OutputFile);
    }
}
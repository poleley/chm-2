using System;
using System.IO;

namespace chm_2;

using static System.Math;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputFile = new StreamReader("input.txt");
        var matrixA = Utils.MatrixFromFile(inputFile);
        var x = Utils.VectorFromFile(inputFile);
        var xNext = new double[x.Length];
        var f = Utils.VectorFromFile(inputFile);
        var w = Utils.ReadDouble(inputFile);
        var maxIterations = Utils.ReadInt(inputFile);
        var eps = Utils.ReadDouble(inputFile);
        var diffEps = eps / 206.0;
        Utils.Pprint(matrixA);
        Utils.Pprint(f);

        Console.WriteLine();

        var xNew = new double[x.Length];
        x.AsSpan().CopyTo(xNew);

        // Here is Gauss-Seidel method
        for (var i = 0; i < maxIterations; i++)
        {
            var residual = Methods.RelativeResidual(matrixA, x, f);

            if (Abs(residual - eps) < diffEps)
            {
                break;
            }

            Console.WriteLine($"Iteration: {i + 1} Residual: {residual} ");
            x = Methods.Iterate(x, xNext, matrixA, w, f);
        }

        Console.WriteLine("Result by GS:");
        Utils.Pprint(x);
        Console.WriteLine();

        // Here is Jacobi method
        for (var i = 0; i < maxIterations; i++)
        {
            var residual = Methods.RelativeResidual(matrixA, xNew, f);

            if (Abs(residual - eps) < diffEps)
            {
                Console.WriteLine($"abs:{Abs(residual - eps)}");
                break;
            }

            Console.WriteLine($"Iteration: {i + 1} Residual: {residual} ");
            xNew = Methods.Iterate(xNew, xNew, matrixA, w, f);
        }

        Console.WriteLine("Result by Jacobi:");
        Utils.Pprint(xNew);
    }
}
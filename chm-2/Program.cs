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
            //Utils.Pprint(f);
            
            for (int i = 0; i < maxIterations; i++)
            {
                var residual = Methods.RelativeResidual(matrixA, x, f);
                if (residual < eps)
                {
                    break;
                }
                Console.WriteLine($"Iteration: {i+1} Residual: {residual} ");
                x = Methods.Iterate(x, matrixA, w, f, 1);
            }
            
            Utils.Pprint(x);

        }
    }
}
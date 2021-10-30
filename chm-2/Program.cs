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
        }
    }
}
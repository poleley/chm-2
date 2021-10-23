using System;
using System.IO;

namespace chm_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
            var matrixA = Utils.MatrixFromFile(inputFile);
            
        }
    }
}
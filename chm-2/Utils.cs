using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace chm_2
{
    public class Utils
    {
        public static double[] ReadDoubles(StreamReader file)
        {
            return file
                .ReadLine()!
                .Trim()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
        }

        public static double ReadDouble(StreamReader file)
        {
            var ln = file.ReadLine()!
                .Trim(' ');
            return double.Parse(ln);
        }

        private static int[] ReadInts(StreamReader file)
        {
            return file
                .ReadLine()!
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
        
        public static int ReadInt(StreamReader file)
        {
            var ln = file.ReadLine()!
                .Trim(' ');
            return int.Parse(ln);
        }

        public static double[] VectorFromFile(StreamReader file) => ReadDoubles(file);

        public static Matrix MatrixFromFile(StreamReader file)
        {
            var size = ReadInt(file);

            var diags = new double[7][];

            for (var i = 0; i < 7; i++)
            {
                diags[i] = ReadDoubles(file);
            }

            var shifts = ReadInts(file);
            return new Matrix(diags, shifts, size);
        }
        
        public static void Pprint(Matrix matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void Pprint(double[] vector)
        {
            foreach (var t in vector)
            {
                Console.Write($"{t} ");
            }
        }
    }
}
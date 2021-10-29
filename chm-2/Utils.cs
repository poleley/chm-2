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

        public static int[] ReadInts(StreamReader file)
        {
            return file
                .ReadLine()!
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }

        public static Matrix MatrixFromFile(StreamReader file)
        {
            var ln = file.ReadLine()!
                .Trim();

            var size = int.Parse(ln);

            var diags = new double[7][];

            for (var i = 0; i < 7; i++) diags[i] = ReadDoubles(file);

            var shifts = ReadInts(file);
            return new Matrix(diags, shifts, size);
        }
    }
}
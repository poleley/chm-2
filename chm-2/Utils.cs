using System;
using System.IO;
using System.Linq;

namespace chm_2;

public static class Utils
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

    public static double ReadDouble(StreamReader file) => double.Parse(file.ReadLine()!.Trim(' '));

    private static int[] ReadInts(StreamReader file)
    {
        return file
            .ReadLine()!
            .Trim()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
    }

    public static int ReadInt(StreamReader file) => int.Parse(file.ReadLine()!.Trim(' '));

    public static double[] VectorFromFile(StreamReader file) => ReadDoubles(file);

    public static Matrix MatrixFromFile(StreamReader file)
    {
        var n = ReadInt(file);
        var m = ReadInt(file);

        var upperPart = new double[3][];

        for (var i = 0; i < 3; i++)
        {
            upperPart[i] = ReadDoubles(file);
        }

        var diag = ReadDoubles(file);

        var lowPart = new double[3][];

        for (var i = 0; i < 3; i++)
        {
            lowPart[i] = ReadDoubles(file);
        }

        return new Matrix(n, m, diag, upperPart, lowPart);
    }

    public static void Pprint(double[] vector)
    {
        foreach (var t in vector)
        {
            Console.WriteLine($"{t} ");
        }
    }
}
using System;

namespace chm_2;

public class Matrix
{
    public readonly double[][] Diags;
    private readonly int DiagsSize;
    public readonly int[] Shifts;
    public readonly int Size;

    public Matrix()
    {
        DiagsSize = 7;
        Diags = new double[DiagsSize][];
        Shifts = Array.Empty<int>();
        Size = 0;
    }

    public Matrix(double[][] diags, int[] shifts, int size)
    {
        Diags = diags;
        Shifts = shifts;
        Size = size;
    }

    public double this[int i, int j] => GetElement(i, j);

    private double GetElement(int i, int j)
    {
        var shift = j - i;

        for (var k = 0; k < Shifts.Length; k++)
        {
            if (shift != Shifts[k])
            {
                continue;
            }

            return shift > 0 ? Diags[k][i] : Diags[k][j];
        }

        return 0.0;
    }
}
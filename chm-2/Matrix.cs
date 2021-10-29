using System;

namespace chm_2
{
    public class Matrix
    {
        public double[][] Diags;
        public int[] Shifts;
        public int Size;

        public Matrix()
        {
            Diags = new double[7][];
            Shifts = Array.Empty<int>();
            Size = 0;
        }

        public Matrix(double[][] diags, int[] shifts, int size)
        {
            Diags = diags;
            Shifts = shifts;
            Size = size;
        }
    }
}
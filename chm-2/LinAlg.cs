using System;
using System.Linq;

namespace chm_2;

public abstract class LinAlg
{
    public static double Norm(double[] x) => Math.Sqrt(x.Sum(t => t * t));

    public static double[] MatMul(Matrix matrix, double[] vec)
    {
        var res = new double[vec.Length];

        for (var i = 0; i < vec.Length; i++)
        {
            res[i] = ScalarProd(i, matrix, vec);
        }

        return res;
    }

    public static double ScalarProd(int i, Matrix matrix, double[] vec)
    {
        var res = 0.0;

        if (i > 0)
        {
            res += matrix.LowPart[0][i - 1] * vec[i - 1];

            if (i > matrix.M + 1)
            {
                res += matrix.LowPart[1][i - matrix.M - 2] * vec[i - matrix.M - 2];
            }

            if (i > matrix.M + 2)
            {
                res += matrix.LowPart[2][i - matrix.M - 3] * vec[i - matrix.M - 3];
            }
        }

        res += matrix.Diag[i] * vec[i];

        if (i < matrix.N - 1)
        {
            res += matrix.UpperPart[2][i] * vec[i + 1];

            if (i < matrix.N - matrix.M - 2)
            {
                res += matrix.UpperPart[1][i] * vec[i + matrix.M + 2];
            }

            if (i < matrix.N - matrix.M - 3)
            {
                res += matrix.UpperPart[0][i] * vec[i + matrix.M + 3];
            }
        }

        return res;
    }

    public static double GSLowScalarProd(int i, Matrix matrix, double[] vec)
    {
        var res = 0.0;

        if (i > 0)
        {
            res += matrix.LowPart[0][i - 1] * vec[i - 1];

            if (i > matrix.M + 1)
            {
                res += matrix.LowPart[1][i - matrix.M - 2] * vec[i - matrix.M - 2];
            }

            if (i > matrix.M + 2)
            {
                res += matrix.LowPart[2][i - matrix.M - 3] * vec[i - matrix.M - 3];
            }
        }

        return res;
    }

    public static double GSUpScalarProd(int i, Matrix matrix, double[] vec)
    {
        var res = 0.0;

        res += matrix.Diag[i] * vec[i];

        if (i < matrix.N - 1)
        {
            res += matrix.UpperPart[2][i] * vec[i + 1];

            if (i < matrix.N - matrix.M - 2)
            {
                res += matrix.UpperPart[1][i] * vec[i + matrix.M + 2];
            }

            if (i < matrix.N - matrix.M - 3)
            {
                res += matrix.UpperPart[0][i] * vec[i + matrix.M + 3];
            }
        }

        return res;
    }
}
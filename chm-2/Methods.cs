using System;

namespace chm_2;

public abstract class Methods
{
    public static double RelativeResidual(Matrix matrix, double[] x, double[] f)
    {
        var diff = new double[f.Length];

        var innerProd = LinAlg.MatMul(matrix, x);

        for (var i = 0; i < f.Length; i++)
        {
            diff[i] = f[i] - innerProd[i];
        }

        return LinAlg.Norm(diff) / LinAlg.Norm(f);
    }

    public static double[] IterateGS(double[] x, Matrix matrix, double w, double[] f)
    {
        for (var i = 0; i < x.Length; i++)
        {
            var sum = LinAlg.ScalarProd(i, matrix, x);

            x[i] += w * (f[i] - sum) / matrix.Diag[i];
        }

        return x;
    }

    public static double[] IterateJacoby(double[] x, Matrix matrix, double w, double[] f)
    {
        var xNext = new double[x.Length];

        for (var i = 0; i < x.Length; i++)
        {
            var sum = LinAlg.ScalarProd(i, matrix, x);

            xNext[i] = x[i] + w * (f[i] - sum) / matrix.Diag[i];
        }

        xNext.AsSpan().CopyTo(x);

        return x;
    }
}
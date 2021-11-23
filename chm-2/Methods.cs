namespace chm_2;

public static class Methods
{
    public static double RelativeResidual(Matrix matrixA, double[] x, double[] f)
    {
        var diff = new double[f.Length];

        var innerProd = LinAlg.Inner(matrixA, x);

        for (var i = 0; i < f.Length; i++)
        {
            diff[i] = f[i] - innerProd[i];
        }

        return LinAlg.Norm(diff) / LinAlg.Norm(f);
    }

    public static double[] Iterate(
        double[] x,
        double[] xNext,
        Matrix matrixA,
        double w,
        double[] f
    )
    {
        for (var i = 0; i < x.Length; i++)
        {
            var s1 = 0.0;
            var s2 = 0.0;

            for (var j = 0; j <= i - 1; j++)
            {
                s1 += matrixA[i, j] * xNext[j];
            }

            for (var j = i; j < x.Length; j++)
            {
                s2 += matrixA[i, j] * x[j];
            }

            xNext[i] = x[i] + w * (f[i] - s1 - s2) / matrixA[i, i];
        }

        return xNext;
    }
}
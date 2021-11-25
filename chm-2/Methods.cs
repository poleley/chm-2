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

    public static double[] Iterate(double[] x, double[] xNext, Matrix matrix, double w, double[] f)
    {
        for (var i = 0; i < x.Length; i++)
        {
            var lowSum = LinAlg.GSLowScalarProd(i, matrix, xNext);
            var upSum = LinAlg.GSUpScalarProd(i, matrix, x);

            xNext[i] = x[i] - w * (f[i] - lowSum - upSum) / matrix.Diag[i];
        }

        return xNext;
    }
}
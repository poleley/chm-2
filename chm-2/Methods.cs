namespace chm_2
{
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

        public static double[] Iterate(double[] x, Matrix matrixA, double w, double[] f)
        {
            var xNext = new double[x.Length];

            for (var i = 0; i < x.Length; i++)
            {
                xNext[i] = x[i] + w * (f[i] - LinAlg.Inner(matrixA, x)[i]) / matrixA[i, i];
            }

            return xNext;
        }
    }
}
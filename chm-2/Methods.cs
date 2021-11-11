using System;

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

        public static double[] Iterate(double[] x, Matrix matrixA, double w, double[] f, int a)
        {
            var xNext = new double[x.Length];
            var xNext1 = new double[x.Length];
            var sum = 0.0;
            xNext1[0] = xNext[0];
            for (var i = 0; i < x.Length; i++)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    sum += matrixA[i, j] * xNext[j];
                }
                xNext[i] = x[i] + w *
                    (f[i] - a * sum - LinAlg.Inner(matrixA, x)[i]) / matrixA[i, i];
                Console.Write($"{xNext[i]} ");
            }
            Console.WriteLine();
            
            return xNext;
        }
    }
}
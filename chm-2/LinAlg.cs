using System;
using System.Linq;

namespace chm_2
{
    public abstract class LinAlg
    {
        public static double Norm(double[] x)
        {
            var res = x.Sum(t => t * t);

            return Math.Sqrt(res);
        }

        public static double[] Inner(Matrix matrixA, double[] x)
        {
            var res = new double[x.Length];
            for (var i = 0; i < x.Length; i++)
            {
                for (var j = 0; j < x.Length; j++)
                {
                    res[i] += matrixA[i, j] * x[j];
                }
            }

            return res;
        }
    }
}
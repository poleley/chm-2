using System;

namespace chm_2
{
    public class Vector
    {
        public static double norm(double[] x, int n)
        {
            var res = 0.0;
            for (int i = 0; i < n; i++)
            {
                res += x[i] * x[i];
            }

            return Math.Sqrt(res);
        }
    }
}
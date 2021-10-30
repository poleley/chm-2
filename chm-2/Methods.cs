using System;

namespace chm_2
{
    public class Methods
    {
        public static double relativeResidual(double vectorNorm, double[] Ax, double[] b, int n)
        {
            double[] diff = new double[n];
            for (int i = 0; i < n; i++)
            {
                diff[i] = b[i] - Ax[i];
            }

            return Vector.norm(diff, n) / vectorNorm;
        }
    }
}
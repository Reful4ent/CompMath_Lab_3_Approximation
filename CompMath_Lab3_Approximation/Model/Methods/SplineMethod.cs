using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab3_Approximation.Model
{
    public class SplineMethod
    {
        public static Func<double, double> CubicSplineInterpolation(double[] xp, double[] yp)
        {
            double[] x= xp;
            double[] y = yp;
            double[] a = y;
            double[] b;
            double[] c;
            double[] d;

            int n = x.Length;
            double[] h = new double[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
            }

            double[] alpha = new double[n];
            for (int i = 1; i < n - 1; i++)
            {
                alpha[i] = (3 / h[i]) * (a[i + 1] - a[i]) - (3 / h[i - 1]) * (a[i] - a[i - 1]);
            }

            double[] l = new double[n];
            double[] mu = new double[n];
            double[] z = new double[n];
            l[0] = 1;
            mu[0] = 0;
            z[0] = 0;

            for (int i = 1; i < n - 1; i++)
            {
                l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
                mu[i] = h[i] / l[i];
                z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
            }

            l[n - 1] = 1;
            z[n - 1] = 0;
            c = new double[n];
            b = new double[n];
            d = new double[n];
            for (int j = n - 2; j >= 0; j--)
            {
                c[j] = (float)(z[j] - mu[j] * c[j + 1]);
                b[j] = (float)(((a[j + 1] - a[j]) / h[j]) - (h[j] * (c[j + 1] + 2 * c[j]) / 3));
                d[j] = (float)((c[j + 1] - c[j]) / (3 * h[j]));
            }


            Func<double, double> SplinePolynomial = new Func<double, double>((x) =>
            {
                int j = 0;
                while (j < xp.Length - 1 && x > xp[j + 1])
                {
                    j++;
                }
                double dx = x - xp[j];
                return a[j] + b[j] * dx + c[j] * dx * dx + d[j] * dx * dx * dx;
            });



            return SplinePolynomial;
        }
    }
}

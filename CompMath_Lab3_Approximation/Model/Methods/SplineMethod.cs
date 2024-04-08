using CompMath_Lab_2;
using OpenTK.Graphics.ES20;

namespace CompMath_Lab3_Approximation.Model
{
    public class SplineMethod
    {
        private static double[,] splineSystem;
        private static double[] x;
        private static double[]  a;
        private static double[] b;
        private static double[] c;
        private static double[] d;
        public static Func<double, double> CubicSplineInterpolation(double[] xp, double[] yp)
        {
            x = xp;
            double[] y = yp;
            a = y;


            int n = x.Length;
            c = new double[n];
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
            
            GetC(ref c,alpha,h);
            Array.Resize(ref c,c.Length+1);
            
            b = new double[n];
            d = new double[n];
            for (int j = n - 2; j >= 0; j--)
            {
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



        private static void GetC(ref double[] c,double[] alpha,double[] h)
        {
            double[,] matrix = new double[ c.Length - 1  ,c.Length - 1];
            double[] freeMembers = new double[c.Length - 1];
            int rowIndex = 1;

            matrix[0, 0] = 1;

            for (int i = 1; i < c.Length - 1; i++)
            {
                matrix[rowIndex, i - 1] = h[i - 1];
                matrix[rowIndex, i] = 2 * (h[i - 1] + h[i]);
                if (i + 1 != c.Length - 1)
                    matrix[rowIndex, i + 1] = h[i];
                freeMembers[rowIndex] = alpha[rowIndex];
                rowIndex++;
            }

            freeMembers = PassingMethod.PassingIteration(matrix, freeMembers);
            c = freeMembers;
            return;
        }

        public static double Interpolate(double xF)
        {
            int j = 0;
            while (j < x.Length - 1 && xF > x[j + 1])
            {
                j++;
            }
            double dx = xF - x[j];
            return a[j] + b[j] * dx + c[j] * dx * dx + d[j] * dx * dx * dx;
        }
    }
}

using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CompMath_Lab3_Approximation.Model
{
    public class NutonMethod
    {
        public static Func<double, double> CreateNuton(double[] X, double[] Y)
        {
            TableXY tableXY = new TableXY();
            tableXY.SetTable(X,Y);
            double[] result = new double[X.Length+1];
            for (int i = 0; i < X.Length + 1; i++)
                result[i] = DividedDifferences(tableXY, i);
            Func<double, double> NutonPolynomial = new Func<double, double>((x) =>
            {
                double tmp = Y[0];
                for(int i = 1; i < X.Length + 1; i++)
                {
                    double temp = 1;
                    for(int j = 0;  j < Y.Length + 1;j++)
                        tmp *= x-X[j];
                    tmp += result[i - 1] * temp;
                }
                return x;
            });
            return NutonPolynomial;
        }
        public static double DividedDifferences(TableXY tableXY, int k)
        {
            double[] x = tableXY.GetX();
            double[] y = tableXY.GetY();
            double tmp = 0;
            for(int i = 0; i < k; i++)
            {
                double n = 1;
                for(int j = 0; j < k; j++)
                {
                    if (i != j)
                        n *= x[i] - x[j];
                }
                tmp += y[i] / n;
            }
            return tmp;
        }
    }
}

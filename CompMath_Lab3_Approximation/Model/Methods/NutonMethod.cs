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
            double[] divDiff = new double[X.Length];
            for (int i = 1; i < X.Length; i++)
                divDiff[i] = DividedDifferences(tableXY, i);
            Func<double, double> NutonPolynomial = new Func<double, double>((x) =>
            {
                double result = Y[0];
                for (int k = 0; k < Y.Length; k++)
                {
                    double mul = 1;
                    for (int j = 0; j < k; j++)
                        mul *= x-X[j];
                    result += divDiff[k] * mul;
                }
                return result;
            });
            return NutonPolynomial;
        }
        public static double DividedDifferences(TableXY tableXY, int k)
        {
            double[] x = tableXY.GetX();
            double[] y = tableXY.GetY();
            double result = 0;
            for (int j = 0; j < k+1; j++)
            {
                double mul = 1;
                for(int i = 0; i < k+1; i++)
                {
                    if(i != j)
                        mul *= x[j] - x[i];
                }
                result += y[j]/mul;
            }
            return result;
        }
    }
}

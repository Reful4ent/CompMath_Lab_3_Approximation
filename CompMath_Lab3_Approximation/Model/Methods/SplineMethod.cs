using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab3_Approximation.Model
{
    public class SplineMethod
    {
        public static Func<double, double> CreateLagrange(double[] X, double[] Y)
        {
            Func<double, double> lagrangePolynomial = new Func<double, double>((x) =>
            {
                double result = 0;
                return result;
            });
            return lagrangePolynomial;
        }
    }
}

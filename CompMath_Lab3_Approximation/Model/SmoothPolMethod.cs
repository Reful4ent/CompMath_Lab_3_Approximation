using CompMath_Lab_2;

namespace CompMath_Lab3_Approximation.Model;

public class SmoothPolMethod
{
    public static Func<double, double> CreateSmooth(double[] X, double[] Y, int degree)
    {
        double[,] MatrixA = new double[degree + 1, degree + 1];
        double[] freeMembers = new double[degree+1];

        for (int k = 0; k < X.Length; k++)
        {
            for (int i = 0; i < degree + 1; i++)
            {
                for (int j = 0; j < degree + 1; j++)
                {
                    MatrixA[i, j] += Math.Pow(X[k],i+j);
                }
            
            }

            for (int i = 0; i < Y.Length; i++)
            {
                freeMembers[i] += Y[k] + Math.Pow(X[i], i);
            }
        }
        Matrix.PrintMatrix(MatrixA,freeMembers);
        Func<double, double> smoothPolynomial = new Func<double, double>((x) =>
        {
            var c = 0;
            return c;
        });
        return smoothPolynomial;
    }
}
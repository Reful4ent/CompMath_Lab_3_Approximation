using CompMath_Lab_2;

namespace CompMath_Lab3_Approximation.Model;

public class SmoothPolMethod
{
    public static Func<double, double> CreateSmooth(double[] X, double[] Y, int degree)
    {
        double[,] MatrixA = new double[degree + 1, degree + 1];
        double[] freeMembers = new double[degree+1];

        for (int k = 0; k < degree + 1; k++){
            
            for (int i = 0; i < degree + 1; i++)
                for (int j = 0; j < X.Length; j++)
                    MatrixA[k, i] += Math.Pow(X[j],k+i);

            for (int i = 0; i < Y.Length; i++)
                freeMembers[k] += Y[i] * Math.Pow(X[i], k);
        }
        freeMembers = GaussMethod.GaussWithElement(MatrixA,freeMembers);
        Func<double, double> smoothPolynomial = new Func<double, double>((x) =>
        {
            double Func = 0;
            for (int i = 0; i < freeMembers.Length; i++)
            {
                Func += Math.Pow(x, X.Length - (i+1)) * freeMembers[i];
            }
            return Func;
        });
        return smoothPolynomial;
    }
}
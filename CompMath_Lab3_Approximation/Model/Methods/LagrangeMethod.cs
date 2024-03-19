namespace CompMath_Lab3_Approximation.Model;

public class LagrangeMethod
{
    /// <summary>
    /// Создает полином Лагранжа
    /// </summary>
    /// <param name="X">массив X из таблицы OY</param>
    /// <param name="Y">массив Y из таблицы OY</param>
    /// <returns></returns>
    public static Func<double,double> CreateLagrange(double[] X, double[] Y)
    {
        List<Func<double, double>> basicPolynomial = new List<Func<double, double>>();
        double[] tempX = X;
        
        for (int i = 0; i < tempX.Length; i++)
            basicPolynomial.Add(CreateBasicPolynomial(tempX,i));
        
        Func<double, double> lagrangePolynomial = new Func<double, double>((x) =>
        {
            double result = 0;
            for (int i = 0; i < tempX.Length; i++)
                result += Y[i] * basicPolynomial[i].Invoke(x);
            return result;
        });
        return lagrangePolynomial;
    }
    
    /// <summary>
    /// Создает промежуточный полином
    /// </summary>
    /// <param name="X">массив X из таблицы OY</param>
    /// <param name="i">индекс промежуточного полиндрома</param>
    /// <returns></returns>
    private static Func<double,double> CreateBasicPolynomial(double[] X, int i)
    {
        Func<double, double> basicPolynomial = new Func<double, double>((x) =>
        {
            double numerator = 1;
            double denominator = 1;
            for (int k = 0; k < X.Length; k++)
            {
                if (k == i)
                    continue;
                numerator *= (x - X[k]);
                denominator *= (X[i] - X[k]);
            }
            return numerator / denominator;
        });
        return basicPolynomial;
    }
}
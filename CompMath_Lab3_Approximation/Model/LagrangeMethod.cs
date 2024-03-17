namespace CompMath_Lab3_Approximation.Model;

public class LagrangeMethod
{
    public static Func<double,double> CreateLagrange(ITableOY table)
    {
        List<Func<double, double>> basicPolynomial = new List<Func<double, double>>();
        float[] tempX = new float[table.Table.GetUpperBound(1) + 1];
        
        for (int i = 0; i < table.Table.GetUpperBound(1) + 1; i++)
            tempX[i] = table.Table[0, i];
        for (int i = 0; i < table.Table.GetUpperBound(1) + 1; i++)
            basicPolynomial.Add(CreateBasicPolynomial(tempX,i));
        
        Func<double, double> lagrangePolynomial = new Func<double, double>((x) =>
        {
            double result = 0;
            for (int i = 0; i < tempX.Length; i++)
                result += table.Table[1, i] * basicPolynomial[i].Invoke(x);
            return result;
        });
        return lagrangePolynomial;
    }

    private static Func<double,double> CreateBasicPolynomial(float[] X, int i)
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
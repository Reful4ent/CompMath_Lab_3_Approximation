namespace CompMath_Lab3_Approximation.Model.Methods;

public class RatiosMethod
{
    public static Func<double, double> CreateRation(double[] ratios)
    {
        Func<double, double> function = new Func<double, double>((x) =>
        {
            double xWithRatio = 0;
            for (int i = 0; i < ratios.Length; i++)
            {
                xWithRatio += ratios[i] * Math.Pow(x, ratios.Length - (1 + i));
            }

            return xWithRatio;
        });
        return function;
    }
}
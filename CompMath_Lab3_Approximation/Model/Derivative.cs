namespace CompMath_Lab3_Approximation.Model;

public class Derivative
{
    
    public static double[,] CalculateFirstDerivative(double[,] table, double step)
    {
        for (int i = 0; i < table.GetLength(1); i++)
        {    
            table[1, i] = (5 * Math.Pow(table[0, i], 2) - 5 * Math.Pow(table[0, i]-step, 2)) / step;
        }
        Console.WriteLine();
        return table;
    }

    public static double CalculateFirstSplineDerivative(double prevY, double nexty, double step)
    {
        return (nexty - prevY) / (2 * step);
    }

    public static double CalculateSecondSpineDerivative(double prevTwoY, double nextTwoY, double y, double step) =>
        (nextTwoY-2*y+prevTwoY) / (4 * Math.Pow(step, 2));

}
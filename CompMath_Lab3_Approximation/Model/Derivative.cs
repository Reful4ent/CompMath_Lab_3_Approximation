namespace CompMath_Lab3_Approximation.Model;

public class Derivative
{
    public static double[,] CalculateFirstDerivative(double[,] table, double step)
    {
        for (int i = 0; i < table.GetLength(1); i++)
        {
            table[1, i] = (5 * Math.Pow(table[0, i], 2) - 5 * Math.Pow(table[0, i]-step, 2)) / step;
            Console.Write(table[1,i] + " ");
        }
        Console.WriteLine();
        return table;
    }
}
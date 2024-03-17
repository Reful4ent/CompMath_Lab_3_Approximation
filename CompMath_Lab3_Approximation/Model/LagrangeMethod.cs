namespace CompMath_Lab3_Approximation.Model;

public class LagrangeMethod
{
    public static bool CountLagrange(ITableOY table)
    {
        float[] y = new float [table.Table.GetUpperBound(1) + 1];
        float functionResult = 0;
        for (int i = 0; i < table.Table.GetUpperBound(1) + 1; i++)
        {
            float l = 0;
            for (int j = 0; j < table.Table.GetUpperBound(1) + 1; j++)
            {
                float numerator = 1;
                float denominator = 1;
                for (int k = 0; k < table.Table.GetUpperBound(1) + 1; j++)
                {
                    if (k==i)
                        continue;
                    numerator *= (table.Table[0, i] - table.Table[0, k]);
                    denominator *= (table.Table[0, j] - table.Table[0, k]);
                }
                l += numerator / denominator * table.Table[1, j];
            }

            y[i] = functionResult = l;
        }

        foreach (var item in y)
        {
            Console.Write(item);
        }
        return true;
    }
}
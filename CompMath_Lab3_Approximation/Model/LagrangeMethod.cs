namespace CompMath_Lab3_Approximation.Model;

public class LagrangeMethod
{
    public static bool CountLagrange(ITableOY table)
    {
        for (int i = 0; i < table.Table.GetUpperBound(1) + 1; i++)
        {
            float l = 0;
            for (int j = 0; j < table.Table.GetUpperBound(1) + 1; j++)
            {
                float numerator = 1;
                float denominator = 1;
                for (int k = 0; k < table.Table.GetUpperBound(1) + 1; k++)
                {
                    if (k==j)
                        continue;
                    numerator *= (table.Table[0, i] - table.Table[0, k]);
                    denominator *= (table.Table[0, j] - table.Table[0, k]);
                }
                l += numerator / denominator * table.Table[1, j];
            }
            table.Table[1, i] = l;
        }
        return true;
    }
}
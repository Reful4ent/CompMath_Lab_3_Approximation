namespace CompMath_Lab3_Approximation.Model;

public interface ITableOY
{
    public float[,] Table { get; }
    public bool SetTable(float[] X, float[] Y);
}
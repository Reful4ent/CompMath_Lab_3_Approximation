namespace CompMath_Lab3_Approximation.Model;

public interface ITable : IGivePoints
{
    public double[,] Table { get; }
    public bool SetTable(double[] X, double[] Y);
    public void ClearTable();
}
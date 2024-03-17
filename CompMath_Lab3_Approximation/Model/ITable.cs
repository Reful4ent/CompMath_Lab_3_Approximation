namespace CompMath_Lab3_Approximation.Model;

public interface ITable
{
    public double[,] Table { get; }
    public bool SetTable(double[] X, double[] Y);
    public void ClearTable();
    public double[] GetX();
    public double[] GetY();
}
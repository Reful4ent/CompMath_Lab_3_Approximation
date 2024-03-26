namespace CompMath_Lab3_Approximation.Model;

public interface ITable : IGivePoints
{
    public double[,] Table { get; }
    public double[] RatiosList { get;}
    public bool SetRatios(double[] ratios);
    public bool SetTable(double[] X, double[] Y);
    public void ClearTable();
    public void ClearRatios();
}
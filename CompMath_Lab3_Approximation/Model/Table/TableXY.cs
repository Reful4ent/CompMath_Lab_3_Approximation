namespace CompMath_Lab3_Approximation.Model
{
    public class TableXY : ITable
    {
        public double[,] Table { get; private set; }
        
        public static TableXY Instance() => new();

        public double[] RatiosList { get; private set; }
        
        public bool SetTable(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                return false;
            SortElements(ref x,ref y, 0, x.Length-1);
            if (!(CheckIncrease(x) && CheckDuplicate(ref x,ref y)))
                return false;
            
            Table = new double[2, x.Length];
            for (int i = 0; i < x.Length; i++)
                Table[0, i] = x[i];
            for (int i = 0; i < x.Length; i++)
                Table[1, i] = y[i];
            
            return true;
        }

        private void SortElements(ref double[] x, ref double[]y, int leftIndex,int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            double xI = x[leftIndex];
            double yI = y[leftIndex];
            while (i <= j)
            {
                while (x[i] < xI)
                    i++;
                while (x[j] > xI)
                    j--;
                if (i <= j)
                {
                    double tempX = x[i];
                    double tempY = y[i];
                    x[i] = x[j];
                    x[j] = tempX;
                    y[i] = y[j];
                    y[j] = tempY;
                    i++;
                    j--;
                }
            }
            if(leftIndex < j)
                SortElements(ref x, ref y,leftIndex, j);
            if (i < rightIndex)
                SortElements(ref x, ref y, i, leftIndex);
        }

        public bool SetRatios(double[] ratios)
        {
            if (ratios == null)
                return false;
            RatiosList = ratios;
            return true;
        }

        private bool CheckIncrease(double[] x)
        {
            for (int i = 1; i < x.Length; i++)
                if (x[i] < x[i - 1])
                    return false;
            
            return true;
        }
        private bool CheckDuplicate(ref double[] x,ref double[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if(i==j)
                        continue;
                    if (x[i] == x[j] && y[i]!=y[j])
                        return false;
                    if (x[i] == x[j] && y[i] == y[j])
                    {
                        var tempX = x.ToList();
                        tempX.RemoveAt(j);
                        x = tempX.ToArray();
                        var tempY = y.ToList();
                        tempY.RemoveAt(j);
                        y = tempY.ToArray();
                    }
                }
            }

            return true;
        }
        
        
        public void ClearTable() => Array.Clear(Table, 0, Table.Length);
        public void ClearRatios() => Array.Clear(RatiosList, 0, RatiosList.Length);

        /// <summary>
        /// Возвращает массив X из таблицы XY
        /// </summary>
        /// <returns></returns>
        public double[] GetX()
        {
            double[] X = new double[Table.GetUpperBound(1) + 1];
            for (int i = 0; i < Table.GetUpperBound(1) + 1; i++)
                X[i] = Table[0, i];
            return X;
        }
        /// <summary>
        /// Возвращает массив Y из таблицы XY
        /// </summary>
        /// <returns></returns>
        public double[] GetY()
        {
            double[] Y = new double[Table.GetUpperBound(1) + 1];
            for (int i = 0; i < Table.GetUpperBound(1) + 1; i++)
                Y[i] = Table[1, i];
            return Y;
        }

        public double[] GetRatios() => RatiosList;

    }
}
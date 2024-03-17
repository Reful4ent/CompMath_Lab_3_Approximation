using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab3_Approximation.Model
{
    public class TableOY : ITableOY
    {
        public float[,] Table { get; private set; }

        public static TableOY Instance() => new();
        public bool SetTable(float[] x, float[] y)
        {
            if (x.Length != y.Length)
                return false;
            Table = new float[2, x.Length];
            for (int i = 0; i < x.Length; i++)
                Table[0, i] = x[i];
            for (int i = 0; i < x.Length; i++)
                Table[1, i] = y[i];
            return true;
        }
    }
}
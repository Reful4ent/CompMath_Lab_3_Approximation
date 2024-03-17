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
        
        public bool SetTable(float[] X, float[] Y)
        {
            if (X.Length != Y.Length)
                return false;
            Table = new float[2, X.Length];
            for (int i = 0; i < X.Length; i++)
                Table[0, i] = X[i];
            for (int i = 0; i < X.Length; i++)
                Table[0, i] = Y[i];
            return true;
        }

        public float[,] Lagrange()
        {
            LagrangeMethod.CountLagrange(this);
            return Table;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompMath_Lab3_Approximation.Model
{
    public class TableXY : ITable
    {
        public double[,] Table { get; private set; }
        
        public static TableXY Instance() => new();
        public bool SetTable(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                return false;
            Table = new double[2, x.Length];
            for (int i = 0; i < x.Length; i++)
                Table[0, i] = x[i];
            for (int i = 0; i < x.Length; i++)
                Table[1, i] = y[i];
            return true;
        }

        public void ClearTable() => Array.Clear(Table, 0, Table.Length);

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

    }
}
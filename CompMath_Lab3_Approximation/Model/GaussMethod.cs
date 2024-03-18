namespace CompMath_Lab_2
{
    public static class GaussMethod
    {
        /// <summary>
        /// Метод гауса с выбором главного элемента по строке
        /// Gauss's method with the selection of main element by line
        /// </summary>
        public static void GaussWithElement(double[,] mainMatrix, double[] freeMembers)
        {
            for(int i = 0; i < mainMatrix.GetUpperBound(1)+1; i++)
            {
                ChangeColumns(ref mainMatrix, i);
                for (int j = i + 1; j < mainMatrix.GetUpperBound(0) + 1; j++)
                {
                    double number = (mainMatrix[j, i] / mainMatrix[i, i]);
                    for (int k = i; k < mainMatrix.GetUpperBound(1) + 1; k++)
                        mainMatrix[j, k] -= mainMatrix[i, k] * number;
                    freeMembers[j] -= freeMembers[i] * number;
                }
            }
            ReverseMotion(mainMatrix, freeMembers);
        }

        /// <summary>
        /// Изменяет порядок столбцов в матрице
        /// Change columns in the matrix
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="row"></param>
        private static void ChangeColumns(ref double[,] mainMatrix, int row)
        {
            double maxValue = mainMatrix[row, 0];
            double[] temp = new double[mainMatrix.GetUpperBound(0) + 1];
            int column = 0;
            for (int i = row; i < mainMatrix.GetUpperBound(1) + 1; i++)
            {
                if (Math.Abs(mainMatrix[row, i]) > maxValue)
                {
                    maxValue = Math.Abs(mainMatrix[row, i]);
                    column = i;
                }
            }
            for (int j = 0; j < mainMatrix.GetUpperBound(0) + 1; j++)
                temp[j] = mainMatrix[j, column];
            for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                mainMatrix[j, column] = mainMatrix[j, row];
            for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                mainMatrix[j, row] = temp[j];
        }


        /// <summary>
        /// Обратный ход для метода Гауса
        /// Reverse motion for Gauss's method
        /// </summary>
        public static void ReverseMotion(double[,] mainMatrix, double[]freeMembers)
        {
            double sum = 0;
            for(int i = mainMatrix.GetUpperBound(0);i >= 0; i--)
            {
                for (int j = mainMatrix.GetUpperBound(1); j > i; j--)
                    sum += mainMatrix[i, j] * freeMembers[j];
                freeMembers[i] = 1 / mainMatrix[i, i]*(freeMembers[i]-sum);
                sum = 0;
            }
            Matrix.PrintMatrix(mainMatrix,freeMembers);
        }
    }
}
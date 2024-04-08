namespace CompMath_Lab_2
{
    public static class PassingMethod
    {
        /// <summary>
        /// Метод прогонки для трехдиагональной матрицы
        /// Passing method for a tridiagonal matrix
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="freeMembers"></param>
        public static double[] PassingIteration(double[,] mainMatrix, double[] freeMembers)
        {
            for (int i = 1; i< mainMatrix.GetUpperBound(0)+1; i++)
            {
                mainMatrix[i, i] -= mainMatrix[i, i - 1] * mainMatrix[i - 1, i] / (mainMatrix[i-1,i-1]);
                freeMembers[i] -= mainMatrix[i, i-1] * freeMembers[i - 1] / mainMatrix[i - 1, i - 1];
                mainMatrix[i, i - 1] = 0;
            }
            //freeMembers[freeMembers.Length - 1] = freeMembers[freeMembers.Length - 1] / mainMatrix[mainMatrix.GetUpperBound(0), mainMatrix.GetUpperBound(0)];
            //for (int i = mainMatrix.GetUpperBound(0) - 1; i >= 0; i--)
            //{
            //    freeMembers[i] = (freeMembers[i] - mainMatrix[i, i + 1]) / mainMatrix[i, i];
            //}
            //Matrix.PrintMatrix(mainMatrix, freeMembers);


            GaussMethod.ReverseMotion(ref mainMatrix, ref freeMembers);
            return freeMembers;
        }
        private static bool IsTridiagonal(double[,] mainMatrix)
        {
            for (int i = 0; i < mainMatrix.GetUpperBound(0) - 1; i++)
            {
                for (int j = 2 + i; j < mainMatrix.GetUpperBound(1)+1; j++)
                {
                    if (mainMatrix[i, j] != 0)
                        return false;
                }
            }

            for(int i = mainMatrix.GetUpperBound(0); i > 0; i--)
            {
                for (int j = i-1; j > 1; j--)
                {
                    if (mainMatrix[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
    }
}

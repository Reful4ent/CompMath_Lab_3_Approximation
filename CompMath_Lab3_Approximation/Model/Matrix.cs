namespace CompMath_Lab_2
{
    public static class Matrix
    {
        public static void PrintMatrix(double[,] mainMatrix, double[] ansMatrix)
        {
            for(int i=0; i< mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(mainMatrix[i, j]+"   ");
                }
                Console.Write("\t\t\t");
                Console.Write("{0:f8}",ansMatrix[i]);
                Console.WriteLine();
            }
        }
    }
}

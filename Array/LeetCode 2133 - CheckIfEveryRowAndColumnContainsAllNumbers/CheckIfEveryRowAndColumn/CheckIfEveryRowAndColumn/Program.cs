using System;
using System.Collections.Generic;

namespace CheckIfEveryRowAndColumn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckValid(int[][] matrix)
        {
            var n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                var rowNums = new HashSet<int>();
                var colNums = new HashSet<int>();
                int rowSum = 0, colSum = 0;
                for (int j = 0; j < n; j++)
                {
                    rowSum += matrix[i][j];
                    colSum += matrix[j][i];
                    rowNums.Add(matrix[i][j]);
                    colNums.Add(matrix[j][i]);
                }
                if (rowSum != (1 + n) * n / 2 || rowNums.Count != n)
                    return false;
                if (colSum != (1 + n) * n / 2 || colNums.Count != n)
                    return false;
            }
            return true;
        }
    }
}

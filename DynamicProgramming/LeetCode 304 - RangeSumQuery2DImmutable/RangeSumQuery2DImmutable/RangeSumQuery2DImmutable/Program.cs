using System;

namespace RangeSumQuery2DImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class NumMatrix
    {
        private int[][] sum;
        public NumMatrix(int[][] matrix)
        {
            sum = new int[matrix.Length][];
            for (int r = 0; r < matrix.Length; r++)
            {
                sum[r] = new int[matrix[0].Length];
                sum[r][0] = matrix[r][0];
                for (int c = 1; c < matrix[0].Length; c++)
                    sum[r][c] = sum[r][c - 1] + matrix[r][c];
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var res = 0;
            for (int r = row1; r <= row2; r++)
                res += col1 == 0 ? sum[r][col2] : sum[r][col2] - sum[r][col1 - 1];
            return res;
        }
    }

    public class NumMatrix_DP
    {
        private int[][] sum;
        public NumMatrix(int[][] matrix)
        {
            sum = new int[matrix.Length][];
            for (int r = 0; r < matrix.Length; r++)
                sum[r] = new int[matrix[0].Length];
            if (matrix.Length != 0 && matrix[0].Length != 0)
            {
                sum[0][0] = matrix[0][0];
                for (int r = 1; r < matrix.Length; r++)
                    sum[r][0] = matrix[r][0] + sum[r - 1][0];
                for (int c = 1; c < matrix[0].Length; c++)
                    sum[0][c] = matrix[0][c] + sum[0][c - 1];
                for (int r = 1; r < matrix.Length; r++)
                {
                    for (int c = 1; c < matrix[0].Length; c++)
                    {
                        sum[r][c] = sum[r - 1][c] + sum[r][c - 1] - sum[r - 1][c - 1] + matrix[r][c];
                    }
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var res = sum[row2][col2];
            if (row1 != 0) res -= sum[row1 - 1][col2];
            if (col1 != 0) res -= sum[row2][col1 - 1];
            if (row1 != 0 && col1 != 0) res += sum[row1 - 1][col1 - 1];
            return res;
        }
    }
}

//将数字记录入一个数组，再排列到相应的位置。
using System;

namespace RotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };
            Rotate(matrix);
        }
        static void Rotate(int[][] matrix)
        {
            int row = matrix.Length;
            if (row == 0)
                return;
            int col = matrix[0].Length;
            int[] record = new int[row * col];
            int index = 0;
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    record[index++] = matrix[r][c];
            index = 0;
            for (int c = col - 1; c >= 0; c--)
                for (int r = 0; r < row; r++)
                    matrix[r][c] = record[index++];
        }
        public void Rotate_InPlace(int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = r; c < matrix[0].Length; c++)
                {
                    int temp = matrix[r][c];
                    matrix[r][c] = matrix[c][r];
                    matrix[c][r] = temp;
                }
            }
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length / 2; c++)
                {
                    int temp = matrix[r][c];
                    matrix[r][c] = matrix[r][matrix[0].Length - c - 1];
                    matrix[r][matrix[0].Length - c - 1] = temp;
                }
            }
        }
    }
}

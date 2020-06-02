using System;
using System.Collections.Generic;

namespace SortTheMatrixDiagonally
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[3][];
            mat[0] = new int[] {3, 3, 1, 1};
            mat[1] = new int[] {2, 2, 1, 2};
            mat[2] = new int[] {1, 1, 1, 2};
            Console.WriteLine(DiagonalSort(mat));
        }
        static int[][] DiagonalSort(int[][] mat)
        {
            for (int r = 0; r < mat.Length; r++)
            {
                var record = new List<int>();
                int point = 0;
                while (point < mat[0].Length && r + point < mat.Length)
                {
                    record.Add(mat[r + point][point]);
                    point++;
                }
                record.Sort();
                point = 0;
                while (point < mat[0].Length && r + point < mat.Length)
                    mat[r + point][point] = record[point++];
            }
            for (int c = 1; c < mat[0].Length; c++)
            {
                var record = new List<int>();
                int point = 0;
                while (point < mat.Length && c + point < mat[0].Length)
                {
                    record.Add(mat[point][c + point]);
                    point++;
                }
                record.Sort();
                point = 0;
                while (point < mat.Length && c + point < mat[0].Length)
                    mat[point][c + point] = record[point++];
            }
            return mat;
        }
    }
}

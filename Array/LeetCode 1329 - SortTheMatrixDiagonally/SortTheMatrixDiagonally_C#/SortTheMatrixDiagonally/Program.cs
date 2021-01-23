using System;
using System.Collections.Generic;

namespace SortTheMatrixDiagonally
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[3][];
            mat[0] = new int[] { 3, 3, 1, 1 };
            mat[1] = new int[] { 2, 2, 1, 2 };
            mat[2] = new int[] { 1, 1, 1, 2 };
            Console.WriteLine(DiagonalSort(mat));
        }
        static int[][] DiagonalSort(int[][] mat)
        {
            for (int r = 0; r < mat.Length; r++)
            {
                var record = new List<int>();
                int pointer = 0;
                while (r + pointer < mat.Length && pointer < mat[0].Length)
                {
                    record.Add(mat[r + pointer][pointer]);
                    pointer++;
                }
                record.Sort();
                pointer = 0;
                while (r + pointer < mat.Length && pointer < mat[0].Length)
                    mat[r + pointer][pointer] = record[pointer++];
            }
            for (int c = 1; c < mat[0].Length; c++)
            {
                var record = new List<int>();
                int pointer = 0;
                while (pointer < mat.Length && pointer + c < mat[0].Length)
                {
                    record.Add(mat[pointer][pointer + c]);
                    pointer++;
                }
                record.Sort();
                pointer = 0;
                while (pointer < mat.Length && pointer + c < mat[0].Length)
                    mat[pointer][pointer + c] = record[pointer++];
            }
            return mat;
        }
    }
}

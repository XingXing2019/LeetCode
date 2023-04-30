using System;
using System.Collections.Generic;

namespace FirstCompletelyPaintedRowOrColumn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 5, 2, 6, 3 };
            int[][] mat = new int[][]
            {
                new[] { 4, 3, 5 },
                new[] { 1, 2, 6 },
            };
            Console.WriteLine(FirstCompleteIndex(arr, mat));
        }

        public static int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            var rows = new Dictionary<int, int>();
            var cols = new Dictionary<int, int>();
            var pos = new Dictionary<int, int[]>();
            for (int i = 0; i < m; i++)
            {
                rows[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    cols[j] = 0;
                    pos[mat[i][j]] = new[] { i, j };
                }
            }
            for (var i = 0; i < arr.Length; i++)
            {
                int row = pos[arr[i]][0], col = pos[arr[i]][1];
                rows[row]++;
                cols[col]++;
                if (rows[row] == n || cols[col] == m)
                    return i;
            }
            return -1;
        }
    }
}

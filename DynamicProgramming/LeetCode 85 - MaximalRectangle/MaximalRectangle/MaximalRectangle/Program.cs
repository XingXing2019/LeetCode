using System;
using System.Runtime.InteropServices.ComTypes;

namespace MaximalRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new[]
            {
                new[] { '1', '0', '1', '0', '0' },
                new[] { '1', '0', '1', '1', '1' },
                new[] { '1', '1', '1', '1', '1' },
                new[] { '1', '0', '0', '1', '0' },
            };
            Console.WriteLine(MaximalRectangle(matrix));
        }

        public static int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return 0;
            int m = matrix.Length, n = matrix[0].Length, res = 0;
            int[][] leftMatrix = new int[m][], rightMatrix = new int[m][], heightMatrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                heightMatrix[i] = new int[n];
                leftMatrix[i] = new int[n];
                rightMatrix[i] = new int[n];
                Array.Fill(rightMatrix[i], n);
                int left = n, right = -1;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        left = n;
                        heightMatrix[i][j] = 0;
                    }
                    else
                    {
                        left = Math.Min(left, j);
                        leftMatrix[i][j] = i == 0 ? left : Math.Max(leftMatrix[i - 1][j], left);
                        heightMatrix[i][j] = i == 0 ? 1 : heightMatrix[i - 1][j] + 1;
                    }
                }
                for (int j = n - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == '0')
                        right = -1;
                    else
                    {
                        right = Math.Max(right, j);
                        rightMatrix[i][j] = i == 0 ? right : Math.Min(rightMatrix[i - 1][j], right);
                        res = Math.Max(res, (rightMatrix[i][j] - leftMatrix[i][j] + 1) * heightMatrix[i][j]);
                    }
                }
            }
            return res;
        }
    }
}

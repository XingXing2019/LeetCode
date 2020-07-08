using System;

namespace _01Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[][]
            {
                new int[]{0,0,0},
                new int[]{0,1,1},
                new int[]{1,0,1},
            };
            Console.WriteLine(UpdateMatrix(matrix));
        }

        static int[][] UpdateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return matrix;
            var res = new int[matrix.Length][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[matrix[0].Length];
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    if (matrix[x][y] == 0) continue;
                    res[x][y] = DFS(matrix, res, x, y);
                }
            }
            return res;
        }

        static int DFS(int[][] matrix, int[][] result, int x, int y)
        {
            if (matrix[x][y] == 0) return 0;
            if (x > 0 && matrix[x - 1][y] == 0 || x < matrix.Length - 1 && matrix[x + 1][y] == 0)
                return 1;
            if (y > 0 && matrix[x][y - 1] == 0 || y < matrix[0].Length - 1 && matrix[x][y + 1] == 0)
                return 1;
            int min = int.MaxValue - 1;
            if (x > 0 && result[x - 1][y] != 0)
                min = Math.Min(min, result[x - 1][y]);
            if (x < matrix.Length - 1)
                min = Math.Min(min, DFS(matrix, result, x + 1, y));
            if (y > 0 && result[x][y - 1] != 0)
                min = Math.Min(min, result[x][y - 1]);
            if (y < matrix[0].Length - 1)
                min = Math.Min(min, DFS(matrix, result, x, y + 1));
            return min + 1;
        }
    }
}

using System;

namespace SparseMatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A =
            {
                new[] {1, 0, 0},
                new[] {-1, 0, 3},
            };
            int[][] B =
            {
                new[] {7, 0, 0},
                new[] {0, 0, 0},
                new[] {0, 0, 1},
            };
            Console.WriteLine(Multiply(A, B));
        }
        static int[][] Multiply(int[][] A, int[][] B)
        {
            var res = new int[A.Length][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[B[0].Length];
            for (int i = 0; i < B[0].Length; i++)
            {
                for (int c = 0; c < A[0].Length; c++)
                {
                    if (B[c][i] == 0) continue;
                    for (int r = 0; r < A.Length; r++)
                        res[r][i] += A[r][c] * B[c][i];
                }
            }
            return res;
        }
    }
}

using System;

namespace MatrixBlockSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[3][];
            mat[0] = new int[] {1, 2, 3};
            mat[1] = new int[] {4, 5, 6};
            mat[2] = new int[] {7, 8, 9};
            int K = 100;
            Console.WriteLine(MatrixBlockSum(mat, K));
        }
        static int[][] MatrixBlockSum(int[][] mat, int K)
        {
            var res = new int[mat.Length][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[mat[0].Length];
            for (int r = 0; r <= Math.Min(K, mat.Length - 1); r++)
                for (int c = 0; c <= Math.Min(K, mat[0].Length - 1); c++)
                    res[0][0] += mat[r][c];
            for (int r = 1; r < mat.Length; r++)
            {
                res[r][0] = res[r - 1][0];
                if (r - K > 0)
                    for (int c = 0; c <= Math.Min(K, mat[0].Length - 1); c++)
                        res[r][0] -= mat[r - K - 1][c];
                if(r + K < mat.Length)
                    for (int c = 0; c <= Math.Min(K, mat[0].Length - 1); c++)
                        res[r][0] += mat[r + K][c];
            }
            for (int r = 0; r < mat.Length; r++)
            {
                for (int c = 1; c < mat[0].Length; c++)
                {
                    res[r][c] = res[r][c - 1];
                    if(c - K > 0)
                        for (int i = Math.Max(0, r - K); i <= Math.Min(mat.Length - 1, r + K); i++)
                            res[r][c] -= mat[i][c - K - 1];
                    if(c + K < mat[0].Length)
                        for (int i = Math.Max(0, r - K); i <= Math.Min(mat.Length - 1, r + K); i++)
                            res[r][c] += mat[i][c + K];
                }
            }
            return res;
        }
    }
}

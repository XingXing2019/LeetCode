using System;

namespace CountSubmatricesWithAllOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumSubmat(int[][] mat)
        {
            for (int r = mat.Length - 1; r >= 0; r--)
                for (int c = mat[0].Length - 2; c >= 0; c--)
                    mat[r][c] = mat[r][c] == 0 ? 0 : mat[r][c] + mat[r][c + 1];
            var res = 0;
            for (int r = 0; r < mat.Length; r++)
            {
                for (int c = 0; c < mat[0].Length; c++)
                {
                    var min = mat[r][c];
                    res += min;
                    for (int i = r + 1; i < mat.Length; i++)
                    {
                        if (mat[i][c] == 0) break;
                        min = Math.Min(min, mat[i][c]);
                        res += min;
                    }
                }
            }
            return res;
        }
    }
}

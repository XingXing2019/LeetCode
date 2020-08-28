using System;
using System.Linq;

namespace LongestLineOfConsecutiveOneInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] M = new int[][]
            {
                new int[] {1, 1, 0, 0, 1, 0, 0, 1, 1, 0},
                new int[] {1, 0, 0, 1, 0, 1, 1, 1, 1, 1},
                new int[] {1, 1, 1, 0, 0, 1, 1, 1, 1, 0},
                new int[] {0, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                new int[] {0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
                new int[] {1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
                new int[] {0, 1, 1, 1, 1, 1, 1, 0, 0, 1},
                new int[] {1, 1, 1, 1, 1, 0, 0, 1, 1, 1},
                new int[] {0, 1, 0, 1, 1, 0, 1, 1, 1, 1},
                new int[] {1, 1, 1, 0, 1, 0, 1, 1, 1, 1},
            };
            Console.WriteLine(LongestLine(M));
        }
        static int LongestLine(int[][] M)
        {
            if (M.Length == 0 || M[0].Length == 0)
                return 0;
            var dp = new int[M.Length][][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[M[0].Length][];
            dp[0][0] = M[0][0] == 0 ? new int[4] : new[] {1, 1, 1, 0};
            var res = dp[0][0].Max();
            for (int i = 1; i < M.Length; i++)
            {
                dp[i][0] = M[i][0] == 0 ? new int[4] : new[] {dp[i - 1][0][0] + 1, 1, 1, 0};
                res = Math.Max(res, dp[i][0].Max());
            }
            for (int i = 1; i < M[0].Length; i++)
            {
                dp[0][i] = M[0][i] == 0 ? new int[4] : new[] {1, dp[0][i - 1][1] + 1, 1, 0};
                res = Math.Max(res, dp[0][i].Max());
            }
            for (int i = 1; i < M.Length; i++)
            {
                for (int j = 1; j < M[0].Length; j++)
                {
                    dp[i][j] = M[i][j] == 0
                        ? new int[4]
                        : new[] {dp[i - 1][j][0] + 1, dp[i][j - 1][1] + 1, dp[i - 1][j - 1][2] + 1, 0};
                    res = Math.Max(res, dp[i][j].Max());
                }
            }
            for (int i = 0; i < M[0].Length; i++)
                dp[^1][i][3] = M[^1][i] == 0 ? 0 : 1;
            for (int i = M.Length - 2; i >= 0; i--)
            {
                for (int j = 1; j < M[0].Length; j++)
                {
                    dp[i][j][3] = M[i][j] == 0 ? 0 : dp[i + 1][j - 1][3] + 1;
                    res = Math.Max(res, dp[i][j][3]);
                }
            }
            return res;
        }
    }
}

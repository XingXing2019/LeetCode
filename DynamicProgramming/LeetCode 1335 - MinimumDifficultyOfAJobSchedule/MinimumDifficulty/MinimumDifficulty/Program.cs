using System;
using System.Linq;

namespace MinimumDifficulty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] jobDifficulty = { 6, 5, 4, 3, 2, 1 };
            var d = 2;
            Console.WriteLine(MinDifficulty(jobDifficulty, d));
        }

        public static int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d)
                return -1;
            var dp = new int[jobDifficulty.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[d + 1];
                Array.Fill(dp[i], 1000 * jobDifficulty.Length);
            }
            dp[0][0] = 0;
            for (int i = 1; i <= jobDifficulty.Length; i++)
            {
                for (int k = 1; k <= d; k++)
                {
                    var max = 0;
                    for (int j = i - 1; j >= k - 1; j--)
                    {
                        max = Math.Max(max, jobDifficulty[j]);
                        dp[i][k] = Math.Min(dp[i][k], dp[j][k - 1] + max);
                    }
                }
            }
            return dp[^1][^1];
        }
    }
}

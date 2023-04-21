using System;

namespace ProfitableSchemes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[profit.Length + 1][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[n + 1][];
                for (int j = 0; j < dp[i].Length; j++)
                    dp[i][j] = new long[minProfit + 1];
            }
            dp[0][0][0] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    for (int k = 0; k < dp[i][j].Length; k++)
                    {
                        dp[i][j][k] = dp[i - 1][j][k];
                        if (j >= group[i - 1])
                            dp[i][j][k] += dp[i - 1][j - group[i - 1]][Math.Max(0, k - profit[i - 1])];
                        dp[i][j][k] %= mod;
                    }
                }
            }
            long res = 0;
            for (int i = 0; i < dp[^1].Length; i++)
                res += dp[^1][i][minProfit];
            return (int)(res % mod);
        }
    }
}

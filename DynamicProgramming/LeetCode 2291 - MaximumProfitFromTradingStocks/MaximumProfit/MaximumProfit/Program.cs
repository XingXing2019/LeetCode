using System;

namespace MaximumProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] present = { 0, 0, 1, 2 };
            int[] future = { 4, 4, 2, 3};
            var budget = 3;
            Console.WriteLine(MaximumProfit(present, future, budget));
        }

        public static int MaximumProfit(int[] present, int[] future, int budget)
        {
            var dp = new int[present.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[budget + 1];
            var res = 0;
            for (int i = present[0]; i < dp[0].Length; i++)
            {
                dp[0][i] = future[0] - present[0];
                res = Math.Max(res, dp[0][i]);
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    var profit = j - present[i] >= 0 ? dp[i - 1][j - present[i]] + future[i] - present[i] : 0;
                    dp[i][j] = Math.Max(dp[i - 1][j], profit);
                    res = Math.Max(res, dp[i][j]);
                }
            }
            return res;
        }
    }
}

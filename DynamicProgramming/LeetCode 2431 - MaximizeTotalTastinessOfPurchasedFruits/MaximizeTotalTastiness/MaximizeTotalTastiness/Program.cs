using System;

namespace MaximizeTotalTastiness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] price = { 10, 15 };
            int[] tastiness = { 5, 8 };
            int maxAmount = 10, maxCoupons = 2;
            Console.WriteLine(MaxTastiness(price, tastiness, maxAmount, maxCoupons));
        }

        public static int MaxTastiness(int[] price, int[] tastiness, int maxAmount, int maxCoupons)
        {
            var dp = new int[price.Length + 1][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[maxAmount + 1][];
                for (int j = 0; j < dp[i].Length; j++)
                    dp[i][j] = new int[maxCoupons + 1];
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j <= maxAmount; j++)
                {
                    for (int k = 0; k <= maxCoupons; k++)
                    {
                        dp[i][j][k] = dp[i - 1][j][k];
                        if (j >= price[i - 1])
                            dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j - price[i - 1]][k] + tastiness[i - 1]);
                        if (j >= price[i - 1] / 2 && k > 0)
                            dp[i][j][k] = Math.Max(dp[i][j][k], dp[i - 1][j - price[i - 1] / 2][k - 1] + tastiness[i - 1]);
                    }
                }
            }
            return dp[^1][^1][^1];
        }
    }
}

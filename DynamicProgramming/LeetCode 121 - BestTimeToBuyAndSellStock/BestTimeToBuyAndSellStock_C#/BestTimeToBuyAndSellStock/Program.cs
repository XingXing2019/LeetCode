using System;

namespace BestTimeToBuyAndSellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {1, 0, 2, 4, 6 };
            Console.WriteLine(MaxProfit(prices));
        }
        static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }
            return maxProfit;
        }
        static int MaxProfit_RegulateSolution(int[] prices)
        {
            if (prices.Length == 0) return 0;
            var dp = new int[prices.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[2];
            dp[0][0] = 0;
            dp[0][1] = -prices[0];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
                dp[i][1] = Math.Max(dp[i - 1][1], -prices[i]);
            }
            return dp[prices.Length - 1][0];
        }
    }
}

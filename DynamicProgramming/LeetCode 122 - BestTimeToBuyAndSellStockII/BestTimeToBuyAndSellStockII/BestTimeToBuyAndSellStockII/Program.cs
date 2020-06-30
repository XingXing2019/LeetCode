using System;

namespace BestTimeToBuyAndSellStockII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxProfit(int[] prices)
        {
            int totalProfit = 0, minPrice = int.MinValue;
            foreach (var price in prices)
            {
                if (price - minPrice > 0)
                    totalProfit += price - minPrice;
                minPrice = price;
            }
            return totalProfit;
        }

        private static int MaxProfit_RegulateSolution(int[] prices)
        {
            if(prices.Length == 0) return 0;
            var dp = new int[prices.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[2];
            dp[0][0] = 0;
            dp[0][1] = -prices[0];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
            }
            return dp[prices.Length - 1][0];
        }
    }
}

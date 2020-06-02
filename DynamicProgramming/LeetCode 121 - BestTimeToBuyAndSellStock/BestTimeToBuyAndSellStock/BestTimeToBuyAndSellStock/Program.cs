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
    }
}

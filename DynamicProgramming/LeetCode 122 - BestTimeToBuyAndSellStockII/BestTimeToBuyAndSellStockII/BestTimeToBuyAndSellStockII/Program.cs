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
    }
}

using System;
using System.Linq;

namespace BestTimeToBuyAndSellStockIV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 2;
            int[] prices = { 3, 2, 6, 5, 0, 3 };
            Console.WriteLine(MaxProfit(k, prices));
        }

        public static int MaxProfit(int k, int[] prices)
        {
            var n = prices.Length;
            if (n == 0 || k == 0) return 0;
            var sold = new int[n][];
            var hold = new int[n][];
            for (int i = 0; i < n; i++)
            {
                sold[i] = new int[k];
                hold[i] = new int[k];
            }
            for (int j = 0; j < k; j++)
            {
                hold[0][j] = -prices[0];
                for (int i = 1; i < n; i++)
                {
                    sold[i][j] = Math.Max(sold[i - 1][j], hold[i - 1][j] + prices[i]);
                    hold[i][j] = Math.Max(hold[i - 1][j], (j == 0 ? 0 : sold[i - 1][j - 1]) - prices[i]);
                }
            }
            return sold[^1][^1];
        }
    }
}

//因为只能交易两次，所以一定有一个点可以把数组分成两份，两次最佳交易正好在这个点的两边。
//从左往右扫描。找到以每个点为卖出能达到的最大收益。再从右往扫描，找到以每个点为买入能达到的最大收益。
//在遍历一遍找到在哪个点为分割点能达到最大收益。
using System;

namespace BestTimeToBuyAndSellStockIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {  };
            Console.WriteLine(MaxProfit(prices));
        }
        static int MaxProfit(int[] prices)
        {
            if (prices.Length == 0) return 0;
            var leftMax = new int[prices.Length];
            var rightMax = new int[prices.Length];
            int min = prices[0], max = prices[^1], maxProfit = int.MinValue;
            for (int i = 1; i < leftMax.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                leftMax[i] = Math.Max(leftMax[i - 1], prices[i] - min);
            }
            for (int i = rightMax.Length - 2; i >= 0; i--)
            {
                max = Math.Max(max, prices[i]);
                rightMax[i] = Math.Max(rightMax[i + 1], max - prices[i]);
            }
            for (int i = 0; i < leftMax.Length; i++)
                maxProfit = Math.Max(maxProfit, leftMax[i] + rightMax[i]);
            return maxProfit;
        }
    }
}

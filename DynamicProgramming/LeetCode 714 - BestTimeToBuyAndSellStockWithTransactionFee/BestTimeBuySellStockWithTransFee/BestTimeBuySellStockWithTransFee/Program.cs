//采用动态规划思想。利用持有或不持有股票来记录当前的最大收益。
//创建have数组，have[i]表示第i天持有股票情况下的最大收益。那么有两种情况，第一种为第i-1天就持有股票，第二种情况为第i天买入了股票。
//将have[0]设为-prices[0]，因为第一天如果持有股票，那么收益一定是当天估价的负值(相当于借钱买了股票)
//创建dontHave数组，dontHave[i]表示第i天不持有股票情况下的最大收益。那么也有两种情况，第一种为第i-1天就不持有股票，第二种情况为第i天卖出了股票。
//将dontHave[0]设为0，因为第一天如果不持有股票，那么收益一定是0。
//从第二天开始遍历数组，当前天持有股票情况下的最大收益为，上述对应两种情况之中的最大值。
//同理当前天不持有股票情况下的最大收益为，上述对应两种情况之中的最大值。
//最后只需返回最后一天不持有股票的最大收益即可。
using System;

namespace BestTimeBuySellStockWithTransFee
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 3, 2, 8, 4, 9 };
            int fee = 2;
            Console.WriteLine(MaxProfit(prices, fee));
        }
        static int MaxProfit(int[] prices, int fee)
        {
            int[] have = new int[prices.Length];
            int[] dontHave = new int[prices.Length];
            have[0] = -prices[0];
            dontHave[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                have[i] = Math.Max(have[i - 1], dontHave[i - 1] - prices[i]);
                dontHave[i] = Math.Max(dontHave[i - 1], have[i - 1] + prices[i] - fee);
            }
            return dontHave[dontHave.Length - 1];
        }
        
    }
}

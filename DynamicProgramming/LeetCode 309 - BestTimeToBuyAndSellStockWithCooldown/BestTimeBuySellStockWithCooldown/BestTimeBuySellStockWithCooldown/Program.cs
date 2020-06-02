//本题思路为动态规划，要注意找好状态转移方程。创建have和dontHave数组，长度和prices相同。
//have[0]设为-prices[0](代表在第一天持有股票则收益为负)，dontHave[0]设为0，代表在第一天没有持有股票则收益为0。
//对于每一天有两种状态，第一种为持有股票，第二种为没有持有股票。从第二天开始遍历数组。
//在没有持有股票的情况，有两种可能。第一种可能为前一天就没有持有，则该状态下的最大收益与前一天没有持有股票的最大收益相关dontHave[i - 1]。
//第二种可能为前一天持有股票，但今天卖出了。则该状态下的最大收益与前一天持有股票的最大收益与今天的股价相关have[i - 1] + price[i]。
//综上，在某一天没有持有股票的状态下的最大收益为上述两种状态中较大的值。
//对于持有股票的情况，有两种可能，第一种为前一天就持有股票，则该状态下的最大收益与前一天持有股票的最大收益相关have[i - 1]。
//第二种可能为原来没有股票但今天买入了，因为有cooldown的存在，则前一天不能卖出。dontHave[i - 1]只能证明前一天没有持有，只有dontHave[i - 2]才能证明前一天没有卖出。
//则该状态下的最大收益与前两天没有持有股票的最大收益和当天股价相关dontHave[i - 2] - prices[i]。需要注意不要越界，i如果小于2则取0。
//综上，在某一天持有股票的状态下的最大收益为上述两种可能中较大的值。
//最后返回在最后一天不持有股票的值。
using System;

namespace BestTimeBuySellStockWithCooldown
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 2, 3, 0, 2 };
            Console.WriteLine(MaxProfit(prices));
        }
        static int MaxProfit(int[] prices)
        {
            if(prices.Length == 0)
                return 0;
            int[] have = new int[prices.Length];
            int[] dontHave = new int[prices.Length];
            have[0] = -prices[0];
            dontHave[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                have[i] = Math.Max(have[i - 1], -prices[i] + (i >= 2 ? dontHave[i - 2] : 0));
                dontHave[i] = Math.Max(dontHave[i - 1], have[i - 1] + prices[i]);
            }
            return dontHave[dontHave.Length - 1];
        }
        static int MaxProfits(int[] prices)
        {
            if (prices.Length == 0)
                return 0;
            int[] have = new int[prices.Length];
            int[] dontHave = new int[prices.Length];
            have[0] = -prices[0];
            dontHave[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                have[i] = Math.Max(have[i - 1], -prices[i] + (i >= 2 ? dontHave[i - 2] : 0));
                dontHave[i] = Math.Max(dontHave[i - 1], have[i - 1] + prices[i]);
            }
            return dontHave[dontHave.Length - 1];
        }
    }
}

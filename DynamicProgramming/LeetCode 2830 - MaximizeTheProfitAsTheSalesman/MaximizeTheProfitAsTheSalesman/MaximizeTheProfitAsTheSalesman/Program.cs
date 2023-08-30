using System;
using System.Collections.Generic;

namespace MaximizeTheProfitAsTheSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximizeTheProfit(int n, IList<IList<int>> offers)
        {
            var dp = new int[n];
            offers = offers.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();
            var res = 0;
            foreach (var offer in offers)
            {
                int start = offer[0], end = offer[1], gold = offer[2], max = 0;
                for (int i = start - 1; i >= 0; i--)
                    max = Math.Max(max, dp[i]);
                dp[end] = Math.Max(dp[end], max + gold);
                res = Math.Max(res, dp[end]);
            }
            return res;
        }
    }
}

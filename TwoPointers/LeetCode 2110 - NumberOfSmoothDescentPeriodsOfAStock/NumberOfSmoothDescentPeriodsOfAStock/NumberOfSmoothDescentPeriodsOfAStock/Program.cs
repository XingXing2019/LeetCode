using System;

namespace NumberOfSmoothDescentPeriodsOfAStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 3, 2, 1, 4 };
            Console.WriteLine(GetDescentPeriods(prices));
        }

        public static long GetDescentPeriods(int[] prices)
        {
            long res = 0, li = 0, hi = 1;
            while (hi < prices.Length)
            {
                if (prices[hi - 1] - prices[hi] != 1)
                {
                    res += (hi - li + 1) * (hi - li) / 2;
                    li = hi;
                }
                hi++;
            }
            return res + (hi - li + 1) * (hi - li) / 2;
        }
    }
}

using System;

namespace MinimumPenaltyForAShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = "YNYY";
            Console.WriteLine(BestClosingTime(customers));
        }

        public static int BestClosingTime(string customers)
        {
            var open = new int[customers.Length + 1];
            var close = new int[customers.Length + 1];
            int openPenalty = 0, closePenalty = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                open[i] = openPenalty;
                openPenalty += customers[i] == 'N' ? 1 : 0;
                closePenalty += customers[^(i + 1)] == 'Y' ? 1 : 0;
                close[^(i + 2)] = closePenalty;
            }
            open[^1] = openPenalty;
            int res = 0, min = int.MaxValue;
            for (int i = 0; i <= customers.Length; i++)
            {
                if (open[i] + close[i] >= min) continue;
                res = i;
                min = open[i] + close[i];
            }
            return res;
        }
    }
}

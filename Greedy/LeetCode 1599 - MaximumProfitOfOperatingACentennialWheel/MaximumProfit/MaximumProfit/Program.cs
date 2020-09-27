using System;
using System.Collections.Generic;

namespace MaximumProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] customers = { 10, 10, 6, 4, 7 };
            int boardingCost = 1, runningCost = 92;
            Console.WriteLine(MinOperationsMaxProfit(customers, boardingCost, runningCost));
        }
        static int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
        {
            int max = 0, profit = 0, left = 0, res = 0;
            var groups = new List<int>();
            foreach (var customer in customers)
            {
                int num = Math.Min(customer + left, 4);
                groups.Add(num);
                left = Math.Max(0, customer + left - 4);
            }
            while (left - 4 > 0)
            {
                groups.Add(4);
                left -= 4;
            }
            groups.Add(left);
            for (int i = 0; i < groups.Count; i++)
            {
                profit += groups[i] * boardingCost - runningCost;
                if (profit <= max) continue;
                max = profit;
                res = i + 1;
            }
            return max == 0 ? -1 : res;
        }
    }
}

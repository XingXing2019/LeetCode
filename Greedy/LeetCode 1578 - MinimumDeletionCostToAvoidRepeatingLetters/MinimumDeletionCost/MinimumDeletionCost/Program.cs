using System;
using System.Linq;

namespace MinimumDeletionCost
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "abc";
            int[] cost = { 1, 2, 3};
            Console.WriteLine(MinCost(s, cost));
        }
        static int MinCost(string s, int[] cost)
        {
            int maxTotalCost = 0, maxCost = cost[0], totalDeleteCost = 0;
            int countSame = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    countSame++;
                    maxCost = Math.Max(maxCost, cost[i]);
                    totalDeleteCost += cost[i];
                    if (countSame == 2)
                        totalDeleteCost += cost[i - 1];
                }
                else
                {
                    if (countSame > 1)
                        maxTotalCost += maxCost;
                    maxCost = cost[i];
                    countSame = 1;
                }
            }
            if (countSame > 1)
                maxTotalCost += maxCost;
            return totalDeleteCost - maxTotalCost;
        }
    }
}

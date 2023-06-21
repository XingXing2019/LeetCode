using System;
using System.Linq;

namespace MinimumCostToMakeArrayEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 2 };
            int[] cost = { 2, 3, 1, 14 };
            Console.WriteLine(MinCost(nums, cost));
        }

        public static long MinCost(int[] nums, int[] cost)
        {
            var n = nums.Length;
            var paris = new long[n][];
            for (int i = 0; i < n; i++)
                paris[i] = new long[] { nums[i], cost[i] };
            paris = paris.OrderBy(x => x[0]).ToArray();
            long[] costL = new long[n], costR = new long[n];
            long costSumL = 0, costSumR = 0;
            for (int i = 0; i < n; i++)
            {
                costL[i] = i == 0 ? 0 : costL[i - 1] + costSumL * (paris[i][0] - paris[i- 1][0]);
                costSumL += paris[i][1];
                costR[^(i + 1)] = i == 0 ? 0 : costR[^i] + costSumR * (paris[^i][0] - paris[^(i + 1)][0]);
                costSumR += paris[^(i + 1)][1];
            }
            long res = long.MaxValue;
            for (int i = 0; i < n; i++)
                res = Math.Min(res, costL[i] + costR[i]);
            return res;
        }
    }
}

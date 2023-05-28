using System;
using System.Collections.Generic;

namespace MinimumCostToCutAStick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 7;
            int[] cuts = { 1 };
            Console.WriteLine(MinCost(n, cuts));
        }

        public static int MinCost(int n, int[] cuts)
        {
            var newCuts = new int[cuts.Length + 2];
            for (int i = 0; i < cuts.Length; i++)
                newCuts[i] = cuts[i];
            newCuts[^1] = 0;
            newCuts[^2] = n;
            Array.Sort(newCuts);
            var dp = new int[newCuts.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[newCuts.Length];
            return DFS(newCuts, 0, newCuts.Length - 1, dp);
        }

        public static int DFS(int[] cuts, int li, int hi, int[][] dp)
        {
            if (cuts[hi] - cuts[li] <= 1)
                return 0;
            if (dp[li][hi] != 0)
                return dp[li][hi];
            int min = int.MaxValue, len = cuts[hi] - cuts[li];
            for (int i = li + 1; i < hi; i++)
            {
                var cost = DFS(cuts, li, i, dp) + DFS(cuts, i, hi, dp);
                min = Math.Min(min, cost);
            }
            return dp[li][hi] = min == int.MaxValue ? 0 : min + len;
        }
    }
}

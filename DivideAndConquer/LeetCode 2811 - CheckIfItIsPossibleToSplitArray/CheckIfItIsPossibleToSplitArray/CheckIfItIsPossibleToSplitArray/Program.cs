using System;
using System.Collections.Generic;

namespace CheckIfItIsPossibleToSplitArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 2, 1, 3 };
            var m = 5;
            Console.WriteLine(CanSplitArray(nums, m));
        }

        public static bool CanSplitArray(IList<int> nums, int m)
        {
            if (nums.Count <= 2)
                return true;
            var dp = new int[nums.Count][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[nums.Count];
            return DFS(nums, m, 0, nums.Count - 1, dp) == 1;
        }

        public static int DFS(IList<int> nums, int m, int li, int hi, int[][] dp)
        {
            if (dp[li][hi] != 0)
                return dp[li][hi];
            if (hi - li + 1 == 1)
                return dp[li][hi] = 1;
            var sum = 0;
            for (int i = li; i <= hi; i++)
                sum += nums[i];
            if (sum < m)
                return dp[li][hi] = -1;
            for (int i = li; i < hi; i++)
            {
                if (DFS(nums, m, li, i, dp) == 1 && DFS(nums, m, i + 1, hi, dp) == 1)
                    return dp[li][hi] = 1;
            }
            return dp[li][hi] = -1;
        }
    }
}

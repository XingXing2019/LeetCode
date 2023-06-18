using System;
using System.Collections.Generic;

namespace SpecialPermutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192 };
            Console.WriteLine(SpecialPerm(nums));
        }

        public static int SpecialPerm(int[] nums)
        {
            var dp = new Dictionary<int, long>[1 << nums.Length];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new Dictionary<int, long>();
            var res = DFS(nums, 0, -1, dp);
            return (int)res;
        }

        public static long DFS(int[] nums, int state, int last, Dictionary<int, long>[] dp)
        {
            if (dp[state].ContainsKey(last))
                return dp[state][last];
            if (state == (1 << nums.Length) - 1)
                return 1;
            long res = 0, mod = 1_000_000_000 + 7;
            for (int i = 0; i < nums.Length; i++)
            {
                if (((state >> i) & 1) == 1) 
                    continue;
                if (last != -1 && nums[i] % last != 0 && last % nums[i] != 0)
                    continue;
                res = (res + DFS(nums, state | (1 << i), nums[i], dp)) % mod;
            }
            return dp[state][last] = res;
        }
    }
}

//利用动态数组dp记录以当前数字结尾的子数组中最长的set是什么。初始条件设为dp[0]就是包含nums[0]的一个列表。
//将数组排序后，开始动态规划。对于dp[i]，应该找到他前面set中，nums[i]能整除nums[j]的最长set，再将当前的nums[i]添加进去.
//同时记录一下最长的set和他的位置。最后返回dp中那个最长的set。
using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestDivisibleSubset
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 9, 18, 54, 108, 540, 90, 180, 360, 720 };
            Console.WriteLine(LargestDivisibleSubset(nums));
        }
        static IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums.Length == 0) return new List<int>();
            Array.Sort(nums);
            var dp = new List<int>[nums.Length];
            dp[0] = new List<int> {nums[0]};
            int max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                int longest = 0, index = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] != 0 || dp[j].Count + 1 <= longest) continue;
                    index = j;
                    longest = dp[j].Count + 1;
                }
                dp[i] = new List<int> {nums[i]};
                if(index != -1) dp[i].AddRange(dp[index]);
                max = Math.Max(max, dp[i].Count);
            }
            return dp.First(x => x.Count == max);
        }
    }
}

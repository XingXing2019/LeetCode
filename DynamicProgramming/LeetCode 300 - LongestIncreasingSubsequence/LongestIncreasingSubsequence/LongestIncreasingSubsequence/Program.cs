//创建动态数组dp，dp[i]代表以nums[i]为结尾的数组能组成的最长升序数组的长度。将第一个元素初始化为1，因为以第一个数字为结尾的数组最大长度为1。创建res记录结果。
//从第二个元素开始遍历。对于nums中的每一个数字，遍历他之前的数字，试图找到以比他小的数字为结尾的数组能达到的最大长度。那么就应该把当前数字加到那个数字后面形成更长的数组。
//找到后，将dp[i]设为已找到那个数字结尾数组长度加一。并将res更新为当前res和dp[i]中较大的数字。
using System;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            Console.WriteLine(LengthOfLIS(nums));
        }
        static int LengthOfLIS(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int res = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                    if (nums[i] > nums[j])
                        max = Math.Max(max, dp[j]);
                dp[i] = max + 1;
                res = Math.Max(dp[i], res);
            }
            return res;
        }
    }
}

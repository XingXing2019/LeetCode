//创建动态数组dp，dp[i]代表删除或者不删除这个数字能获得的最大收益。
//dp长度设为nums中的最大值加一，代表从0到最大值这些数字一次讨论删除或者不删除的情况。
//因为nums中没有0，则无需更改dp[0]，dp[1]设为nums中1的个数。另外创建record数组记录nums中每个数字的个数。
//从2开始遍历dp，则dp[i]等于dp[i-1](删除当前数字)和dp[i-2]+i*record[i](不删除当前数字)中较大的值。
using System;
using System.Linq;

namespace DeleteAndEarn
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3,5 };
            Console.WriteLine(DeleteAndEarn(nums));
        }
        static int DeleteAndEarn(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int max = nums.Max(n => n);
            int[] dp = new int[max + 1];
            int[] record = new int[max + 1];
            foreach (var n in nums)
                record[n]++;
            dp[1] = nums.Count(n => n == 1);
            for (int i = 2; i < dp.Length; i++)
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + i * record[i]);
            return dp[max];
        }
    }
}

//创建dp布尔数组，dp[i]记录是否有一组数字之和为i。dp[0]设为true。
//遍历每个数字n。然后倒着遍历dp到n。将dp[i]设为dp[i]或dp[i-n]。
//如果dp[i]为true，而且i为数组总和的一半，则返回true。否则遍历结束后返回false。
using System;
using System.Linq;

namespace PartitionEqualSubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 14, 9, 8, 4, 3, 2 };
            Console.WriteLine(CanPartition(nums));
        }
        static bool CanPartition(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 != 0) return false;
            var target = sum / 2;
            var dp = new bool[target + 1];
            dp[0] = true;
            foreach (var num in nums)
            {
                for (int i = target; i >= num; i--)
                {
                    dp[i] = dp[i] || dp[i - num];
                    if (dp[i] && i == target) return true;
                }
            }
            return false;
        }
    }
}

//用字典当代替动态数组。key为数字，value为以该数字结尾符合条件数组的长度。
//遍历arr，如果num-difference在字典中，则将dp[num]设为dp[num-difference] + 1。否则dp[num]设为1.
//最后返回地点中的最大value.
using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestArithmeticSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 5, 7, 8, 5, 3, 4, 2, 1};
            int different = -2;
            Console.WriteLine(LongestSubsequence(arr, different));
        }
        static int LongestSubsequence(int[] arr, int difference)
        {
            var dp = new Dictionary<int, int>();
            foreach (var num in arr)
                dp[num] = dp.ContainsKey(num - difference) ? dp[num - difference] + 1 : 1;
            return dp.Max(x => x.Value);
        }
    }
}

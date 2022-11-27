using System;
using System.Collections.Generic;

namespace ArithmeticSlicesIISubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 2000000000, -294967296 };
            Console.WriteLine(NumberOfArithmeticSlices(nums));
        }

        public static int NumberOfArithmeticSlices(int[] nums)
        {
            var dp = new Dictionary<long, long>[nums.Length];
            long res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = new Dictionary<long, long>();
                for (int j = 0; j < i; j++)
                {
                    var diff = (long)nums[i] - nums[j];
                    var sum = dp[j].GetValueOrDefault(diff, 0L);
                    var origin = dp[i].GetValueOrDefault(diff, 0L);
                    dp[i][diff] = sum + origin + 1;
                    res += sum;
                }
            }
            return (int)res;
        }
    }
}

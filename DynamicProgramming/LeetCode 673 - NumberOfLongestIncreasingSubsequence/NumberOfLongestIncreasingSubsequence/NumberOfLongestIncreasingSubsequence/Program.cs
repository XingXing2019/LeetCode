using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfLongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2 };
            Console.WriteLine(FindNumberOfLIS(nums));
        }

        public static int FindNumberOfLIS(int[] nums)
        {
            var lenDp = new int[nums.Length];
            var countDp = new int[nums.Length];
            lenDp[0] = countDp[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] <= nums[j]) continue;
                    if (lenDp[j] + 1 > lenDp[i])
                    {
                        lenDp[i] = lenDp[j] + 1;
                        countDp[i] = countDp[j];
                    } 
                    else if (lenDp[j] + 1 == lenDp[i])
                        countDp[i] += countDp[j];
                }
            }
            int max = lenDp.Max(), res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (lenDp[i] == max)
                    res += countDp[i];
            }
            return res;
        }
    }
}

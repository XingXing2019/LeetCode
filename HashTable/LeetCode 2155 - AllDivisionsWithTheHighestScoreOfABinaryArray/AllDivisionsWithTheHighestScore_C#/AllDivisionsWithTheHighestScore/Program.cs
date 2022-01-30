using System;
using System.Collections.Generic;

namespace AllDivisionsWithTheHighestScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 0, 1, 0 };
            Console.WriteLine(MaxScoreIndices(nums));
        }

        public static IList<int> MaxScoreIndices(int[] nums)
        {
            var left = new int[nums.Length + 1];
            var right = new int[nums.Length + 1];
            int zero = 0, one = 0;
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = zero;
                if (i < nums.Length && nums[i] == 0) zero++;
                right[^(i + 1)] = one;
                if (nums.Length - i - 1 >= 0 && nums[^(i + 1)] == 1) one++;
            }
            var dict = new Dictionary<int, List<int>>();
            var max = 0;
            for (int i = 0; i < left.Length; i++)
            {
                var sum = left[i] + right[i];
                if (!dict.ContainsKey(sum))
                    dict[sum] = new List<int>();
                dict[sum].Add(i);
                max = Math.Max(max, sum);
            }
            return dict[max];
        }
    }
}

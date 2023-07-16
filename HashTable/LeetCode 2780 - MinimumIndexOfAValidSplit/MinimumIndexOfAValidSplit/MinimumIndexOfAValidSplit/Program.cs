using System;
using System.Collections.Generic;

namespace MinimumIndexOfAValidSplit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2, 2 };
            Console.WriteLine(MinimumIndex(nums));
        }

        public static int MinimumIndex(IList<int> nums)
        {
            int dominant = 0, max = 0, count = 0;
            var freq = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!freq.ContainsKey(num))
                    freq[num] = 0;
                freq[num]++;
                if (freq[num] <= max) continue;
                max = freq[num];
                dominant = num;
            }
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == dominant)
                    count++;
                if (count * 2 > i + 1 && (freq[dominant] - count) * 2 > nums.Count - i - 1)
                    return i;
            }
            return -1;
        }
    }
}

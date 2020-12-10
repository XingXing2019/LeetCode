using System;
using System.Collections.Generic;

namespace MissingRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            var res = new List<string>();
            if (nums.Length == 0)
            {
                res.Add(lower == upper ? $"{lower}" : $"{lower}->{upper}");
                return res;
            }
            if (lower == upper) return res;
            if (nums[0] > lower)
                res.Add(nums[0] - lower == 1 ? $"{nums[0] - 1}" : $"{lower}->{nums[0] - 1}");
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1) continue;
                res.Add(nums[i] - nums[i - 1] == 2 ? $"{nums[i] - 1}" : $"{nums[i - 1] + 1}->{nums[i] - 1}");
            }
            lower = nums[^1];
            if (lower != upper)
                res.Add(upper - nums[^1] <= 1 ? $"{upper}" : $"{nums[^1] + 1}->{upper}");
            return res;
        }
    }
}

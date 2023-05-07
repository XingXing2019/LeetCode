using System;
using System.Collections.Generic;

namespace FindTheDistinctDifferenceArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] DistinctDifferenceArray(int[] nums)
        {
            var prefix = new HashSet<int>();
            var suffix = new HashSet<int>();
            var left = new int[nums.Length];
            var right = new int[nums.Length];
            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                prefix.Add(nums[i]);
                left[i] = prefix.Count;
                right[^(i + 1)] = suffix.Count;
                suffix.Add(nums[^(i + 1)]);
            }
            for (int i = 0; i < res.Length; i++)
                res[i] = left[i] - right[i];
            return res;
        }
    }
}

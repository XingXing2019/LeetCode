using System;
using System.Collections.Generic;
using System.Globalization;

namespace MostFrequentNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 555, 2, 555, 3, 555, 2 };
            int key = 555;
            Console.WriteLine(MostFrequent(nums, key));
        }

        public static int MostFrequent(int[] nums, int key)
        {
            var dict = new Dictionary<int, int>();
            int max = 0, res = -1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != key) continue;
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = 0;
                dict[nums[i]]++;
                if (dict[nums[i]] > max)
                {
                    max = dict[nums[i]];
                    res = nums[i];
                }
            }
            return res;
        }
    }
}

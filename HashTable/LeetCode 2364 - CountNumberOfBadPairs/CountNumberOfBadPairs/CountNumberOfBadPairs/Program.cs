using System;
using System.Collections.Generic;

namespace CountNumberOfBadPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long CountBadPairs(int[] nums)
        {
            long res = 0, total = 0;
            var freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var diff = nums[i] - i;
                total++;
                freq[diff] = freq.GetValueOrDefault(diff, 0) + 1;
                res += total - freq[diff];
            }
            return res;
        }
    }
}

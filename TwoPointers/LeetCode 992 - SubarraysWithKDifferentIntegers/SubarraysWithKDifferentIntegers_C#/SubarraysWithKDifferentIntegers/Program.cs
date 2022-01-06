using System;
using System.Collections.Generic;

namespace SubarraysWithKDifferentIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            return CountLess(nums, k) - CountLess(nums, k - 1);
        }

        public int CountLess(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            int li = 0, hi = 0, res = 0;
            while (hi < nums.Length)
            {
                if (!dict.ContainsKey(nums[hi]))
                    dict[nums[hi]] = 0;
                dict[nums[hi++]]++;
                while (li < hi && dict.Count > k)
                {
                    dict[nums[li]]--;
                    if (dict[nums[li]] == 0)
                        dict.Remove(nums[li]);
                    li++;
                }
                res += hi - li + 1;
            }
            return res;
        }
    }
}

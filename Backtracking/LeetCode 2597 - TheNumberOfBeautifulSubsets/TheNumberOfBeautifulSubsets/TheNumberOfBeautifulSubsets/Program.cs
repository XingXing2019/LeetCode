using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNumberOfBeautifulSubsets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 6 };
            int k = 2;
            Console.WriteLine(BeautifulSubsets(nums, k));
        }

        public static int BeautifulSubsets(int[] nums, int k)
        {
            var res = 0;
            var freq = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                freq[num] = 0;
                freq[num - k] = 0;
                freq[num + k] = 0;
            }
            DFS(nums, 0, 0, k, freq, ref res);
            return res;
        }

        public static void DFS(int[] nums, int start, int count, int k, Dictionary<int, int> freq, ref int res)
        {
            if (count != 0)
                res++;
            for (int i = start; i < nums.Length; i++)
            {
                if (freq[nums[i] - k] != 0 || freq[nums[i] + k] != 0) continue;
                freq[nums[i]]++;
                DFS(nums, i + 1, count + 1, k, freq, ref res);
                freq[nums[i]]--;
            }
        }
    }
}

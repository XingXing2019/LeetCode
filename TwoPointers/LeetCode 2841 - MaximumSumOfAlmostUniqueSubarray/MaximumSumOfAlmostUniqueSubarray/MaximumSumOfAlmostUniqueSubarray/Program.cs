using System;
using System.Collections.Generic;

namespace MaximumSumOfAlmostUniqueSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 2, 6, 7, 3, 1, 7 };
            int m = 3, k = 4;
            Console.WriteLine(MaxSum(nums, m, k));
        }

        public static long MaxSum(IList<int> nums, int m, int k)
        {
            var index = 0;
            long res = 0, sum = 0;
            var freq = new Dictionary<int, int>();
            for (int i = 0; i < k; i++)
            {
                if (!freq.ContainsKey(nums[index]))
                    freq[nums[index]] = 0;
                freq[nums[index]]++;
                sum += nums[index++];
            }
            if (freq.Count >= m)
                res = sum;
            while (index < nums.Count)
            {
                var front = nums[index - k];
                var after = nums[index];
                freq[front]--;
                if (freq[front] == 0)
                    freq.Remove(front);
                if (!freq.ContainsKey(after))
                    freq[after] = 0;
                freq[after]++;
                sum = sum - front + after;
                if (freq.Count >= m)
                    res = Math.Max(res, sum);
                index++;
            }
            return res;
        }
    }
}

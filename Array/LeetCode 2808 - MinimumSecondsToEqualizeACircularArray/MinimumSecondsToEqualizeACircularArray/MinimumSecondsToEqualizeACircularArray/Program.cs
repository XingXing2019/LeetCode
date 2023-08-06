using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumSecondsToEqualizeACircularArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 1, 3, 3, 2 };
            Console.WriteLine(MinimumSeconds(nums));
        }

        public static int MinimumSeconds(IList<int> nums)
        {
            var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var max = dict.Max(x => x.Value);
            var keys = dict.Where(x => x.Value == max).Select(x => x.Key).ToList();
            var res = int.MaxValue;
            foreach (var key in keys)
                res = Math.Min(res, GetSeconds(nums, key));
            return res;
        }

        public static int GetSeconds(IList<int> nums, int key)
        {
            int first = -1, last = -1, res = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == key && first == -1)
                    first = i;
                if (nums[^(i + 1)] == key && last == -1)
                    last = nums.Count - i - 1;
            }
            int[] prev = new int[nums.Count], post = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == key)
                    last = i;
                else
                    prev[i] = last > i ? nums.Count - last + i : i - last;
            }
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if (nums[i] == key)
                    first = i;
                else
                    post[i] = first < i ? first + nums.Count - i : first - i;
            }
            for (int i = 0; i < nums.Count; i++)
                res = Math.Max(res, Math.Min(prev[i], post[i]));
            return res;
        }
    }
}

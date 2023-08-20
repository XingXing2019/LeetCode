using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheLongestEqualSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 6, 4, 7, 6, 4, 8, 6, 6 };
            var k = 1;
            Console.WriteLine(LongestEqualSubarray(nums, k));
        }

        public static int LongestEqualSubarray(IList<int> nums, int k)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = new List<int>();
                dict[nums[i]].Add(i);
            }
            return dict.Max(x => GetMaxLen(x.Value, k));
        }

        public static int GetMaxLen(List<int> indexes, int k)
        {
            int li = 0, hi = 0, res = 0, len = 0;
            while (hi < indexes.Count)
            {
                len += hi == li ? 0 : indexes[hi] - indexes[hi - 1] - 1;
                while (li < hi && len > k)
                {
                    li++;
                    len -= indexes[li] - indexes[li - 1] - 1;
                }
                res = Math.Max(res, hi - li + 1);
                hi++;
            }
            return res;
        }
    }
}

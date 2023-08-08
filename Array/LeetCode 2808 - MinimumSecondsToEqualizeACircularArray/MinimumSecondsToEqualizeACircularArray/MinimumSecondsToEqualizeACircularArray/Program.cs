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
            var maxDis = new Dictionary<int, int>();
            var firstIndexes = new Dictionary<int, int>();
            var lastIndexes = new Dictionary<int, int>();
            var res = int.MaxValue;
            for (int i = 0; i < nums.Count; i++)
            {
                if (lastIndexes.ContainsKey(nums[i]))
                    maxDis[nums[i]] = Math.Max(i - lastIndexes[nums[i]], maxDis.GetValueOrDefault(nums[i], 0));
                if (!firstIndexes.ContainsKey(nums[i]))
                    firstIndexes[nums[i]] = i;
                lastIndexes[nums[i]] = i;
            }
            foreach (var num in firstIndexes.Keys)
            {
                var inner = maxDis.ContainsKey(num) ? maxDis[num] / 2 : 0;
                var outer = (nums.Count - lastIndexes[num] + firstIndexes[num]) / 2;
                res = Math.Min(res, Math.Max(inner, outer));
            }
            return res;
        }
    }
}

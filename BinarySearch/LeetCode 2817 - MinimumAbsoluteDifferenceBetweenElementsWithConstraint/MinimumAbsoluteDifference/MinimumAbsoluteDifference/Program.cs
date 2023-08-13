using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumAbsoluteDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 3, 2, 4 };
            var x = 2;
            Console.WriteLine(MinAbsoluteDifference(nums, x));
        }

        public static int MinAbsoluteDifference(IList<int> nums, int x)
        {
            var list = new List<int>();
            var set = new HashSet<int>();
            var res = int.MaxValue;
            for (int i = 0; i < nums.Count; i++)
            {
                if (i - x < 0) continue;
                if (set.Add(nums[i - x]))
                {
                    var pos = list.BinarySearch(nums[i - x]);
                    if (pos < 0) pos = ~pos;
                    list.Insert(pos, nums[i - x]);
                }
                var index = list.BinarySearch(nums[i]);
                if (index < 0)
                    index = ~index;
                if (index == 0)
                    res = Math.Min(res, list[index] - nums[i]);
                else if (index == list.Count)
                    res = Math.Min(res, nums[i] - list[index - 1]);
                else
                    res = Math.Min(res, Math.Min(nums[i] - list[index - 1], list[index] - nums[i]));
            }
            return res;
        }
    }
}

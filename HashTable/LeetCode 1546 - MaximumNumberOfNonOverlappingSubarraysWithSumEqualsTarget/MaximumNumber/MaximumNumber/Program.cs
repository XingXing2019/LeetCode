using System;
using System.Collections.Generic;

namespace MaximumNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 1, 1 };
            var target = 2;
            Console.WriteLine(MaxNonOverlapping(nums, target));
        }

        public static int MaxNonOverlapping(int[] nums, int target)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            var dict = new Dictionary<int, int> { { 0, -1 } };
            var index = new List<int>();
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i] - target;
                if (dict.ContainsKey(num) && (index.Count == 0 || dict[num] >= index[^1]))
                {
                    res++;
                    index.Add(i);
                }
                dict[nums[i]] = i;
            }
            return res;
        }
    }
}

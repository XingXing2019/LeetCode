using System;
using System.Collections.Generic;

namespace ReplaceElementsInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] ArrayChange(int[] nums, int[][] operations)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = new List<int>();
                dict[nums[i]].Add(i);
            }
            foreach (var o in operations)
            {
                var index = dict[o[0]];
                if (!dict.ContainsKey(o[1]))
                    dict[o[1]] = new List<int>();
                dict[o[1]].AddRange(index);
                dict.Remove(o[0]);
            }
            foreach (var num in dict.Keys)
            {
                foreach (var index in dict[num])
                    nums[index] = num;
            }
            return nums;
        }
    }
}

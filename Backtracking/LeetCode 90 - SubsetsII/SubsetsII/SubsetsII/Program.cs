using System;
using System.Collections.Generic;

namespace SubsetsII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2 };
            Console.WriteLine(SubsetsWithDup(nums));
        }
        static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> res = new List<IList<int>>();
            List<int> item = new List<int>();
            Generate(0, nums, item, res);
            return res;
        }
        static void Generate(int start, int[] nums, List<int> item, List<IList<int>> res)
        {
            res.Add(new List<int>(item));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;
                item.Add(nums[i]);
                Generate(i + 1, nums, item, res);
                item.Remove(nums[i]);
            }
        }
    }
}

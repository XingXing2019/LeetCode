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
            var res = new List<IList<int>>();
            DFS(nums, 0, new List<int>(), res);
            return res;
        }

        static void DFS(int[] nums, int start, List<int> item, List<IList<int>> res)
        {
            res.Add(new List<int>(item));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                item.Add(nums[i]);
                DFS(nums, i + 1, item, res);
                item.RemoveAt(item.Count - 1);
            }
        }
    }
}

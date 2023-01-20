using System;
using System.Collections.Generic;

namespace IncreasingSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 6, 7, 7 };
            Console.WriteLine(FindSubsequences(nums));
        }

        static IList<IList<int>> FindSubsequences(int[] nums)
        {
            var res = new List<IList<int>>();
            DFS(nums, 0, new HashSet<string>(), new List<int>(), res);
            return res;
        }

        static void DFS(int[] nums, int index, HashSet<string> has, List<int> item, List<IList<int>> res)
        {
            if (item.Count >= 2)
            {
                var str = string.Join(":", item);
                if (has.Add(str))
                    res.Add(new List<int>(item));
            }
            for (int i = index; i < nums.Length; i++)
            {
                if (item.Count != 0 && nums[i] < item[^1]) continue;
                item.Add(nums[i]);
                DFS(nums, i + 1, has, item, res);
                item.RemoveAt(item.Count - 1);
            }
        }
    }
}

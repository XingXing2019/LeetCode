using System;
using System.Collections.Generic;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            Subsets(nums);
        }
        static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            List<int> item = new List<int>();
            res.Add(item);
            generate(0, nums, item, res);
            return res;
        }
        static void generate(int i, int[] nums, List<int> item, List<IList<int>> res)
        {
            if (i >= nums.Length)
                return;
            item.Add(nums[i]);
            res.Add(new List<int>(item));
            generate(i + 1, nums, item, res);
            item.RemoveAt(item.Count - 1);
            generate(i + 1, nums, item, res);
        }

        //static IList<IList<int>> Subsets(int[] nums)
        //{
        //    List<IList<int>> result = new List<IList<int>>();
        //    List<int> item = new List<int>();
        //    Array.Sort(nums);
        //    generate(result, new List<int>(), nums, 0);
        //    return result;
        //}
        //static void generate(List<IList<int>> result, List<int> tem, int[] nums, int start)
        //{
        //    result.Add(new List<int>(tem));
        //    for (int i = start; i < nums.Length; i++)
        //    {
        //        tem.Add(nums[i]);
        //        generate(result, tem, nums, i + 1);
        //        tem.RemoveAt(tem.Count - 1);
        //    }
        //}
    }
}

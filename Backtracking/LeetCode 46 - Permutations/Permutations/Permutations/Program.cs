//回溯算法，用一个字典记录一个数字是否已经每记录过了。每向item中加一个数字，就将其在字典中记录一下。回溯时，将该数字从item中去掉，别更新字典。
using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            Console.WriteLine(Permute(nums));
        }
        static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            List<int> item = new List<int>();
            Dictionary<int, bool> record = new Dictionary<int, bool>();
            foreach (var n in nums)
                record[n] = false;
            Generate(res, item, nums, record);
            return res;
        }
        static void Generate(List<IList<int>> res, List<int> item, int[] nums, Dictionary<int, bool> record)
        {
            if (item.Count == nums.Length)
            {
                res.Add(new List<int>(item));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (record[nums[i]])
                    continue;
                else
                {
                    item.Add(nums[i]);
                    record[nums[i]] = true;
                }
                Generate(res, item, nums, record);
                item.Remove(nums[i]);
                record[nums[i]] = false;
            }
        }
    }
}

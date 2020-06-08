//回溯算法，用一个布尔数组记录一个数字是否已经每记录过了。每向item中加一个数字，就将其在字典中记录一下。回溯时，将该数字从item中去掉，别更新字典。
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
            var res = new List<IList<int>>();
            var path = new List<int>();
            var visit = new bool[nums.Length];
            DFS(nums, path, res, visit);
            return res;
        }

        static void DFS(int[] nums, List<int> path, List<IList<int>> res, bool[] visit)
        {
            if (path.Count == nums.Length)
            {
                var temp = new List<int>(path);
                res.Add(temp);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (visit[i]) continue;
                path.Add(nums[i]);
                visit[i] = true;
                DFS(nums, path, res, visit);
                path.RemoveAt(path.Count - 1);
                visit[i] = false;
            }
        }
    }
}

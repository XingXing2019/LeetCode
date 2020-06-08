using System;
using System.Collections.Generic;

namespace PermutationsII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1, 2};
            Console.WriteLine(PermuteUnique(nums));
        }
        static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var path = new List<int>();
            var res = new List<IList<int>>();
            var visit = new bool[nums.Length];
            DFS(nums, path, res, visit);
            return res;
        }

        static void DFS(int[] nums, List<int> path, List<IList<int>> res, bool[] viisit)
        {
            if (path.Count == nums.Length)
            {
                var temp = new List<int>(path);
                res.Add(temp);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if(viisit[i]) continue;
                path.Add(nums[i]);
                viisit[i] = true;
                DFS(nums, path, res, viisit);
                path.RemoveAt(path.Count - 1);
                viisit[i] = false;
            }
        }
    }
}

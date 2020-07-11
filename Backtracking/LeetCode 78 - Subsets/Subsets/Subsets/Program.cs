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
            var res = new List<IList<int>>();
            var path = new List<int>();
            DFS(0, nums, path, res);
            return res;
        }

        static void DFS(int start, int[] nums, List<int> path, List<IList<int>> res)
        {
            res.Add(new List<int>(path));
            for (int i = start; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                DFS(i + 1, nums, path, res);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}

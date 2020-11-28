using System.Collections.Generic;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            Subset_BitManipulation(nums);
        }
        static IList<IList<int>> Subset_BackTracking(int[] nums)
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

        static IList<IList<int>> Subset_BitManipulation(int[] nums)
        {
            var count = 1 << nums.Length;
            var res = new List<IList<int>>();
            for (int i = 1; i <= count; i++)
            {
                var temp = new List<int>();
                for (int j = 0; j < nums.Length; j++)
                {
                    if(((1 << j) & i) != 0)
                        temp.Add(nums[j]);
                }
                res.Add(temp);
            }
            return res;
        }
    }
}

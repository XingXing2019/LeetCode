using System;
using System.Collections.Generic;

namespace CombinationSumIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3, n = 15;
            Console.WriteLine(CombinationSum3(k, n));
        }
        static IList<IList<int>> CombinationSum3(int k, int n)
        {
            var res = new List<IList<int>>();
            DFS(k, n, 1, new List<int>(), res);
            return res;
        }

        static void DFS(int k, int n, int start, List<int> nums, IList<IList<int>> res)
        {
            if (k < 0 || n < 0) return;
            if (k == 0 && n == 0)
                res.Add(new List<int>(nums));
            for (int i = start; i <= 9; i++)
            {
                nums.Add(i);
                DFS(k - 1, n - i, i + 1, nums, res);
                nums.RemoveAt(nums.Count - 1);
            }
        }
    }
}

//回溯算法，但是应该可以进一步剪枝，加快速度。
using System;
using System.Collections.Generic;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            Console.WriteLine(Combine(n, k));
        }
        static IList<IList<int>> Combine(int n, int k)
        {
            var res = new List<IList<int>>();
            DFS(n, k, 1, new List<int>(), res);
            return res;
        }

        static void DFS(int n, int k, int cur, List<int> item, List<IList<int>> res)
        {
            if (item.Count == k)
                res.Add(new List<int>(item));
            for (int i = cur; i <= n; i++)
            {
                item.Add(i);
                DFS(n, k, i + 1, item, res);
                item.RemoveAt(item.Count - 1);
            }
        }
    }
}

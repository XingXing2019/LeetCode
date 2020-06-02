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
            List<IList<int>> res = new List<IList<int>>();
            List<int> item = new List<int>();
            Generate(1, res, item, n, k);
            return res;
        }
        static void Generate(int m, List<IList<int>> res, List<int> item, int n, int k)
        {
            if (k == 0)
            {
                res.Add(new List<int>(item));
                return;
            }
            for (int i = m; i <= n; i++)
            {
                if (k != 0)
                    item.Add(i);
                Generate(i + 1, res, item, n, k - 1);
                item.Remove(i);
            }
        }
    }
}

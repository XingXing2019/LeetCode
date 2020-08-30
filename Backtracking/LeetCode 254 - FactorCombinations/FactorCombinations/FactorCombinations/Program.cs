using System;
using System.Collections.Generic;

namespace FactorCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 32;
            Console.WriteLine(GetFactors(n));
        }
        static IList<IList<int>> GetFactors(int n)
        {
            var res = new List<IList<int>>();
            DFS(n, n, 1, 2, new List<int>(), res);
            return res;
        }

        static void DFS(int n, int cur, int product, int next, List<int> path, List<IList<int>> res)
        {
            if(cur == 1 && path.Count != 0)
                res.Add(new List<int>(path));
            for (int i = next; i < n; i++)
            {
                if(i > cur) break;
                if (cur % i == 0 && product * i <= n)
                {
                    path.Add(i);
                    DFS(n, cur / i, product * i, i, path, res);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}

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
            for (int i = 1; i <= 9; i++)
            {
                var visit = new bool[10];
                var path = new List<int>();
                if (i <= n)
                    DFS(i, path, res, k - 1, n - i, visit);
            }
            return res;
        }

        static void DFS(int cur, List<int> path, List<IList<int>> res, int k, int n, bool[] visit)
        {
            path.Add(cur);
            visit[cur] = true;
            if (n < 0 || k < 0) return;
            if (n == 0 && k == 0)
            {
                var temp = new List<int>(path);
                res.Add(temp);
            }
            for (int i = cur; i <= 9; i++)
            {
                if(visit[i]) continue;
                if (k == 0) break;
                DFS(i, path, res, k - 1, n - i, visit);
                path.Remove(i);
                visit[i] = false;
            }
        }
    }
}

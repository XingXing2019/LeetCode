using System;
using System.Collections.Generic;

namespace BeautifulArrangement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(CountArrangement(n));
        }
        static int CountArrangement(int n)
        {
            var res = 0;
            DFS(n, 1, new HashSet<int>(), ref res);
            return res;
        }

        static void DFS(int n, int count, HashSet<int> visited, ref int res)
        {
            if (count == n + 1) res++;
            for (int i = 1; i <= n; i++)
            {
                if ((i % count == 0 || count % i == 0) && visited.Add(i))
                {
                    DFS(n, count + 1, visited, ref res);
                    visited.Remove(i);
                }
            }
        }
    }
}

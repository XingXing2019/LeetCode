using System;
using System.Collections.Generic;

namespace LongestCycleInAGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        private HashSet<int> visited = new HashSet<int>();
        private int res = -1;
        public int LongestCycle(int[] edges)
        {
            for (int i = 0; i < edges.Length; i++)
            {
                if (visited.Contains(i)) continue;
                DFS(edges, i, new HashSet<int>(), new Dictionary<int, int>());
            }
            return res;
        }

        public void DFS(int[] edges, int cur, HashSet<int> path, Dictionary<int, int> indexes)
        {
            if (cur == -1) return;
            path.Add(cur);
            if (!visited.Add(cur))
            {
                if (indexes.ContainsKey(cur))
                    res = Math.Max(res, path.Count - indexes[cur] + 1);
                return;
            }
            indexes[cur] = path.Count;
            DFS(edges, edges[cur], path, indexes);
        }
    }
}

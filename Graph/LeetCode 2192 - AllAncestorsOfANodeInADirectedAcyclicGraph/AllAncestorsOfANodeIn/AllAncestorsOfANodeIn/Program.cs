using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAncestorsOfANodeIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            int[][] edges = new[]
            {
                new[] { 0, 3 },
                new[] { 0, 4 },
                new[] { 1, 3 },
                new[] { 2, 4 },
                new[] { 2, 7 },
                new[] { 3, 5 },
                new[] { 3, 6 },
                new[] { 3, 7 },
                new[] { 4, 6 },
            };
            Console.WriteLine(GetAncestors(n, edges));
        }
        public static IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            var ancestors = new List<HashSet<int>>();
            var graph = new List<int>[n];
            var inDegree = new int[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                ancestors.Add(new HashSet<int>());
            }
            foreach (var edge in edges)
            {
                inDegree[edge[1]]++;
                graph[edge[0]].Add(edge[1]);
            }
            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (inDegree[i] != 0) continue;
                queue.Enqueue(i);
            }
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    foreach (var ancestor in ancestors[cur])
                        ancestors[next].Add(ancestor);
                    ancestors[next].Add(cur);
                    inDegree[next]--;
                    if (inDegree[next] == 0)
                        queue.Enqueue(next);
                }
            }
            var res = new List<IList<int>>();
            foreach (var ancestor in ancestors)
                res.Add(ancestor.OrderBy(x => x).ToList());
            return res;
        }
    }
}

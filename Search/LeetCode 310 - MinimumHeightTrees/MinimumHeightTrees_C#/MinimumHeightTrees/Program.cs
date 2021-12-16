using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumHeightTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[][] edges = new int[][]
            {
                new []{1, 0},
                new []{1, 2},
                new []{1, 3},
            };
            Console.WriteLine(FindMinHeightTrees(n, edges));
        }
        static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1) return new List<int> {0};
            var graph = new List<int>[n];
            var res = new List<int>();
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            var inDegree = new int[n];
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
                inDegree[edge[0]]++;
                inDegree[edge[1]]++;
            }
            var queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 1)
                    queue.Enqueue(i);
            }
            while (queue.Count != 0)
            {
                var count = queue.Count;
                res.Clear();
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    res.Add(cur);
                    foreach (var next in graph[cur])
                    {
                        inDegree[next]--;
                        if (inDegree[next] == 1)
                            queue.Enqueue(next);
                    }
                }
            }
            return res;
        }
    }
}

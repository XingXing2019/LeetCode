using System;
using System.Collections.Generic;

namespace ReachableNodesWithRestrictions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var set = new HashSet<int>(restricted);
            var visited = new HashSet<int> { 0 };
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var res = 0;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                res++;
                foreach (var next in graph[cur])
                {
                    if (!set.Contains(next) && visited.Add(next))
                        queue.Enqueue(next);
                }
            }
            return res;
        }
    }
}

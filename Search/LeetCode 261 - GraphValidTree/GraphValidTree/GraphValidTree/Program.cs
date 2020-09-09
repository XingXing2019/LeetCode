using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphValidTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[][] edges = new int[][]
            {
                new [] {0, 1}, 
                new [] {1, 2},
                new [] {3, 4},
            };
            Console.WriteLine(ValidTree(n, edges));
        }
        static bool ValidTree(int n, int[][] edges)
        {
            var graph = new HashSet<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new HashSet<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var visit = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(0);
            visit.Add(0);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    if (visit.Add(next))
                    {
                        queue.Enqueue(next);
                        graph[next].Remove(cur);
                    }
                    else
                        return false;
                }
            }
            return visit.Count == n;
        }
    }
}

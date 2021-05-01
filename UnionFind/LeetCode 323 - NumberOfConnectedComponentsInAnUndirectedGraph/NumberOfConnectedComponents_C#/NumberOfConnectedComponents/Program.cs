using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfConnectedComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[][] edges = new int[][]
            {
                new[] {0, 1},
                new[] {0, 2},
                new[] {2, 3},
                new[] {2, 4},
            };
            Console.WriteLine(CountComponents(n, edges));
        }
        static int CountComponents(int n, int[][] edges)
        {
            var res = 0;
            var graph = new HashSet<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new HashSet<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var visit = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (visit.Add(i))
                {
                    var queue = new Queue<int>();
                    queue.Enqueue(i);
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
                        }
                    }
                    res++;
                }
            }
            return res;
        }
    }
}

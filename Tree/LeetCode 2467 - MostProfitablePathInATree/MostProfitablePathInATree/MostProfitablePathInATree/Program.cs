using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MostProfitablePathInATree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            var n = edges.Length + 1;
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var queue = new Queue<int>();
            queue.Enqueue(bob);
            var visited = new HashSet<int> { bob };
            var bobPath = new int[n];
            var level = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    bobPath[cur] = level;
                    foreach (var next in graph[cur])
                    {
                        if (!visited.Add(next)) continue;
                        queue.Enqueue(next);
                    }
                }
                level++;
            }
            return DFS(graph, 0, 0, bobPath, amount, 0, new bool[n]);
        }

        public int DFS(List<int>[] graph, int cur, int sum, int[] bobPath, int[] amount, int level, bool[] visited)
        {
            if (visited[cur])
                return 0;
            if (level < bobPath[cur])
                sum += amount[cur];
            else if (level == bobPath[cur])
                sum += amount[cur] / 2;
            var max = 0;
            foreach (var next in graph[cur])
            {
                
            }
        }
    }
}

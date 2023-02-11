using System;
using System.Collections.Generic;

namespace ShortestPathWithAlternatingColors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            var graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();
            foreach (var edge in redEdges)
                graph[edge[0]].Add(new[] { edge[1], 0 });
            foreach (var edge in blueEdges)
                graph[edge[0]].Add(new[] { edge[1], 1 });
            var res = new int[n];
            for (int i = 1; i < n; i++)
                res[i] = BFS(graph, i);
            return res;
        }

        private static int BFS(List<int[]>[] graph, int target)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { 0, -1 });
            var visited = new HashSet<string> { "0:-1" };
            var res = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur[0] == target) return res;
                    foreach (var next in graph[cur[0]])
                    {
                        if (next[1] == cur[1] || !visited.Add($"{next[0]}:{next[1]}")) continue;
                        queue.Enqueue(new[] { next[0], next[1] });
                    }
                }
                res++;
            }
            return -1;
        } 
    }
}

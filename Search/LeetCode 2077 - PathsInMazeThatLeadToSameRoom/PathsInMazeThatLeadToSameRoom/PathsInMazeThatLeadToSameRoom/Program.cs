using System;
using System.Collections.Generic;

namespace PathsInMazeThatLeadToSameRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[][] corridors = new[]
            {
                new[] { 1, 2 },
                new[] { 5, 2 },
                new[] { 4, 1 },
                new[] { 2, 4 },
                new[] { 3, 1 },
                new[] { 3, 4 },
            };
            Console.WriteLine(NumberOfPaths(n, corridors));
        }

        public static int NumberOfPaths(int n, int[][] corridors)
        {
            var graph = new HashSet<int>[n + 1];
            var res = 0;
            for (int i = 0; i < n + 1; i++)
                graph[i] = new HashSet<int>();
            foreach (var corridor in corridors)
            {
                graph[corridor[0]].Add(corridor[1]);
                graph[corridor[1]].Add(corridor[0]);
            }
            for (int i = 1; i <= n; i++)
            {
                var count = 0;
                DFS(graph, 0, i, i, ref count);
                res += count / 2;
            }
            return res / 3;
        }

        public static void DFS(HashSet<int>[] graph, int length, int start, int cur, ref int count)
        {
            if (length > 2)
                return;
            if (length == 2)
            {
                if (graph[cur].Contains(start))
                    count++;
                return;
            }
            foreach (var next in graph[cur])
            {
                DFS(graph, length + 1, start, next, ref count);
            }
        }
    }
}

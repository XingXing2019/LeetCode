using System;
using System.Collections.Generic;

namespace DetonateTheMaximumBombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] bombs = new[]
            {
                new[] { 2, 1, 3 },
                new[] { 6, 1, 4 },
            };
            Console.WriteLine(MaximumDetonation(bombs));
        }

        public static int MaximumDetonation(int[][] bombs)
        {
            var graph = new List<int>[bombs.Length];
            for (int i = 0; i < bombs.Length; i++)
            {
                graph[i] = new List<int>();
                for (int j = 0; j < bombs.Length; j++)
                {
                    if (i == j) continue;
                    double x = Math.Abs(bombs[i][0] - bombs[j][0]);
                    double y = Math.Abs(bombs[i][1] - bombs[j][1]);
                    if (Math.Sqrt(x * x + y * y) <= bombs[i][2])
                        graph[i].Add(j);
                }
            }
            var res = 0;
            for (int i = 0; i < bombs.Length; i++)
            {
                var set = new HashSet<int>();
                DFS(graph, i, new HashSet<int>(), set);
                res = Math.Max(res, set.Count);
            }
            return res;
        }

        public static void DFS(List<int>[] graph, int cur, HashSet<int> visited, HashSet<int> bombs)
        {
            if (!visited.Add(cur)) 
                return;
            bombs.Add(cur);
            foreach (var next in graph[cur])
                DFS(graph, next, visited, bombs);
        }
    }
}

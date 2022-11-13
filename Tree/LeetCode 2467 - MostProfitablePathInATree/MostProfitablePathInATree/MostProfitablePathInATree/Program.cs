using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MostProfitablePathInATree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
            {
                new[] { 0, 2 },
                new[] { 1, 4 },
                new[] { 1, 6 },
                new[] { 2, 4 },
                new[] { 3, 6 },
                new[] { 3, 7 },
                new[] { 5, 7 },
            };
            int bob = 4;
            int[] amount = { -6, -6, -8, -8, 6, -4, -2, -8 };
            Console.WriteLine(MostProfitablePath(edges, bob, amount));
        }

        public static int MostProfitablePath(int[][] edges, int bob, int[] amount)
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
            var visited = new HashSet<int> { bob };
            var bobPath = new int[n];
            Array.Fill(bobPath, int.MaxValue);
            bobPath[bob] = 0;
            var found = false;
            BobPath(graph, bob, visited, bobPath, ref found);
            return AlicePath(graph, 0, bobPath, amount, 0, new HashSet<int> { 0 });
        }

        public static int AlicePath(List<int>[] graph, int cur, int[] bobPath, int[] amount, int level, HashSet<int> visited)
        {
            var sum = level < bobPath[cur] ? amount[cur] : level == bobPath[cur] ? amount[cur] / 2 : 0;
            var max = int.MinValue;
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                max = Math.Max(max, AlicePath(graph, next, bobPath, amount, level + 1, visited));
                visited.Remove(next);
            }
            return max == int.MinValue ? sum : sum + max;
        }

        public static void BobPath(List<int>[] graph, int cur, HashSet<int> visited, int[] bobPath, ref bool found)
        {
            if (found) return;
            if (cur == 0)
            {
                var level = 0;
                foreach (var node in visited)
                    bobPath[node] = level++;
                found = true;
                return;
            }
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                BobPath(graph, next, visited, bobPath, ref found);
                visited.Remove(next);
            }
        }
    }
}

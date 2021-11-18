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
            var largeGraph = new HashSet<int>[n + 1];
            var smallGraph = new HashSet<int>[n + 1];
            var res = 0;
            for (int i = 0; i < n + 1; i++)
            {
                largeGraph[i] = new HashSet<int>();
                smallGraph[i] = new HashSet<int>();
            }
            foreach (var corridor in corridors)
            {
                int min = Math.Min(corridor[0], corridor[1]);
                int max = Math.Max(corridor[0], corridor[1]);
                largeGraph[min].Add(max);
                smallGraph[max].Add(min);
            }
            for (int i = 1; i <= n; i++)
            {
                var count = 0;
                DFS(largeGraph, smallGraph, 0, i, i, ref count);
                res += count;
            }
            return res;
        }

        public static void DFS(HashSet<int>[] largeGraph, HashSet<int>[] smallGraph, int length, int start, int cur, ref int count)
        {
            if (length > 2)
                return;
            if (length == 2)
            {
                if (smallGraph[cur].Contains(start))
                    count++;
                return;
            }
            foreach (var next in largeGraph[cur])
            {
                DFS(largeGraph, smallGraph, length + 1, start, next, ref count);
            }
        }
    }
}

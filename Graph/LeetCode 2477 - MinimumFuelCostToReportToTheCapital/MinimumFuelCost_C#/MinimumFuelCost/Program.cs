using System;
using System.Collections.Generic;

namespace MinimumFuelCost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] roads = new int[][]
            {
                new[] { 3, 1 },
                new[] { 3, 2 },
                new[] { 1, 0 },
                new[] { 0, 4 },
                new[] { 0, 5 },
                new[] { 4, 6 },
            };
            var seat = 2;
            Console.WriteLine(MinimumFuelCost(roads, seat));
        }

        public static long MinimumFuelCost(int[][] roads, int seats)
        {
            var n = roads.Length + 1;
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var road in roads)
            {
                graph[road[0]].Add(road[1]);
                graph[road[1]].Add(road[0]);
            }
            long res = 0;
            DFS(graph, 0, seats, new HashSet<int> { 0 }, ref res);
            return res;
        }

        public static int DFS(List<int>[] graph, int cur, int seats, HashSet<int> visited, ref long res)
        {
            var count = 1;
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                count += DFS(graph, next, seats, visited, ref res);
            }
            if (cur == 0) return count;
            res += count % seats == 0 ? count / seats : count / seats + 1;
            return count;
        }
    }
}

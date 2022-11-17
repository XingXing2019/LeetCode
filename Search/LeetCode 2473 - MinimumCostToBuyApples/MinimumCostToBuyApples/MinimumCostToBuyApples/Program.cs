using System;
using System.Collections.Generic;

namespace MinimumCostToBuyApples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4, k = 2;
            int[][] roads = new int[][]
            {
                new[] { 1, 2, 4 },
                new[] { 2, 3, 2 },
                new[] { 2, 4, 5 },
                new[] { 3, 4, 1 },
                new[] { 1, 3, 4 },
            };
            int[] appleCost = { 56, 42, 102, 301 };
            Console.WriteLine(MinCost(n, roads, appleCost, k));
        }

        public static long[] MinCost(int n, int[][] roads, int[] appleCost, int k)
        {
            var graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();
            foreach (var road in roads)
            {
                graph[road[0] - 1].Add(new[] { road[1] - 1, road[2] });
                graph[road[1] - 1].Add(new[] { road[0] - 1, road[2] });
            }
            var res = new long[n];
            for (int i = 0; i < res.Length; i++)
                res[i] = BFS(graph, i, appleCost, k);
            return res;
        }

        public static long BFS(List<int[]>[] graph, int startCity, int[] appleCost, int k)
        {
            var dp = new long[graph.Length];
            Array.Fill(dp, long.MaxValue);
            dp[startCity] = appleCost[startCity];
            var queue = new Queue<long[]>();
            queue.Enqueue(new[] { startCity, dp[startCity], 0 });
            var res = dp[startCity];
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                long curCity = cur[0], curCost = cur[2];
                res = Math.Min(res, cur[1]);
                foreach (var next in graph[curCity])
                {
                    var nextCity = next[0];
                    var travelCost = next[1];
                    if (appleCost[nextCity] + (1 + k) * (travelCost + curCost) >= dp[nextCity]) continue;
                    dp[nextCity] = appleCost[nextCity] + (1 + k) * (travelCost + curCost);
                    queue.Enqueue(new[] { nextCity, dp[nextCity], travelCost + curCost });
                }
            }
            return res;
        }
    }
}

using System;
using System.Collections.Generic;

namespace MaximalNetworkRank
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[][] roads = new int[][]
            {
                new[] {0, 1},
                new[] {0, 3},
                new[] {1, 2},
                new[] {1, 3},
            };
            Console.WriteLine(MaximalNetworkRank(n, roads));
        }
        static int MaximalNetworkRank(int n, int[][] roads)
        {
            var graph = new HashSet<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new HashSet<int>();
            foreach (var road in roads)
            {
                graph[road[0]].Add(road[1]);
                graph[road[1]].Add(road[0]);
            }
            var res = 0;
            for (int i = 0; i < n; i++)
            {
                var max = 0;
                for (int j = i + 1; j < n; j++)
                {
                    var temp = graph[i].Count + graph[j].Count;
                    if (graph[i].Contains(j)) temp--;
                    max = Math.Max(max, temp);
                }
                res = Math.Max(res, max);
            }
            return res;
        }
    }
}

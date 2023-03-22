using System;
using System.Collections.Generic;

namespace MinimumScoreOfAPathBetweenTwoCities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[][] roads = new int[][]
            {
                new[] { 1, 2, 9 },
                new[] { 2, 3, 6 },
                new[] { 2, 4, 5 },
                new[] { 1, 4, 7 },
            };
            Console.WriteLine(MinScore(n, roads));
        }

        public static int MinScore(int n, int[][] roads)
        {
            var graph = new List<int[]>[n + 1];
            for (int i = 0; i < n + 1; i++)
                graph[i] = new List<int[]>();
            foreach (var road in roads)
            {
                graph[road[0]].Add(new[] { road[1], road[2] });
                graph[road[1]].Add(new[] { road[0], road[2] });
            }
            var queue = new Queue<int>();
            queue.Enqueue(1);
            var visited = new HashSet<int> { 1 };
            var res = int.MaxValue;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    int nextCity = next[0], nextDis = next[1];
                    res = Math.Min(res, nextDis);
                    if (!visited.Add(nextCity))
                        continue;
                    queue.Enqueue(nextCity);
                }
            }
            return res;
        }
    }
}

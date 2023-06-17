using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheClosestMarkedNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumDistance(int n, IList<IList<int>> edges, int s, int[] marked)
        {
            var graph = new List<int[]>[n];
            edges = edges.OrderBy(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]).ToArray();
            var used = new HashSet<string>();
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();
            foreach (var edge in edges)
            {
                if (!used.Add($"{edge[0]}:{edge[1]}")) continue;
                graph[edge[0]].Add(new[] { edge[1], edge[2] });
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { s, 0 });
            var dp = new int[n];
            Array.Fill(dp, int.MaxValue);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur[0]])
                {
                    if (dp[next[0]] <= cur[1] + next[1]) continue;
                    dp[next[0]] = cur[1] + next[1];
                    queue.Enqueue(new[] { next[0], cur[1] + next[1] });
                }
            }
            var targets = new HashSet<int>(marked);
            var res = int.MaxValue;
            for (int i = 0; i < dp.Length; i++)
            {
                if (!targets.Contains(i)) continue;
                res = Math.Min(res, dp[i]);
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
}

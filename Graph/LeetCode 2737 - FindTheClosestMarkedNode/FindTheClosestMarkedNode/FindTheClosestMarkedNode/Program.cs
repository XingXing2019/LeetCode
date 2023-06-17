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
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();
            foreach (var edge in edges)
                graph[edge[0]].Add(new[] { edge[1], edge[2] });
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
            var res = int.MaxValue;
            foreach (var node in marked)
                res = Math.Min(res, dp[node]);
            return res == int.MaxValue ? -1 : res;
        }
    }
}

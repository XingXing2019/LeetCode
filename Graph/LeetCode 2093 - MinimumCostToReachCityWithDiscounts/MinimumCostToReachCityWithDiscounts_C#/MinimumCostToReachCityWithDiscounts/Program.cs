using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumCostToReachCityWithDiscounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4, discount = 4;
            int[][] highways = new[]
            {
                new[] { 1, 2, 7 },
                new[] { 3, 2, 5 },
                new[] { 0, 1, 6 },
                new[] { 3, 0, 20 },
            };
            Console.WriteLine(MinimumCost(n, highways, discount));
        }

        public static int MinimumCost(int n, int[][] highways, int discounts)
        {
            var graph = new List<int[]>[n];
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
                dp[i] = new int[discounts + 1];
                if (i != 0)
                    Array.Fill(dp[i], int.MaxValue);
            }
            foreach (var highway in highways)
            {
                graph[highway[0]].Add(new[] { highway[1], highway[2] });
                graph[highway[1]].Add(new[] { highway[0], highway[2] });
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new []{0, 0, discounts});
            while (queue.Count != 0)
            {
                var item1 = queue.Dequeue();
                int cur = item1[0], cost = item1[1], dis = item1[2];
                if (cur == n - 1) continue;
                foreach (var item2 in graph[cur])
                {
                    int next = item2[0], toll = item2[1];
                    if (dis != 0 && dp[next][dis - 1] > cost + toll / 2)
                    {
                        queue.Enqueue(new []{next, cost + toll / 2, dis - 1});
                        dp[next][dis - 1] = cost + toll / 2;
                    }
                    if (dp[next][dis] > cost + toll)
                    {
                        dp[next][dis] = cost + toll;
                        queue.Enqueue(new[] { next, cost + toll, dis });
                    }
                }
            }
            var res = dp[n - 1].Min();
            return res == int.MaxValue ? -1 : res;
        }
    }
}

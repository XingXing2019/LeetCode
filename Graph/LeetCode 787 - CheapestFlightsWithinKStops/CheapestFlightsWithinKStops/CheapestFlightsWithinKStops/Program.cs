//解法一：直接DFS。利用剪枝，在当前price大于cheapest时返回，外加记录访问过得城市。可以通过测试，但是速度很慢
//解法二：动态规划，dp[i][j]代表飞了i次到达j城所需的最小金额。所以dp的尺寸应该是k+2行，n列。先将dp中每一位置设置成一个很大的值。代表起初没有飞机能到达。
//再将dp[0][src]设为0，代表飞了0次就能到达src，所需金额为0。
//从i=1开始遍历，将dp[i][src]设为0，代表到达src成，飞几次都不需要花钱。
//然后遍历每个flight，则dp[i][flight[1]]等于当前值和飞i-1次到达flight[0]城再加上flight[2]之间较小的值。代表如果能飞i-1次到flight[0]城，只需在飞一次就能到达flight[1]城。
//最后返回dp[k+1][dst]，代表飞了k+1次到达dst的最小花费。
using System;
using System.Collections.Generic;

namespace CheapestFlightsWithinKStops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3, src = 0, dst = 2, k = 1;
            var flight = new int[3][]
            {
                new int[] {0, 1, 100},
                new int[] {1, 2, 100},
                new int[] {0, 2, 500}
            };
            Console.WriteLine(FindCheapestPrice_DP(n, flight, src, dst, k));
        }

        static int FindCheapestPrice_DFS(int n, int[][] flights, int src, int dst, int K)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            var prices = new Dictionary<string, int>();
            foreach (var flight in flights)
            {
                graph[flight[0]].Add(flight[1]);
                prices.Add($"{flight[0]}-{flight[1]}", flight[2]);
            }
            int cheapest = int.MaxValue;
            var visit = new bool[n];
            visit[src] = true;
            DFS(graph, src, dst, K + 2, 0, prices, visit, ref cheapest);
            return cheapest == int.MaxValue ? -1 : cheapest;
        }

        static void DFS(List<int>[] graph, int src, int dst, int K, int price, Dictionary<string, int> prices, bool[] visit, ref int cheapest)
        {
            if (K == 0 || price > cheapest) return;
            if (src == dst)
            {
                cheapest = Math.Min(cheapest, price);
                return;
            }
            for (int i = 0; i < graph[src].Count; i++)
            {
                if (visit[graph[src][i]]) continue;
                visit[graph[src][i]] = true;
                DFS(graph, graph[src][i], dst, K - 1, price + prices[$"{src}-{graph[src][i]}"], prices, visit, ref cheapest);
                visit[graph[src][i]] = false;
            }
        }

        static int FindCheapestPrice_DP(int n, int[][] flights, int src, int dst, int K)
        {
            int infinity = int.MaxValue / 2;
            var dp = new int[K + 2][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[n];
            for (int i = 0; i < dp.Length; i++)
                for (int j = 0; j < dp[0].Length; j++)
                    dp[i][j] = infinity;
            dp[0][src] = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][src] = 0;
                foreach (var flight in flights)
                    dp[i][flight[1]] = Math.Min(dp[i][flight[1]], dp[i - 1][flight[0]] + flight[2]);
            }
            return dp[K + 1][dst] >= infinity ? -1 : dp[K + 1][dst];
        }
    }
}

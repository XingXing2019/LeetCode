using System;
using System.Collections.Generic;

namespace DesignGraphWithShortestPathCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[][] edges = new int[][]
            {
                new[] { 0, 2, 5 },
                new[] { 0, 1, 2 },
                new[] { 1, 2, 1 },
                new[] { 3, 0, 3 },
            };
            var graph = new Graph(n, edges);
            Console.WriteLine(graph.ShortestPath(3, 2));
        }
    }

    public class Graph
    {
        private List<int[]>[] graph;
        public Graph(int n, int[][] edges)
        {
            graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();
            foreach (var edge in edges)
                graph[edge[0]].Add(new[] { edge[1], edge[2] });
        }

        public void AddEdge(int[] edge)
        {
            graph[edge[0]].Add(new[] { edge[1], edge[2] });
        }

        public int ShortestPath(int node1, int node2)
        {
            var dp = new int[graph.Length];
            Array.Fill(dp, int.MaxValue);
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] {node1, 0});
            var res = int.MaxValue;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                int curNode = cur[0], curCost = cur[1];
                if (curNode == node2)
                    res = Math.Min(res, curCost);
                foreach (var next in graph[cur[0]])
                {
                    int nextNode = next[0], nextCost = next[1];
                    if (curCost + nextCost < dp[nextNode])
                    {
                        dp[nextNode] = curCost + nextCost;
                        queue.Enqueue(new[] {nextNode, curCost + nextCost});
                    }
                }
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
}

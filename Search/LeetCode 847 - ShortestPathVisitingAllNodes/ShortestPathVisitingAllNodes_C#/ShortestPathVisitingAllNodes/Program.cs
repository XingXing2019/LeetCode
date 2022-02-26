
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShortestPathVisitingAllNodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] graph = new int[][]
            {
                new[] { 1, 2 },
                new[] { 0 },
                new[] { 0 },
            };
            Console.WriteLine(ShortestPathLength(graph));
        }


        public static int ShortestPathLength(int[][] graph)
        {
            int n = graph.Length, goal = 0, res = int.MaxValue;
            for (int i = 0; i < n; i++)
                goal += 1 << i;
            for (int i = 0; i < n; i++)
                res = Math.Min(res, BFS(graph, i, goal));
            return res;
        }

        public static int BFS(int[][] graph, int start, int goal)
        {
            var queue = new Queue<int[]>();
            var visited = new bool[graph.Length][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new bool[goal + 1];
            queue.Enqueue(new[] { start, 1 << start, 0 });
            visited[start][1 << start] = true;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var status = cur[1];
                if (status == goal) return cur[2];
                foreach (var next in graph[cur[0]])
                {
                    if (visited[next][status | (1 << next)]) continue;
                    visited[next][status | (1 << next)] = true;
                    queue.Enqueue(new[] { next, status | (1 << next), cur[2] + 1 });
                }
            }
            return int.MaxValue;
        }
    }
}

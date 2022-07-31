using System;
using System.Collections.Generic;

namespace FindClosestNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] edges = { 2, 2, 3, -1 };
            int node1 = 0, node2 = 1;
            Console.WriteLine(ClosestMeetingNode(edges, node1, node2));
        }

        public static int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            var graph = new List<int>[edges.Length];
            for (int i = 0; i < edges.Length; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] == -1) continue;
                graph[i].Add(edges[i]);
            }
            var nodes1 = BFS(graph, node1);
            var nodes2 = BFS(graph, node2);
            int res = -1, dis = int.MaxValue;
            foreach (var node in nodes1.Keys)
            {
                if (!nodes2.ContainsKey(node)) continue;
                var max = Math.Max(nodes1[node], nodes2[node]);
                if (max > dis) continue;
                if (max < dis || node < res)
                    res = node;
                dis = max;
            }
            return res;
        }

        private static Dictionary<int, int> BFS(List<int>[] graph, int node)
        {
            var dict = new Dictionary<int, int>();
            var visited = new HashSet<int> { node };
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { node, 0 });
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                dict.Add(cur[0], cur[1]);
                foreach (var next in graph[cur[0]])
                {
                    if (!visited.Add(next)) continue;
                    queue.Enqueue(new[] { next, cur[1] + 1 });
                }
            }
            return dict;
        }
    }
}

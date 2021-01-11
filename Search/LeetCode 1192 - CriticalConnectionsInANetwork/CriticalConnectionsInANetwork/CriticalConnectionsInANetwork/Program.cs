using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CriticalConnectionsInANetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var connection in connections)
            {
                graph[connection[0]].Add(connection[1]);
                graph[connection[1]].Add(connection[0]);
            }
            var res = new List<IList<int>>();
            var min = new int[n];
            for (int i = 0; i < n; i++)
                min[i] = -1;
            DFS(0, -1, 0, min, graph, res);
            return res;
        }

        static int DFS(int cur, int parent, int step, int[] depth, List<int>[] graph, List<IList<int>> res)
        {
            depth[cur] = step;
            var min = int.MaxValue;
            foreach (var child in graph[cur])
            {
                if(child == parent) continue;
                var endDepth = 0;
                if (depth[child] == -1)
                {
                    endDepth = DFS(child, cur, step + 1, depth, graph, res);
                    if (endDepth > step)
                        res.Add(new List<int> {cur, child});
                }
                else
                    endDepth = depth[child];
                min = Math.Min(min, endDepth);
            }
            return min;
        }
    }
}

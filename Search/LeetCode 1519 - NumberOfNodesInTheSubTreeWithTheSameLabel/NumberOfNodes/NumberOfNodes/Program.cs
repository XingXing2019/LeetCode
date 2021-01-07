using System;
using System.Collections.Generic;

namespace NumberOfNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var res = new int[n];
            DFS(0, labels, new int[26], graph, res, new HashSet<int>());
            return res;
        }

        static void DFS(int cur, string label, int[] times, List<int>[] graph, int[] res, HashSet<int> visited)
        {
            if(!visited.Add(cur)) return;
            var curTimes = times[label[cur] - 'a'];
            times[label[cur] - 'a']++;
            foreach (var next in graph[cur])
                DFS(next, label, times, graph, res, visited);
            res[cur] = times[label[cur] - 'a'] - curTimes;
        }
    }
}

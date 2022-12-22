using System;
using System.Collections.Generic;

namespace SumOfDistancesInTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int[][] edges = new[]
            {
                new[] { 0, 1 },
                new[] { 0, 2 },
                new[] { 2, 3 },
                new[] { 2, 4 },
                new[] { 2, 5 },
            };
            Console.WriteLine(SumOfDistancesInTree(n, edges));
        }

        public static int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            var graph = new List<int>[n];
            var res = new int[n];
            var children = new int[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            DFS(0, 0, graph, children, new HashSet<int> { 0 }, ref res[0]);
            GetDistance(0, -1, n, graph, new HashSet<int> { 0 }, res, children);
            return res;
        }

        public static int DFS(int cur, int dis, List<int>[] graph, int[] children, HashSet<int> visited, ref int rootDis)
        {
            var count = 1;
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                count += DFS(next, dis + 1, graph, children, visited, ref rootDis);
                visited.Remove(next);
            }
            rootDis += dis;
            children[cur] = count;
            return count;
        }

        public static void GetDistance(int cur, int prev, int n, List<int>[] graph, HashSet<int> visited, int[] res, int[] children)
        {
            if (prev != -1)
                res[cur] = res[prev] + n - 2 * children[cur];
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                GetDistance(next, cur, n, graph, visited, res, children);
                visited.Remove(next);
            }
        }
    }
}

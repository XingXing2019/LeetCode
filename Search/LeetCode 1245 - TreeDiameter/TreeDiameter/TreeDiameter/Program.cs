using System;
using System.Collections.Generic;

namespace TreeDiameter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
            {
                new[] {0, 1},
                new[] {1, 2},
                new[] {2, 3},
                new[] {1, 4},
                new[] {4, 5},
            };
            Console.WriteLine(TreeDiameter(edges));
        }
        static int TreeDiameter(int[][] edges)
        {
            var res = 0;
            var graph = new List<int>[edges.Length + 1];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var visit = new HashSet<int>();
            var furthest = new int[2];
            visit.Add(0);
            DFS(graph, 0, 0, furthest, visit);
            visit.Clear();
            visit.Add(furthest[1]);
            DFS(graph, furthest[1], 0, furthest, visit);
            res = Math.Max(res, furthest[0]);
            return res;
        }

        static void DFS(List<int>[] graph, int cur, int count, int[] furthest, HashSet<int> visit)
        {
            foreach (var next in graph[cur])
            {
                if(visit.Add(next))
                    DFS(graph, next, count + 1, furthest, visit);
            }
            if (count > furthest[0])
            {
                furthest[0] = count;
                furthest[1] = cur;
            }
        }
    }
}

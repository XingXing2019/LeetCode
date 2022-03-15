using System;
using System.Collections.Generic;

namespace AndroidUnlockPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 1, n = 3;
            Console.WriteLine(NumberOfPatterns(m, n));
        }

        public static int NumberOfPatterns(int m, int n)
        {
            var graph = new[]
            {
                new HashSet<int>(),
                new HashSet<int> { 3, 7, 9 },
                new HashSet<int> { 8 },
                new HashSet<int> { 1, 7, 9 },
                new HashSet<int> { 6 },
                new HashSet<int>(),
                new HashSet<int> { 4 },
                new HashSet<int> { 1, 3, 9 },
                new HashSet<int> { 2 },
                new HashSet<int> { 1, 3, 7 },
            };
            var res = 0;
            for (int i = m; i <= n; i++)
            {
                res += DFS(new bool[10], i, 1, graph) * 4;
                res += DFS(new bool[10], i, 2, graph) * 4;
                res += DFS(new bool[10], i, 5, graph);
            }
            return res;
        }

        public static int DFS(bool[] visited, int left, int cur, HashSet<int>[] graph)
        {
            if (left == 1) return 1;
            var res = 0;
            visited[cur] = true;
            for (int i = 1; i <= 9; i++)
            {
                if (visited[i]) continue;
                if (graph[cur].Contains(i) && !visited[(cur + i) / 2]) continue;
                res += DFS(visited, left - 1, i, graph);
            }
            visited[cur] = false;
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectingCitiesWithMinimumCost
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 3;
            int[][] connections = new[]
            {
                new[] {1, 2, 5},
                new[] {1, 3, 6},
                new[] {2, 3, 1},
            };
            Console.WriteLine(MinimumCost_Prim(N, connections));
        }
        public static int MinimumCost_Kruskal(int N, int[][] connections)
        {
            connections = connections.OrderBy(x => x[2]).ToArray();
            int[] parents = new int[N + 1];
            for (int i = 0; i < parents.Length; i++)
                parents[i] = i;
            int[] rank = new int[N + 1];
            int res = 0;
            foreach (var connection in connections)
            {
                int rootX = Find(connection[0], parents);
                int rootY = Find(connection[1], parents);
                if (rootX == rootY) continue;
                Merge(rootX, rootY, parents, rank);
                res += connection[2];
                N--;
            }
            return N == 1 ? res : -1;
        }

        public static int Find(int x, int[] parents)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x], parents);
            return parents[x];
        }

        public static void Merge(int rootX, int rootY, int[] parents, int[] rank)
        {
            if (rank[rootX] > rank[rootY]) parents[rootY] = rootX;
            else if (rank[rootX] < rank[rootY]) parents[rootX] = rootY;
            else
            {
                parents[rootY] = rootX;
                rank[rootX]++;
            }
        }

        public static int MinimumCost_Prim(int N, int[][] connections)
        {
            var graph = new List<int[]>[N + 1];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int[]>();
            foreach (var connection in connections)
            {
                graph[connection[0]].Add(new []{connection[1], connection[2]});
                graph[connection[1]].Add(new []{connection[0], connection[2]});
            }
            var list = new SortedList<int, Queue<int>>();
            list.Add(0, new Queue<int>());
            list[0].Enqueue(1);
            var visited = new HashSet<int>();
            var res = 0;
            while (list.Count != 0)
            {
                var top = list[list.Keys[0]];
                var cost = list.Keys[0];
                var cur = top.Dequeue();
                if(top.Count == 0)
                    list.RemoveAt(0);
                if (!visited.Add(cur)) continue;
                res += cost;
                foreach (var next in graph[cur])
                {
                    if (!list.ContainsKey(next[1]))
                        list[next[1]] = new Queue<int>();
                    list[next[1]].Enqueue(next[0]);
                }
            }
            return visited.Count == N ? res : -1;
        }
    }
}

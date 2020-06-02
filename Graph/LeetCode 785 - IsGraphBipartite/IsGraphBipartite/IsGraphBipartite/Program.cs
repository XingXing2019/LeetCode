using System;
using System.Collections.Generic;

namespace IsGraphBipartite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsBipartite_BFS(int[][] graph)
        {
            var nodes = graph.Length;
            var colors = new int[nodes];
            var queue = new Queue<int>();
            for (int i = 0; i < nodes; i++)
            {
                if(colors[i] != 0) continue;
                colors[i] = 1;
                queue.Enqueue(i);
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in graph[cur])
                    {
                        if (colors[next] == colors[cur]) return false;
                        if (colors[next] != 0) continue;
                        colors[next] = -colors[cur];
                        queue.Enqueue(next);
                    }
                }
            }
            return true;
        }

        public bool IsBipartite_DFS(int[][] graph)
        {
            var nodes = graph.Length;
            var colors = new int[nodes];
            for (int i = 0; i < nodes; i++)
                if (colors[i] == 0 && !DFS(i, 1, colors, graph))
                    return false;
            return true;
        }

        private bool DFS(int cur, int color, int[] colors, int[][] graph)
        {
            colors[cur] = color;
            foreach (var next in graph[cur])
            {
                if (colors[next] == color) return false;
                if (colors[next] == 0 && !DFS(next, -color, colors, graph)) return false;
            }
            return true;
        }
    }
}

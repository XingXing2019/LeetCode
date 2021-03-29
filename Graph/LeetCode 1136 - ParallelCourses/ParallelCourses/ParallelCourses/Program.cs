using System;
using System.Collections.Generic;
using System.Linq;

namespace ParallelCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinimumSemesters(int n, int[][] relations)
        {
            int[] inDegree = new int[n + 1];
            var graph = new List<int>[n + 1];
            for (int i = 1; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var relation in relations)
            {
                graph[relation[0]].Add(relation[1]);
                inDegree[relation[1]]++;
            }
            var queue = new Queue<int[]>();
            for (int i = 1; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(new[] { i, 1 });
            }
            int res = 0;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                res = Math.Max(res, cur[1]);
                foreach (var next in graph[cur[0]])
                {
                    inDegree[next]--;
                    if (inDegree[next] == 0)
                        queue.Enqueue(new[] { next, cur[1] + 1 });
                }
            }
            return inDegree.All(x => x == 0) ? res : -1;
        }
    }
}

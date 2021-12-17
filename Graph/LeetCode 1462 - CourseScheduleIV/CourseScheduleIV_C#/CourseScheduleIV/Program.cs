using System;
using System.Collections.Generic;

namespace CourseScheduleIV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries)
        {
            var graph = new HashSet<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new HashSet<int>();
            var dependencies = new Dictionary<int, HashSet<int>>();
            foreach (var prerequisite in prerequisites)
                graph[prerequisite[0]].Add(prerequisite[1]);
            for (int i = 0; i < n; i++)
            {
                dependencies[i] = new HashSet<int>();
                var queue = new Queue<int>();
                var visit = new HashSet<int>();
                queue.Enqueue(i);
                visit.Add(i);
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    dependencies[i].Add(cur);
                    foreach (var next in graph[cur])
                    {
                        if (visit.Add(next))
                            queue.Enqueue(next);
                    }
                }
            }
            var res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                res[i] = dependencies[queries[i][0]].Contains(queries[i][1]);
            return res;
        }
    }
}

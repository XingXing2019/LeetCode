using System;
using System.Collections.Generic;

namespace FindEventualSafeStates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] graph = new int[][]
            {
                new int[]{0}, 
                new int[]{2, 3, 4}, 
                new int[]{3, 4}, 
                new int[]{0, 4}, 
                new int[]{}, 
            };
            Console.WriteLine(EventualSafeNodes(graph));
        }
        static IList<int> EventualSafeNodes(int[][] graph)
        {
            var res = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                var queue = new Queue<int>();
                var visit = new bool[graph.Length];
                queue.Enqueue(i);
                visit[i] = true;
                var safe = true;
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in graph[cur])
                    {
                        if (next == i)
                        {
                            safe = false;
                            break;
                        }
                        if(visit[next]) continue;
                        queue.Enqueue(next);
                        visit[next] = true;
                    }
                    if(!safe) break;
                }
                if(safe)
                    res.Add(i);
            }
            return res;
        }
    }
}

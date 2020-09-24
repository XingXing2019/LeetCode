using System;
using System.Collections.Generic;

namespace LoudAndRich
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] LoudAndRich_BFS(int[][] richer, int[] quiet)
        {
            var person = new List<int>[quiet.Length];
            for (int i = 0; i < person.Length; i++)
                person[i] = new List<int> {i};
            foreach (var pair in richer)
                person[pair[1]].Add(pair[0]);
            var res = new int[quiet.Length];
            for (int i = 0; i < res.Length; i++)
            {
                var visit = new HashSet<int>();
                var queue = new Queue<int>();
                queue.Enqueue(i);
                visit.Add(i);
                res[i] = i;
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in person[cur])
                    {
                        if (quiet[next] < quiet[res[i]])
                            res[i] = next;
                        if (visit.Add(next))
                            queue.Enqueue(next);
                    }
                }
            }
            return res;
        }
    }
}

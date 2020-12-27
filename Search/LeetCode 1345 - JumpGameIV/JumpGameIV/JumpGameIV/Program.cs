using System;
using System.Collections.Generic;

namespace JumpGameIV
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
            {
                7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                7, 7
            };
            Console.WriteLine(MinJumps(arr));
        }
        static int MinJumps(int[] arr)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!graph.ContainsKey(arr[i]))
                    graph[arr[i]] = new List<int>();
                graph[arr[i]].Add(i);
            }
            var queue = new Queue<int[]>();
            var visited = new HashSet<int>();
            queue.Enqueue(new[] {0, 0});
            visited.Add(0);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == arr.Length - 1) return cur[1];
                foreach (var next in graph[arr[cur[0]]])
                {
                    if (visited.Add(next))
                        queue.Enqueue(new []{next, cur[1] + 1});
                }
                graph[arr[cur[0]]].Clear();
                if(cur[0] != 0 && visited.Add(cur[0] - 1)) 
                    queue.Enqueue(new []{cur[0] - 1, cur[1] + 1}); 
                if(cur[0] != arr.Length - 1 && visited.Add(cur[0] + 1))
                    queue.Enqueue(new []{cur[0] + 1, cur[1] + 1}); 
            }
            return -1;
        }
    }
}

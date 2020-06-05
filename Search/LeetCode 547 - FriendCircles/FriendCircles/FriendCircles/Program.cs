using System;
using System.Collections.Generic;

namespace FriendCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindCircleNum(int[][] M)
        {
            int number = M.Length;
            var graph = new HashSet<int>[number];
            for (int i = 0; i < number; i++)
                graph[i] = new HashSet<int>();
            for (int i = 0; i < number; i++)
                for (int j = 0; j < number; j++)
                    if (M[i][j] == 1)
                        graph[i].Add(j);
            var visit = new bool[number];
            var count = 0;
            var queue = new Queue<int>();
            for (int i = 0; i < number; i++)
            {
                if (visit[i]) continue;
                queue.Enqueue(i);
                visit[i] = true;
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in graph[cur])
                    {
                        if (visit[next]) continue;
                        queue.Enqueue(next);
                        visit[next] = true;
                    }
                }
                count++;
            }
            return count;
        }
    }
}

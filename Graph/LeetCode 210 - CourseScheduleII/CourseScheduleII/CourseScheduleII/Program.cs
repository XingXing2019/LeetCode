using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseScheduleII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCourses = 4;
            int[][] prerequisites = new int[][]
            {
                new []{1, 0},
                new []{2, 0},
                new []{3, 1},
                new []{3, 2}
            };
            Console.WriteLine(FindOrder(numCourses, prerequisites));
        }
        static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();
            var inDegree = new int[numCourses];
            foreach (var prerequisite in prerequisites)
            {
                graph[prerequisite[1]].Add(prerequisite[0]);
                inDegree[prerequisite[0]]++;
            }
            var res = new int[numCourses];
            var queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; i++)
            {
                if(inDegree[i] == 0)
                    queue.Enqueue(i);
            }
            int index = 0;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                res[index++] = cur;
                foreach (var next in graph[cur])
                {
                    inDegree[next]--;
                    if(inDegree[next] == 0)
                        queue.Enqueue(next);
                }
            }
            if(inDegree.Any(x=> x != 0))
                return new int[0];
            return res;
        }
    }
}

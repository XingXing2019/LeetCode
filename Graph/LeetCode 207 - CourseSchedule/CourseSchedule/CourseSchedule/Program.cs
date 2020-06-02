//创建图节点GraphNode，其中包含CourseNo代表课程序号，nextCourse代表学完专门课程可以学习的下一门可能。
//这里需要引入一个入度的概念。入度代表对于每一门课程需要学习几门预备课程。在图中代表有几条指针指向该门课程。
//在主函数中创建图，根据prerequisites将图中的节点连接起来，并同时统计每门课程的入度，记录去degree数组。
//创建队列辅助进行广度优先遍历。先将degree中入度为零的课程加入队列。
//然后在对列不为空的条件下，弹出对头，再将对头几点nextCourses中的所有课程的入度减一，再将此时入度为零的可能加入队列。
//循环结束后检查是否所有课程的入度都为0。如果都为0证明图是无环图则所有课程都能学完，否则图中有环。
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseSchedule
{

    class Program
    {
        static void Main(string[] args)
        {
            int numCourses = 2;
            int[][] prerequisites = new int[2][]
            {
                new []{1, 0},
                new []{0, 1}
            };
            Console.WriteLine(CanFinish(numCourses, prerequisites));
        }

        class GraphNode
        {
            public int CourseNo;
            public List<GraphNode> nextCourses;
            public GraphNode(int x)
            {
                CourseNo = x;
                nextCourses = new List<GraphNode>();
            }
        }
        static bool CanFinish_BFS(int numCourses, int[][] prerequisites)
        {
             var graph = new GraphNode[numCourses];
             var degree = new int[numCourses];
             for (int i = 0; i < graph.Length; i++)
                 graph[i] = new GraphNode(i);
             foreach (var requisite in prerequisites)
             {
                 var basic = graph[requisite[1]];
                 var advance = graph[requisite[0]];
                 degree[advance.CourseNo]++;
                 basic.nextCourses.Add(advance);
             }
             var queue = new Queue<GraphNode>();
             for (int i = 0; i < degree.Length; i++)
                 if(degree[i] == 0)
                     queue.Enqueue(graph[i]);
             while (queue.Count != 0)
             {
                 var course = queue.Dequeue();
                 foreach (var nextCourse in course.nextCourses)
                 {
                     degree[nextCourse.CourseNo]--;
                     if(degree[nextCourse.CourseNo] == 0)
                         queue.Enqueue(nextCourse);
                 }
             }
             return degree.All(x => x == 0);
        }
        static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var degree = new int[numCourses];
            var graph = new List<int>[numCourses];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var requisite in prerequisites)
            {
                graph[requisite[1]].Add(requisite[0]);
                degree[requisite[0]]++;
            }
            var queue = new Queue<int>();
            for (int i = 0; i < degree.Length; i++)
                if(degree[i] == 0)
                    queue.Enqueue(i);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    degree[next]--;
                    if(degree[next] == 0)
                        queue.Enqueue(next);
                }
            }
            return degree.All(x => x == 0);
        }
    }
}

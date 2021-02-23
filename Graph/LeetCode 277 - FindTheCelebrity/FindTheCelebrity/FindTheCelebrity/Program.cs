using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheCelebrity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Relation
    {
        public bool Knows(int a, int b) => a > b;
    }
    public class Solution : Relation
    {
        public int FindCelebrity(int n)
        {
            var graph = new int[n][];
            for (int i = 0; i < n; i++)
                graph[i] = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    graph[i][j] = Knows(i, j) ? 1 : 0;
            }
            var candidates = new List<int>();
            for (int j = 0; j < n; j++)
            {
                var count = 0;
                for (int i = 0; i < n; i++)
                    count += graph[i][j];
                if(count == n) candidates.Add(j);
            }
            foreach (var i in candidates)
            {
                if (graph[i].Count(x => x == 1) == 1)
                    return i;
            }
            return -1;
        }
    }
}

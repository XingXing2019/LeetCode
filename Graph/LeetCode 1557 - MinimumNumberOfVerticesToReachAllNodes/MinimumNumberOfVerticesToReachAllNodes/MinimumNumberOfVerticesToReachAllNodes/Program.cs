using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumNumberOfVerticesToReachAllNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            var income = new int[n];
            foreach (var edge in edges)
                income[edge[1]]++;
            var res = new List<int>();
            for (int i = 0; i < income.Length; i++)
            {
                if (income[i] == 0)
                    res.Add(i);
            }
            return res;
        }
    }
}

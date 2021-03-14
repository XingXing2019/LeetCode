using System;

namespace FindCenterOfStarGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindCenter(int[][] edges)
        {
            int[] nodes = new int[edges.Length + 2];
            foreach (var edge in edges)
            {
                nodes[edge[0]]++;
                nodes[edge[1]]++;
            }
            return Array.IndexOf(nodes, edges.Length);
        }
    }
}

using System;
using System.Collections.Generic;

namespace MakeCostsOfPathsEqualInABinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            int[] cost = { 1, 5, 2, 32, 3, 12, 1 };
            Console.WriteLine(MinIncrements(n, cost));
        }

        public static int MinIncrements(int n, int[] cost)
        {
            var res = 0;
            DFS(1, cost, ref res);
            return res;
        }

        public static int DFS(int node, int[] cost, ref int res)
        {
            if (node > cost.Length) 
                return 0;
            var left = DFS(node * 2, cost, ref res);
            var right = DFS(node * 2 + 1, cost, ref res);
            res += Math.Abs(left - right);
            return Math.Max(left, right) + cost[node - 1];
        }
    }
}

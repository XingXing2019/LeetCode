using System;
using System.Collections.Generic;
using System.Linq;

namespace ErectTheFence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] tress = new int[][]
            {
                new[] { 3, 7 },
                new[] { 6, 8 },
                new[] { 7, 8 },
                new[] { 11, 10 },
                new[] { 4, 3 },
                new[] { 8, 5 },
            };
            Console.WriteLine(OuterTrees(tress));
        }

        public static int[][] OuterTrees(int[][] trees)
        {
            Array.Sort(trees, (p, q) => p[0] == q[0] ? q[1] - p[1] : q[0] - p[0]);
            var stack = new List<int[]>();
            for (int i = 0; i < trees.Length; i++)
            {
                while (stack.Count >= 2 && Cross(stack[^2], stack[^1], trees[i]) > 0)
                    stack.RemoveAt(stack.Count - 1);
                stack.Add(trees[i]);
            }
            stack.RemoveAt(stack.Count - 1);
            for (int i = trees.Length - 1; i >= 0; i--)
            {
                while (stack.Count >= 2 && Cross(stack[^2], stack[^1], trees[i]) > 0)
                    stack.RemoveAt(stack.Count - 1);
                stack.Add(trees[i]);
            }
            var res = new List<int[]>();
            var visited = new HashSet<string>();
            foreach (var point in stack)
            {
                if (!visited.Add($"{point[0]}:{point[1]}")) continue;
                res.Add(point);
            }
            return res.ToArray();
        }
        
        public static int Cross(int[] p1, int[] p2, int[] tree)
        {
            return (p2[1] - p1[1]) * (tree[0] - p2[0]) - (p2[0] - p1[0]) * (tree[1] - p2[1]);
        }
    }
}

using System;
using System.Collections.Generic;

namespace DepthOfBSTGivenInsertionOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] order = { 2, 1, 4, 3 };
            Console.WriteLine(MaxDepthBST(order));
        }
        
        public static int MaxDepthBST(int[] order)
        {
            var nodes = new List<int>();
            var depth = new Dictionary<int, int>();
            var max = 0;
            foreach (var node in order)
            {
                if (nodes.Count == 0)
                {
                    depth[node] = 1;
                    nodes.Add(node);
                }
                else if (node < nodes[0])
                {
                    depth[node] = depth[nodes[0]] + 1;
                    nodes.Insert(0, node);
                }
                else if (node > nodes[^1])
                {
                    depth[node] = depth[nodes[^1]] + 1;
                    nodes.Add(node);
                }
                else
                {
                    var index = nodes.BinarySearch(node);
                    index = ~index;
                    depth[node] = Math.Max(depth[nodes[index - 1]], depth[nodes[index]]) + 1;
                    nodes.Insert(index, node);
                }
                max = Math.Max(max, depth[node]);
            }
            return max;
        }
    }
}

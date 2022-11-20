using System;
using System.Collections.Generic;

namespace ClosestNodesQueries
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
        {
            var nodes = new List<int>();
            DFS(root, nodes);
            var res = new List<IList<int>>();
            foreach (var query in queries)
            {
                var index = nodes.BinarySearch(query);
                if (index >= 0)
                    res.Add(new List<int> { query, query });
                else
                {
                    index = ~index;
                    if (index == 0)
                        res.Add(new List<int> { -1, nodes[0] });
                    else if (index == nodes.Count)
                        res.Add(new List<int> { nodes[^1], -1 });
                    else
                        res.Add(new List<int> { nodes[index - 1], nodes[index] });
                }
            }
            return res;
        }

        public void DFS(TreeNode node, List<int> nodes)
        {
            if (node == null)
                return;
            DFS(node.left, nodes);
            nodes.Add(node.val);
            DFS(node.right, nodes);
        }
    }
}

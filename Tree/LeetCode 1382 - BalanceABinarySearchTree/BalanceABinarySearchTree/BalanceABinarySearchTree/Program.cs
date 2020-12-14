using System;
using System.Collections.Generic;

namespace BalanceABinarySearchTree
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        static TreeNode BalanceBST(TreeNode root)
        {
            var nodes = new List<int>();
            DFS(root, nodes);
            return Build(nodes.ToArray());
        }

        static void DFS(TreeNode node, List<int> nodes)
        {
            if (node == null) return;
            DFS(node.left, nodes);
            nodes.Add(node.val);
            DFS(node.right, nodes);
        }

        static TreeNode Build(int[] nodes)
        {
            if (nodes.Length == 0) return null;
            var rootIndex = nodes.Length / 2;
            var root = new TreeNode(nodes[rootIndex]);
            var left = Build(nodes[..rootIndex]);
            var right = Build(nodes[(rootIndex + 1)..]);
            root.left = left;
            root.right = right;
            return root;
        }
    }
}

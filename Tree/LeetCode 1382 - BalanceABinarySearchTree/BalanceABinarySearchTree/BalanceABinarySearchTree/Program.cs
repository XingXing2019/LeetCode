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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);
            var d = new TreeNode(4);
            a.right = b;
            b.right = c;
            c.right = d;

            Console.WriteLine(BalanceBST(a));
        }
        
        static TreeNode BalanceBST(TreeNode root)
        {
            var nodes = new List<int>();
            DFS(root, nodes);
            return Build(nodes, 0, nodes.Count - 1);
        }

        static void DFS(TreeNode node, List<int> nodes)
        {
            if (node == null) return;
            DFS(node.left, nodes);
            nodes.Add(node.val);
            DFS(node.right, nodes);
        }

        static TreeNode Build(List<int> nodes, int li, int hi)
        {
            if (li > hi) return null;
            var rootIndex = (hi - li) / 2 + li;
            var root = new TreeNode(nodes[rootIndex]);
            var left = Build(nodes, li, rootIndex - 1);
            var right = Build(nodes, rootIndex + 1, hi);
            root.left = left;
            root.right = right;
            return root;
        }
    }
}

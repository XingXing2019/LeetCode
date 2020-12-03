using System;
using System.Collections.Generic;

namespace LowestCommonAncestorOfABinaryTreeIV
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes)
        {
            return DFS(root, new HashSet<TreeNode>(nodes));
        }

        static TreeNode DFS(TreeNode root, HashSet<TreeNode> nodes)
        {
            if (root == null) return null;
            if (nodes.Contains(root)) return root;
            var left = DFS(root.left, nodes);
            var right = DFS(root.right, nodes);
            if (left == null && right == null) return null;
            if (left != null && right != null) return root;
            return left ?? right;
        }
    }
}

using System;
using System.Collections.Generic;

namespace HeightOfSpecialBinaryTree
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            a.left = b;
            Console.WriteLine(HeightOfTree(a));
        }

        public static int HeightOfTree(TreeNode root)
        {
            var leaves = new HashSet<int>();
            GetLeaves(root, leaves, new HashSet<int>());
            return GetHeight(root, leaves);
        }

        public static void GetLeaves(TreeNode node, HashSet<int> leaves, HashSet<int> visited)
        {
            if (node == null || !visited.Add(node.val))
                return;
            if (node.left == node.right)
                leaves.Add(node.val);
            else if (node.left != null && node.right != null && node.left.right == node)
                leaves.Add(node.val);
            GetLeaves(node.left, leaves, visited);
            GetLeaves(node.right, leaves, visited);
        }

        public static int GetHeight(TreeNode node, HashSet<int> leaves)
        {
            if (node == null || leaves.Contains(node.val))
                return 0;
            var left = GetHeight(node.left, leaves);
            var right = GetHeight(node.right, leaves);
            return Math.Max(left, right) + 1;
        }
    }
}

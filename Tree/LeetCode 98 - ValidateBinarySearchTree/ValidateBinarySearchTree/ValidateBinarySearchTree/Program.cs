using System;
using System.Collections.Generic;

namespace ValidateBinarySearchTree
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsValidBST_Recursion(TreeNode root)
        {
            return DFS_Recursion(root, long.MinValue, long.MaxValue);
        }

        private bool DFS_Recursion(TreeNode node, long min, long max)
        {
            if (node == null) return true;
            var inRange = node.val > min && node.val < max;
            if (!inRange) return false;
            var left = DFS_Recursion(node.left, min, node.val);
            var right = DFS_Recursion(node.right, node.val, max);
            return left && right;
        }

        public bool IsValidBST_Traversal(TreeNode root)
        {
            var list = new List<int>();
            DFS_Traversal(root, list);
            for (int i = 1; i < list.Count; i++)
                if (list[i] <= list[i - 1])
                    return false;
            return true;
        }

        private void DFS_Traversal(TreeNode node, List<int> list)
        {
            if(node == null) return;
            DFS_Traversal(node.left, list);
            list.Add(node.val);
            DFS_Traversal(node.right, list);
        }
    }
}

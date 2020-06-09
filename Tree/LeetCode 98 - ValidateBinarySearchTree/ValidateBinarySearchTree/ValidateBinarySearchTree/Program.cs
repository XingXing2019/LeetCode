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
            var a = new TreeNode(1);
            var b = new TreeNode(1);
            a.left = b;
            Console.WriteLine(IsValidBST_Recursion(a));
        }
        static bool IsValidBST_Recursion(TreeNode root, long min = long.MinValue, long max = long.MaxValue)
        {
            if (root == null) return true;
            if (root.val <= min || root.val >= max) return false;
            return IsValidBST_Recursion(root.left, min, root.val) && IsValidBST_Recursion(root.right, root.val, max);
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

using System;

namespace EvaluateBooleanBinaryTree
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

        public bool EvaluateTree(TreeNode root)
        {
            if (root == null)
                return true;
            if (root.left == root.right)
                return root.val == 1;
            var left = EvaluateTree(root.left);
            var right = EvaluateTree(root.right);
            return root.val == 2 ? left || right : left && right;
        }
    }
}

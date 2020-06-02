//和LeetCode_1123一模一样，一个字都不用改。
using System;

namespace SmallestSubtree
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

        private TreeNode res;
        private int deepest;
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            GetMaxDepth(root, 0);
            return res;
        }

        private int GetMaxDepth(TreeNode node, int level)
        {
            if (node == null) return level - 1;
            deepest = Math.Max(deepest, level);
            int left = GetMaxDepth(node.left, level + 1);
            int right = GetMaxDepth(node.right, level + 1);
            if (left == deepest && right == deepest)
                res = node;
            return Math.Max(left, right);
        }
    }
}

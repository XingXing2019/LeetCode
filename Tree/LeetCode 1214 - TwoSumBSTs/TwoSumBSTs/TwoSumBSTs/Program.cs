using System;

namespace TwoSumBSTs
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
        static bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
        {
            if (root1 == null || root2 == null) return false;
            return DFS(root1, root2.val, target) || TwoSumBSTs(root1, root2.left, target) || TwoSumBSTs(root1, root2.right, target);
        }

        static bool DFS(TreeNode root1, int val, int target)
        {
            if (root1 == null) return false;
            if (root1.val + val == target) return true;
            if (root1.val + val > target) return DFS(root1.left, val, target);
            return DFS(root1.right, val, target);
        }
    }
}

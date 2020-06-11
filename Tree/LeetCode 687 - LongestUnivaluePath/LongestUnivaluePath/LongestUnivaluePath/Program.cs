using System;

namespace LongestUnivaluePath
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
        public int LongestUnivaluePath(TreeNode root)
        {
            int res = 0;
            GetUniValuePath(root, ref res);
            return res;
        }

        private int GetUniValuePath(TreeNode root, ref int res)
        {
            if (root == null) return 0;
            int left = GetUniValuePath(root.left, ref res);
            int right = GetUniValuePath(root.right, ref res);
            int leftPath = 0, rightPath = 0;
            if (root.left != null && root.left.val == root.val)
                leftPath = left + 1;
            if (root.right != null && root.right.val == root.val)
                rightPath = right + 1;
            res = Math.Max(res, leftPath + rightPath);
            return Math.Max(leftPath, rightPath);
        }
    }
}

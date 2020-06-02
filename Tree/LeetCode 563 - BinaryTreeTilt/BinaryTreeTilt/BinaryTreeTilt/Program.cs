using System;

namespace BinaryTreeTilt
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
        private int tilt;
        public int FindTilt(TreeNode root)
        {
            GetSum(root);
            return tilt;
        }
        private int GetSum(TreeNode node)
        {
            if (node == null)
                return 0;
            int left = GetSum(node.left);
            int right = GetSum(node.right);
            tilt += Math.Abs(left - right);
            return left + right + node.val;
        }
    }
}

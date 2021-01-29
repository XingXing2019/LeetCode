using System;

namespace RangeSumOfBST
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
        static int RangeSumBST(TreeNode root, int L, int R)
        {
            int sum = 0;
            if (root == null) return 0;
            sum += root.val >= L && root.val <= R ? root.val : 0;
            sum += root.val < R ? RangeSumBST(root.right, L, R) : 0;
            sum += root.val > L ? RangeSumBST(root.left, L, R) : 0;
            return sum;
        }
    }
}

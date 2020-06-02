
using System;

namespace ConvertBSTToGreaterTree
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
        private int sum;
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null) return null;
            ConvertBST(root.right);
            sum += root.val;
            root.val = sum;
            ConvertBST(root.left);
            return root;
        }
    }
}

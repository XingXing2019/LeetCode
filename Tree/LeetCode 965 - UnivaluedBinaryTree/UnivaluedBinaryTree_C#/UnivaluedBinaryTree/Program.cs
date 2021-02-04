using System;

namespace UnivaluedBinaryTree
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
        static bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
                return false;
            var leftCorrect = root.left == null || (root.val == root.left.val && IsUnivalTree(root.left));
            var rightCorrect = root.right == null || (root.val == root.right.val && IsUnivalTree(root.right));
            return leftCorrect && rightCorrect;
        }
    }
}

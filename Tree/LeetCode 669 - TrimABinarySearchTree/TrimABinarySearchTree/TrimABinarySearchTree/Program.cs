using System;

namespace TrimABinarySearchTree
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
        static TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return root;
            if (root.val < L)
                return TrimBST(root.right, L, R);
            if (root.val > R)
                return TrimBST(root.left, L, R);
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }
    }
}

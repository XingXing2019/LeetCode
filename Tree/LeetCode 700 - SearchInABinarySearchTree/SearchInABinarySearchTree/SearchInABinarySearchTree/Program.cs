using System;

namespace SearchInABinarySearchTree
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
        static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root;
            if (root.val > val) return SearchBST(root.left, val);
            return SearchBST(root.right, val);
        }       
    }
}

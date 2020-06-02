using System;

namespace DiameterOfBinaryTree
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
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(3);
            TreeNode d = new TreeNode(4);
            TreeNode e = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;

            Console.WriteLine(DiameterOfBinaryTree(a));
        }
        static int max = 0;
        static int DiameterOfBinaryTree(TreeNode root)
        {
            MaxDepth(root);
            return max;
        }
        static int MaxDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            int left = MaxDepth(node.left);
            int right = MaxDepth(node.right);
            max = Math.Max(max, left + right);
            return 1 + Math.Max(left, right);
        }
    }
}

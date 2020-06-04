using System;

namespace BalancedBinaryTree
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(2);
            var d = new TreeNode(3);
            var e = new TreeNode(3);
            var f = new TreeNode(4);
            var g = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.left = d;
            c.right = e;
            d.left = f;
            e.right = g;

            Console.WriteLine(IsBalanced(a));
        }
        static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var left = GetDepth(root.left);
            var rigth = GetDepth(root.right);
            return Math.Abs(left - rigth) <=1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        static int GetDepth(TreeNode node)
        {
            if (node == null) return 0;
            return Math.Max(GetDepth(node.left), GetDepth(node.right)) + 1;
        }
    }
}

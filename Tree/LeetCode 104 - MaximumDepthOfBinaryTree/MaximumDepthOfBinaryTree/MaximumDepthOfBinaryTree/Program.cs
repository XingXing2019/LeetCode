using System;

namespace MaximumDepthOfBinaryTree
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
            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;            
        }

        int maxDepth;
        int depth;
        public int MaxDepth(TreeNode root)
        {            
            if (root == null) return depth;
            depth++;
            maxDepth = Math.Max(maxDepth, MaxDepth(root.left));
            maxDepth = Math.Max(maxDepth, MaxDepth(root.right));
            depth--;
            return maxDepth;
        }
    }
}

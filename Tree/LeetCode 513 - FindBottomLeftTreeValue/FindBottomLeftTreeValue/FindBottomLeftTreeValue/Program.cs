//后序遍历，先遍历右子树再遍历左子树，这样就会最后得到最靠左的节点。
using System;

namespace FindBottomLeftTreeValue
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

        private int deepest;
        private int res;
        public int FindBottomLeftValue(TreeNode root, int level = 0)
        {
            if (root == null) return 0;
            deepest = Math.Max(deepest, level);
            res = level == deepest ? root.val : res;
            FindBottomLeftValue(root.right, level + 1);
            FindBottomLeftValue(root.left, level + 1);
            return res;
        }
    }
}

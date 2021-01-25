using System;

namespace SubtreeOfAnotherTree
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
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null) return false;
            if (IsSameTree(s, t)) return true;
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;
            if (s.val != t.val) return false;
            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }
    }
}

using System;

namespace FindACorrespondingNode
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
        private TreeNode res;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            SearchTarget(cloned, target);
            return res;
        }
        void SearchTarget(TreeNode node, TreeNode target)
        {
            if (node == null)
                return;
            if (node.val == target.val)
                res = node;
            SearchTarget(node.left, target);
            SearchTarget(node.right, target);
        }
    }
}

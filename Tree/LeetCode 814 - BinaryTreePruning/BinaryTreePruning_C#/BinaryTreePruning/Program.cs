using System;

namespace BinaryTreePruning
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
        public TreeNode PruneTree(TreeNode root)
        {
            return ContainsOne(root) ? root : null;
        }

        private bool ContainsOne(TreeNode node)
        {
            if (node == null) return false;
            var leftContainsOne = ContainsOne(node.left);
            var rightContainsOne = ContainsOne(node.right);
            if (!leftContainsOne) node.left = null;
            if (!rightContainsOne) node.right = null;
            return node.val == 1 || leftContainsOne || rightContainsOne;
        }
       
    }
}

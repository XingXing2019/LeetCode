using System;
using System.Collections.Generic;

namespace CousinsInBinaryTree
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
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(3);
            TreeNode d = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.right = d;

            Console.WriteLine(IsCousins(a, 2, 3));
        }

        private int xDepth;
        private int yDepth;
        private TreeNode xParent;
        private TreeNode yParent;
        public bool IsCousins(TreeNode root, int x, int y)
        {
            Search(root, x, y, 0, null);
            return xDepth == yDepth && xParent != yParent;
        }

        private void Search(TreeNode node, int x, int y, int depth, TreeNode parent)
        {
            if (node == null)
                return;
            if (node.val == x)
            {
                xDepth = depth;
                xParent = parent;
            }
            else if (node.val == y)
            {
                yDepth = depth;
                yParent = parent;
            }
            Search(node.left, x, y, depth + 1, node);
            Search(node.right, x, y, depth + 1, node);
        }
    }
}

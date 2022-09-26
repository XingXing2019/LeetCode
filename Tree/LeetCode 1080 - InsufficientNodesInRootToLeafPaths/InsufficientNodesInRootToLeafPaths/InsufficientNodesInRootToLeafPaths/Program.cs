using System;
using System.Collections.Generic;

namespace InsufficientNodesInRootToLeafPaths
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(-3);
            var d = new TreeNode(-5);
            var e = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.left = d;
            d.left = e;

            Console.WriteLine(SufficientSubset(a, -1));
        }

        public static TreeNode SufficientSubset(TreeNode root, int limit, int sum = 0)
        {
            if (root == null) 
                return null;
            if (root.left == root.right)
                return sum + root.val < limit ? null : root;
            root.left = SufficientSubset(root.left, limit, sum + root.val);
            root.right = SufficientSubset(root.right, limit, sum + root.val);
            return root.left == root.right ? null : root;
        }
    }
}

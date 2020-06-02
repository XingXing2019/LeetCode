using System;
using System.Collections.Generic;

namespace MaximumDifferenceBetweenNodeAndAncestor
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(8);
            TreeNode b = new TreeNode(3);
            TreeNode c = new TreeNode(10);
            TreeNode d = new TreeNode(1);
            TreeNode e = new TreeNode(6);
            TreeNode f = new TreeNode(14);
            TreeNode g = new TreeNode(4);
            TreeNode h = new TreeNode(7);
            TreeNode i = new TreeNode(1);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;
            e.left = g;
            e.right = h;
            f.left = i;

            Console.WriteLine(MaxAncestorDiff(a));
        }
        static int MaxAncestorDiff(TreeNode root)
        {
            int res = 0, min = int.MaxValue, max = int.MinValue;
            return GetMaxDifference(root, min, max, ref res);
        }

        static int GetMaxDifference(TreeNode node, int min, int max, ref int res)
        {
            if (node == null)
                return 0;
            min = Math.Min(min, node.val);
            max = Math.Max(max, node.val);
            res = Math.Max(res, max - min);
            GetMaxDifference(node.left, min, max, ref res);
            GetMaxDifference(node.right, min, max, ref res);
            return res;
        }
    }
}

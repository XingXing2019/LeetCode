using System;
using System.Collections.Generic;

namespace IncreasingOrderSearchTree
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
            var a = new TreeNode(5);
            var b = new TreeNode(3);
            var c = new TreeNode(6);
            var d = new TreeNode(2);
            var e = new TreeNode(4);
            var f = new TreeNode(8);
            var g = new TreeNode(1);
            var h = new TreeNode(7);
            var i = new TreeNode(9);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;
            d.left = g;
            f.left = h;
            f.right = i;

            Console.WriteLine(IncreasingBST(a));
        }
        static TreeNode IncreasingBST(TreeNode root)
        {
            var res = new TreeNode();
            var pointer = res;
            var values = new List<int>();
            GetNodes(root, values);
            foreach (var val in values)
            {
                pointer.right = new TreeNode(val);
                pointer = pointer.right;
            }
            return res.right;
        }
        static void GetNodes(TreeNode node, List<int> values)
        {
            if (node == null)
                return;
            GetNodes(node.left, values);
            values.Add(node.val);
            GetNodes(node.right, values);
        }
    }
}

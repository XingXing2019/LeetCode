using System;
using System.Numerics;

namespace LongestZigZagPathInABinaryTree
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);
            var d = new TreeNode(4);
            var e = new TreeNode(5);
            var f = new TreeNode(6);
            var g = new TreeNode(7);

            a.left = b;
            a.right = c;
            b.right = d;
            d.left = e;
            d.right = f;
            e.right = g;

            Console.WriteLine(LongestZigZag(a));
        }

        static private int res;
        static int LongestZigZag(TreeNode root)
        {
            DFS(root, 0, true);
            DFS(root, 0, false);
            return res;
        }

        static void DFS(TreeNode node, int length, bool isLeft)
        {
            res = Math.Max(res, length);
            if (node == null) return;
            if (isLeft)
            {
                if (node.left != null)
                    DFS(node.left, length + 1, !isLeft);
                if (node.right != null)
                    DFS(node.right, 1, isLeft);
            }
            else
            {
                if (node.left != null)
                    DFS(node.left, 1, isLeft);
                if (node.right != null)
                    DFS(node.right, length + 1, !isLeft);
            }
        }
    }
}

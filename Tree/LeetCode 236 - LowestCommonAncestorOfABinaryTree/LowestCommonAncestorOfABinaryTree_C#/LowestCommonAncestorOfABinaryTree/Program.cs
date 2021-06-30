using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LowestCommonAncestorOfABinaryTree
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
        static void Main(string[] args)
        {
            var a = new TreeNode(3);
            var b = new TreeNode(5);
            var c = new TreeNode(1);
            var d = new TreeNode(6);
            var e = new TreeNode(2);
            var f = new TreeNode(0);
            var g = new TreeNode(8);
            var h = new TreeNode(7);
            var i = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;
            e.left = h;
            e.right = i;

            var p = d;
            var q = f;

            Console.WriteLine(LowestCommonAncestor_DFS(a, p, q));
        }

        static private bool found;
        static public TreeNode LowestCommonAncestor_DFS(TreeNode root, TreeNode p, TreeNode q)
        {
            var pAncestors = new Queue<TreeNode>();
            var qAncestors = new Queue<TreeNode>();
            DFS(root, pAncestors, p);
            found = false;
            DFS(root, qAncestors, q);
            while (pAncestors.Count > qAncestors.Count)
                pAncestors.Dequeue();
            while (qAncestors.Count > pAncestors.Count)
                qAncestors.Dequeue();
            while (pAncestors.Peek() != qAncestors.Peek())
            {
                pAncestors.Dequeue();
                qAncestors.Dequeue();
            }
            return pAncestors.Peek();
        }

        static private void DFS(TreeNode node, Queue<TreeNode> ancestors, TreeNode target)
        {
            if (node == null || found) return;
            if (node == target)
            {
                ancestors.Enqueue(node);
                found = true;
                return;
            }

            DFS(node.left, ancestors, target);
            DFS(node.right, ancestors, target);
            if (found)
                ancestors.Enqueue(node);
        }

        public TreeNode LowestCommonAncestor_Recursion(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return root;
            if (root == p || root == q) return root;
            var left = LowestCommonAncestor_Recursion(root.left, p, q);
            var right = LowestCommonAncestor_Recursion(root.right, p, q);
            if (left != null && right != null) return root;
            return left ?? right;
        }
    }
}

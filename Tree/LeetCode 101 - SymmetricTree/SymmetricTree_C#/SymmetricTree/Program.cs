﻿using System;
using System.Collections.Generic;

namespace SymmetricTree
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
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(2);
            TreeNode d = new TreeNode(3);
            TreeNode e = new TreeNode(4);
            TreeNode f = new TreeNode(4);
            TreeNode g = new TreeNode(3);
            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;

            Console.WriteLine(IsSymmetric(a));
        }
        static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return CheckSymmetric(root.left, root.right);
        }
        static bool CheckSymmetric(TreeNode left, TreeNode right)
        {
            if (left != null && right != null)
                return left.val == right.val && CheckSymmetric(left.left, right.right) && CheckSymmetric(left.right, right.left);
            return left == null && right == null;
        }
        static bool IsSymmetric_Queue(TreeNode root)
        {
            if (root == null) return true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count != 0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();
                if (left == right) continue;
                if (left == null || right == null || left.val != right.val) return false;
                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }
            return true;
        }
    }
}

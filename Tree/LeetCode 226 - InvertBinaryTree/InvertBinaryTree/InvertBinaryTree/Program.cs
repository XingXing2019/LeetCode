using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace InvertBinaryTree
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
        public TreeNode InvertTree_DFS(TreeNode root)
        {
            if (root == null) return root;
            var left = InvertTree_DFS(root.right);
            var right = InvertTree_DFS(root.left);
            root.left = left;
            root.right = right;
            return root;
        }
        public TreeNode InvertTree_BFS(TreeNode root)
        {
            if (root == null) return root;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var temp = cur.left;
                cur.left = cur.right;
                cur.right = temp;
                if(cur.left != null) queue.Enqueue(cur.left);
                if(cur.right != null) queue.Enqueue(cur.right);
            }
            return root;
        }
    }
}

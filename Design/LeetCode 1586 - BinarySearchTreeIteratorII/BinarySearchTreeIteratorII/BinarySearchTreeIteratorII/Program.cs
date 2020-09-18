using System;
using System.Collections.Generic;

namespace BinarySearchTreeIteratorII
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
    }
    public class BSTIterator
    {
        private readonly List<int> nodes;
        private int pointer;
        public BSTIterator(TreeNode root)
        {
            pointer = 0;
            nodes = new List<int>();
            DFS(root);
        }

        private void DFS(TreeNode root)
        {
            if (root == null) return;
            DFS(root.left);
            nodes.Add(root.val);
            DFS(root.right);
        }

        public bool HasNext()
        {
            return pointer < nodes.Count - 1;
        }

        public int Next()
        {
            return nodes[++pointer];
        }

        public bool HasPrev()
        {
            return pointer > 0;
        }

        public int Prev()
        {
            return nodes[--pointer];
        }
    }
}

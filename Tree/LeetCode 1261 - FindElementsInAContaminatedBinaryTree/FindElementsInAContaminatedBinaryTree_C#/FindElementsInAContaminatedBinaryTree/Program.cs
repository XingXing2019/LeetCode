using System;
using System.Collections.Generic;

namespace FindElementsInAContaminatedBinaryTree
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
            Console.WriteLine("Hello World!");
        }
    }
    public class FindElements
    {
        private HashSet<int> vals;
        public FindElements(TreeNode root)
        {
            vals = new HashSet<int>();
            root.val = 0;
            vals.Add(0);
            DFS(root, vals);
        }

        private void DFS(TreeNode node, HashSet<int> vals)
        {
            if (node == null) return;
            if (node.left != null)
            {
                node.left.val = node.val * 2 + 1;
                vals.Add(node.left.val);
            }
            if (node.right != null)
            {
                node.right.val = node.val * 2 + 2;
                vals.Add(node.right.val);
            }
            DFS(node.left, vals);
            DFS(node.right, vals);
        }

        public bool Find(int target)
        {
            return vals.Contains(target);
        }
    }
}

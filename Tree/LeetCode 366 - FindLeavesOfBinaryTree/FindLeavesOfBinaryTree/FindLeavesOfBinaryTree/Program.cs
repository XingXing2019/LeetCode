using System;
using System.Collections.Generic;
using FindLeavesOfBinaryTree;

namespace FindLeavesOfBinaryTree
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
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            var res = new List<IList<int>>();
            DFS(root, res);
            return res;
        }

        public int DFS(TreeNode node, List<IList<int>> res)
        {
            if (node == null) return -1;
            var left = DFS(node.left, res);
            var right = DFS(node.right, res);
            int height = Math.Max(left, right) + 1;
            if(height == res.Count) res.Add(new List<int>());
            res[height].Add(node.val);
            return height;
        }
    }
}

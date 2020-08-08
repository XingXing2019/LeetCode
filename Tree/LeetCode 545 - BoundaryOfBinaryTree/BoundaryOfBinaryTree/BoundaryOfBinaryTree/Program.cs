using System;
using System.Collections.Generic;

namespace BoundaryOfBinaryTree
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
        static IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            res.Add(root.val);
            DFS(root.left, res, true, false);
            DFS(root.right, res, false, true);
            return res;
        }

        static void DFS(TreeNode node, List<int> res, bool isLeftBoundary, bool isRightBoundary)
        {
            if(node == null) return;
            if(isLeftBoundary) 
                res.Add(node.val);
            if(!isLeftBoundary && !isRightBoundary && node.left == node.right)
                res.Add(node.val);
            DFS(node.left, res, isLeftBoundary, isRightBoundary && node.right == null);
            DFS(node.right, res, isLeftBoundary && node.left == null, isRightBoundary);
            if(isRightBoundary)
                res.Add(node.val);
        }
    }
}

using System;
using System.Collections.Generic;

namespace BinaryTreePreorderTraversal
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
        public IList<int> PreorderTraversal_DFS(TreeNode root)
        {
            var res = new List<int>();
            DFS(root, res);
            return res;
        }

        private void DFS(TreeNode node, List<int> res)
        {
            if(node == null) return;
            res.Add(node.val);
            DFS(node.left, res);
            DFS(node.right, res);
        }

        public IList<int> PreorderTraversal_Stack(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var cur = stack.Pop();
                res.Add(cur.val);
                if (cur.right != null) stack.Push(cur.right);
                if (cur.left != null) stack.Push(cur.left);
            }
            return res;
        }
    }
}

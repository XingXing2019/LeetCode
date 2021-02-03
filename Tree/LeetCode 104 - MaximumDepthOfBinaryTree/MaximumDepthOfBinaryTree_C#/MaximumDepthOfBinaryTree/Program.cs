using System;
using System.Collections.Generic;

namespace MaximumDepthOfBinaryTree
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
            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;            
        }

        int maxDepth;
        int depth;
        public int MaxDepth_DFS(TreeNode root)
        {            
            if (root == null) return depth;
            depth++;
            maxDepth = Math.Max(maxDepth, MaxDepth_DFS(root.left));
            maxDepth = Math.Max(maxDepth, MaxDepth_DFS(root.right));
            depth--;
            return maxDepth;
        }

        public int MaxDepth_BFS(TreeNode root)
        {
            int depth = 0;
            if (root == null) return depth;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                depth++;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
            }
            return depth;
        }
    }
}

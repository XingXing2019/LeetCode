using System;
using System.Collections.Generic;

namespace CountCompleteTreeNodes
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
        static int CountNodes_BFS(TreeNode root)
        {
            if (root == null) return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int count = 0;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                count++;
                if(cur.left != null) queue.Enqueue(cur.left);
                if(cur.right != null) queue.Enqueue(cur.right);
            }
            return count;
        }

        static int CountNodes_DFS(TreeNode root)
        {
            return DFS(root);
        }

        static int DFS(TreeNode node)
        {
            if (node == null) return 0;
            return DFS(node.left) + DFS(node.right) + 1;
        }
    }
}

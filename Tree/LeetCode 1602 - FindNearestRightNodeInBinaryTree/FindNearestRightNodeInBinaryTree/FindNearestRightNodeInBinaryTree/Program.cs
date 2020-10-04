using System;
using System.Collections.Generic;

namespace FindNearestRightNodeInBinaryTree
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
        static TreeNode FindNearestRightNode(TreeNode root, TreeNode u)
        {
            if(u == root) return null;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur == u)
                        return i == count - 1 ? null : queue.Dequeue();
                    if(cur.left != null) queue.Enqueue(cur.left);
                    if(cur.right != null) queue.Enqueue(cur.right);
                }
            }
            return null;
        }
    }
}

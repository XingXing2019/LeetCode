using System;
using System.Collections.Generic;

namespace BinaryTreeRightSideView
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
        public IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                while (count != 0)
                {
                    var current = queue.Dequeue();
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                    count--;
                    if (count == 0)
                        res.Add(current.val);
                }
            }
            return res;
        }
    }
}

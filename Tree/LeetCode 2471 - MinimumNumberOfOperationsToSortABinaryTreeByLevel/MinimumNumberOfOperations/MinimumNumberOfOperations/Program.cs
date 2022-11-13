using System;
using System.Collections.Generic;

namespace MinimumNumberOfOperations
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumOperations(TreeNode root)
        {
            var res = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var nodes = new List<int>();
                var copy = new List<int>();
                var noMatch = 0;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    nodes.Add(cur.val);
                    copy.Add(cur.val);
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                copy.Sort();
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i] == copy[i]) continue;
                    noMatch++;
                }
                res += (int)Math.Ceiling((double)noMatch / 2);
            }
            return res;
        }
    }
}

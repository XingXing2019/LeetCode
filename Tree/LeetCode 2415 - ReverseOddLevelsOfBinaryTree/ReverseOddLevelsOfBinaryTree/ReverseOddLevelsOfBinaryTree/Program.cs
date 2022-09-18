using System;
using System.Collections.Generic;

namespace ReverseOddLevelsOfBinaryTree
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
            var a = new TreeNode(2);
            var b = new TreeNode(3);
            var c = new TreeNode(5);
            Console.WriteLine(ReverseOddLevels(a));
        }

        public static TreeNode ReverseOddLevels(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var level = 0;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var nodes = new List<TreeNode>();
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                    if (level % 2 != 0)
                        nodes.Add(cur);
                }
                int li = 0, hi = nodes.Count - 1;
                while (li < hi)
                {
                    var temp = nodes[li].val;
                    nodes[li++].val = nodes[hi].val;
                    nodes[hi--].val = temp;
                }
                level++;
            }
            return root;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BinaryTreeUpsideDown
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            a.left = b;
            a.right = c;
            Console.WriteLine(UpsideDownBinaryTree(a));
        }
        public static TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            if (root == null) return null;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var record = new List<List<TreeNode>>();
            while (queue.Count != 0)
            {
                var temp = new List<TreeNode>();
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                    cur.left = null;
                    cur.right = null;
                    temp.Add(cur);
                }
                record.Add(temp);
            }
            for (int i = record.Count - 1; i > 0; i--)
            {
                record[i][0].left = record[i].Count < 2 ? null : record[i][1];
                record[i][0].right = record[i - 1][0];
            }
            return record[^1][0];
        }
    }
}

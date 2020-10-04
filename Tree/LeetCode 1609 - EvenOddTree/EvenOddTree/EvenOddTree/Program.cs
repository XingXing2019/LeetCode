using System;
using System.Collections.Generic;

namespace EvenOddTree
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
            var a = new TreeNode(5);
            var b = new TreeNode(4);
            var c = new TreeNode(2);
            var d = new TreeNode(3);
            var e = new TreeNode(3);
            var f = new TreeNode(7);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;

            Console.WriteLine(IsEvenOddTree(a));
        }
        static bool IsEvenOddTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var evenLayer = true;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var value = evenLayer ? int.MinValue : int.MaxValue;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (evenLayer && (cur.val % 2 == 0 || cur.val <= value) || 
                        !evenLayer && (cur.val % 2 != 0 || cur.val >= value)) return false;
                    value = cur.val;
                    if(cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                evenLayer = !evenLayer;
            }
            return true;
        }
    }
}

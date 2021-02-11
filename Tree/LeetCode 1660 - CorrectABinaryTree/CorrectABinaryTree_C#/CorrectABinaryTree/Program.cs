using System;
using System.Collections.Generic;

namespace CorrectABinaryTree
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
            var a = new TreeNode(8);
            var b = new TreeNode(3);
            var c = new TreeNode(1);
            var d = new TreeNode(7);
            var e = new TreeNode(9);
            var f = new TreeNode(4);
            var g = new TreeNode(2);
            var h = new TreeNode(5);
            var i = new TreeNode(6);

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;
            c.right = f;
            d.left = g;
            d.right = f;
            f.left = h;
            f.right = i;

            Console.WriteLine(CorrectBinaryTree(a));
        }
        static TreeNode CorrectBinaryTree(TreeNode root)
        {
            var dict = new Dictionary<TreeNode, TreeNode>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.right != null && dict.ContainsKey(cur.right))
                    {
                        var parent = dict[cur];
                        if (parent.left == cur)
                            parent.left = null;
                        else
                            parent.right = null;
                        return root;
                    }
                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                        dict[cur.right] = cur;
                    }
                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                        dict[cur.left] = cur;
                    }
                }
            }
            return root;
        }
    }
}

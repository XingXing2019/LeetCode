using System;
using System.Collections.Generic;

namespace AddOneRowToTree
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
            var a = new TreeNode(4);
            var b = new TreeNode(2);
            var c = new TreeNode(6);
            var d = new TreeNode(3);
            var e = new TreeNode(1);
            var f = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;

            int val = 1, depth = 3;

            Console.WriteLine(AddOneRow_BFS(a, val, depth));
        }
        static TreeNode AddOneRow_BFS(TreeNode root, int v, int d)
        {
            if (d == 1) return new TreeNode(v, root, null);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool finish = false;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                d--;
                while (count != 0)
                {
                    var cur = queue.Dequeue();
                    if (d == 1)
                    {
                        cur.left = new TreeNode(v, cur.left, null);
                        cur.right = new TreeNode(v, null, cur.right);
                        finish = true;
                    }
                    if(cur.left != null) queue.Enqueue(cur.left);
                    if(cur.right != null) queue.Enqueue(cur.right);
                    count--;
                }
                if(finish) break;
            }
            return root;
        }
    }
}

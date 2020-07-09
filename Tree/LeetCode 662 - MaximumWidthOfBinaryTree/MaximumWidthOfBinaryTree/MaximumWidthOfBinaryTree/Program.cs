using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumWidthOfBinaryTree
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
            var a = new TreeNode(1);
            var b = new TreeNode(3);
            var c = new TreeNode(2);
            var d = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;

            Console.WriteLine(WidthOfBinaryTree(a));
        }
        public class MyNode : TreeNode
        {
            public MyNode(TreeNode node, int index) : base(node.val)
            {
                this.left = node.left;
                this.right = node.right;
                this.index = index;
            }
            public int index;
        }
        static int WidthOfBinaryTree(TreeNode root)
        {
            var maxWidth = 0;
            var queue = new Queue<MyNode>();
            queue.Enqueue(new MyNode(root, 1));
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var left = 0;
                var width = 0;
                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (left == 0)
                    {
                        left = node.index;
                        width = 1;
                    }
                    else
                        width = node.index - left + 1;
                    if (node.left != null) queue.Enqueue(new MyNode(node.left, node.index * 2));
                    if (node.right != null) queue.Enqueue(new MyNode(node.right, node.index * 2 + 1));
                }
                maxWidth = Math.Max(maxWidth, width);
            }
            return maxWidth;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CousinsInBinaryTreeII
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
            var a = new TreeNode(5);
            var b = new TreeNode(4);
            var c = new TreeNode(9);
            var d = new TreeNode(1);
            var e = new TreeNode(10);
            var f = new TreeNode(7);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;

            Console.WriteLine(ReplaceValueInTree(a));
        }

        public static TreeNode ReplaceValueInTree(TreeNode root)
        {
            var sums = new Dictionary<TreeNode, int>();
            DFS(root, null, sums);
            BFS(root, sums);
            return root;
        }

        private static void BFS(TreeNode root, Dictionary<TreeNode, int> sums)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var sum = 0;
                var nodes = new List<TreeNode>();
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    nodes.Add(cur);
                    sum += cur.val;
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                foreach (var node in nodes)
                {
                    node.val = sum - sums[node];
                }
            }
        }

        private static void DFS(TreeNode node, TreeNode parent, Dictionary<TreeNode, int> sums)
        {
            if (node == null) return;
            if (parent != null)
            {
                var sum = 0;
                if (parent.left != null) sum += parent.left.val;
                if (parent.right != null) sum += parent.right.val;
                sums[node] = sum;
            }
            else
                sums[node] = node.val;
            DFS(node.left, node, sums);
            DFS(node.right, node, sums);
        }
    }
}

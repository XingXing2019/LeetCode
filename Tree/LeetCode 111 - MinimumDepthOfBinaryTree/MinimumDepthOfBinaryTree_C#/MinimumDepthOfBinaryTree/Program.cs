using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDepthOfBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinDepth_DFS(TreeNode root)
        {
            if (root == null)
                return 0;
            List<int> record = new List<int>();
            int depth = 0;
            GetDepth(root, record, depth);
            return record.Min(r => r);
        }
        static void GetDepth(TreeNode node, List<int> record, int depth)
        {
            if (node == null)
                return;
            depth++;
            if(node.left == null && node.right == null)
            {
                record.Add(depth);
                return;
            }
            GetDepth(node.left, record, depth);
            GetDepth(node.right, record, depth);
            depth--;
        }
        public int MinDepth_BFS(TreeNode root)
        {
            if (root == null) return 0;
            int depth = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                depth++;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.left == cur.right) return depth;
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
            }
            return depth;
        }
    }
}

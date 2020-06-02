using System;
using System.Collections.Generic;

namespace FindLargestValueInEachTreeRow
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
        public IList<int> LargestValues_BFS(TreeNode root)
        { 
            var res = new List<int>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int count = queue.Count;
                int max = int.MinValue;
                while (count != 0)
                {
                    var current = queue.Dequeue();
                    max = Math.Max(max, current.val);
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                    count--;
                }
                res.Add(max);
            }
            return res;
        }
        public IList<int> LargestValues_DFS(TreeNode root)
        {
            var res = new List<int>();
            DFS(root, 0, res);
            return res;
        }

        public void DFS(TreeNode node, int level, List<int> res)
        {
            if(node == null) return;
            if (res.Count <= level)
                res.Add(int.MinValue); 
            DFS(node.left, level + 1, res);
            DFS(node.right, level + 1, res);
            res[level] = Math.Max(res[level], node.val);
        }
    }
}

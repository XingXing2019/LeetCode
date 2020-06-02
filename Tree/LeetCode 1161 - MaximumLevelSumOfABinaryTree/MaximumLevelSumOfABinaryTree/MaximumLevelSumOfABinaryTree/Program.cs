using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumLevelSumOfABinaryTree
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
        public int MaxLevelSum_BFS(TreeNode root)
        {
            int maxSum = int.MinValue, level = 1, maxLevel = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var sum = 0;
                while (count != 0)
                {
                    var current = queue.Dequeue();
                    sum += current.val;
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                    count--;
                }
                if(sum > maxSum)
                {
                    maxSum = sum;
                    maxLevel = level;
                }
                level++;
            }
            return maxLevel;
        }
        public int MaxLevelSum_DFS(TreeNode root)
        {
            var sums = new List<int>();
            DFS(root, 0, sums);
            return sums.IndexOf(sums.Max(x => x)) + 1;
        }
        private void DFS(TreeNode node, int level, List<int> sums)
        {
            if (node == null) return;
            if (sums.Count <= level)
                sums.Add(0);
            sums[level] += node.val;
            DFS(node.left, level + 1, sums);
            DFS(node.right, level + 1, sums);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CreateBinaryTreeFromDescriptions
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
            int[][] descriptions = new[]
            {
                new[] { 20, 15, 1 },
                new[] { 20, 17, 0 },
                new[] { 50, 20, 1 },
                new[] { 50, 80, 0 },
                new[] { 80, 19, 1 },
            };
            Console.WriteLine(CreateBinaryTree(descriptions));
        }
        public static TreeNode CreateBinaryTree(int[][] descriptions)
        {
            var graph = new Dictionary<int, List<int[]>>();
            var inDegree = new Dictionary<int, int>();
            var queue = new Queue<TreeNode>();
            foreach (var description in descriptions)
            {
                var parent = description[0];
                var child = description[1];
                if (!graph.ContainsKey(parent))
                    graph[parent] = new List<int[]>();
                graph[parent].Add(new[] { child, description[2] });
                if (!inDegree.ContainsKey(child))
                    inDegree[child] = 0;
                if (!inDegree.ContainsKey(parent))
                    inDegree[parent] = 0;
                inDegree[child]++;
            }
            var root = new TreeNode(inDegree.First(x => x.Value == 0).Key);
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (!graph.ContainsKey(cur.val)) continue;
                foreach (var next in graph[cur.val])
                {
                    var child = new TreeNode(next[0]);
                    if (next[1] == 1)
                        cur.left = child;
                    else
                        cur.right = child;
                    queue.Enqueue(child);
                }
            }
            return root;
        }
    }
}

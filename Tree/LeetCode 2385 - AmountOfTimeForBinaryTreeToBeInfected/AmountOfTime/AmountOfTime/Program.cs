using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AmountOfTime
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
            var b = new TreeNode(5);
            var c = new TreeNode(3);
            var d = new TreeNode(4);
            var e = new TreeNode(10);
            var f = new TreeNode(6);
            var g = new TreeNode(9);
            var h = new TreeNode(2);

            //a.left = b;
            //a.right = c;
            //b.right = d;
            //c.left = e;
            //c.right = f;
            //d.left = g;
            //d.right = h;

            Console.WriteLine(AmountOfTime(a, 1));
        }

        public static int AmountOfTime(TreeNode root, int start)
        {
            var graph = new Dictionary<int, HashSet<int>>();
            DFS(root, -1, graph);
            var res = 0;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            var visited = new HashSet<int> { start };
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (!graph.ContainsKey(cur)) continue;
                    foreach (var next in graph[cur])
                    {
                        if (!visited.Add(next) || next == -1) continue;
                        queue.Enqueue(next);
                    }
                }
                res++;
            }
            return res - 1;
        }

        public static void DFS(TreeNode node, int parent, Dictionary<int, HashSet<int>> graph)
        {
            if (node == null) return;
            if (!graph.ContainsKey(parent))
                graph[parent] = new HashSet<int>();
            graph[parent].Add(node.val);
            if (!graph.ContainsKey(node.val))
                graph[node.val] = new HashSet<int>();
            graph[node.val].Add(parent);
            DFS(node.left, node.val, graph);
            DFS(node.right, node.val, graph);
        }
    }
}

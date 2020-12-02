using System;
using System.Collections.Generic;

namespace ClosestLeafInABinaryTree
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
            var b = new TreeNode(2);
            var c = new TreeNode(3);
            var d = new TreeNode(4);
            var e = new TreeNode(5);
            var f = new TreeNode(6);

            a.left = b;
            a.right = c;
            b.left = d;
            d.left = e;
            e.left = f;

            int k = 5;
            Console.WriteLine();
        }
        public int FindClosestLeaf(TreeNode root, int k)
        {
            var graph = new Dictionary<TreeNode, List<TreeNode>>();
            var leaves = new List<TreeNode>();
            var parent = new TreeNode(0, root);
            DFS(graph, leaves, root, parent);
            int path = int.MaxValue, res = 0;
            foreach (var leaf in leaves)
            {
                var visit = new HashSet<TreeNode> {leaf};
                var queue = new Queue<TreeNode>();
                queue.Enqueue(leaf);
                var layer = 0;
                while (queue.Count != 0)
                {
                    var count = queue.Count;
                    layer++;
                    for (int i = 0; i < count; i++)
                    {
                        var cur = queue.Dequeue();
                        if (cur.val == k)
                        {
                            if (layer < path)
                            {
                                path = layer;
                                res = leaf.val;
                            }
                            break;
                        }
                        foreach (var next in graph[cur])
                        {
                            if(visit.Add(next))
                                queue.Enqueue(next);
                        }
                    }
                    
                }
            }
            return res;
        }

        static void DFS(Dictionary<TreeNode, List<TreeNode>> graph, List<TreeNode> leaves, TreeNode node, TreeNode parent)
        {
            if(node == null) return;
            if (node.left == node.right) leaves.Add(node);
            if(!graph.ContainsKey(node))
                graph[node] = new List<TreeNode>();
            if(!graph.ContainsKey(parent))
                graph[parent] = new List<TreeNode>();
            graph[node].Add(parent);
            graph[parent].Add(node);
            DFS(graph, leaves, node.left, node);
            DFS(graph, leaves, node.right, node);
        }
    }
}

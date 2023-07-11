using System;
using System.Collections.Generic;

namespace AllNodesDistanceKInBinaryTree
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
        static IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            var parents = new Dictionary<TreeNode, TreeNode>();
            DFS(root, null, parents);
            var queue = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();
            queue.Enqueue(target);
            visited.Add(target);
            var res = new List<int>();
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (K == 0) res.Add(cur.val);
                    if (cur.left != null && visited.Add(cur.left)) queue.Enqueue(cur.left);
                    if (cur.right != null && visited.Add(cur.right)) queue.Enqueue(cur.right);
                    if (parents[cur] != null && visited.Add(parents[cur])) queue.Enqueue(parents[cur]);
                }
                K--;
            }
            return res;
        }

        static void DFS(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parents)
        {
            if (node == null) return;
            parents[node] = parent;
            DFS(node.left, node, parents);
            DFS(node.right, node, parents);
        }
    }
}

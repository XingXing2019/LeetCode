using System;
using System.Collections.Generic;

namespace MinimumNumberOfOperations
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
            Console.WriteLine("Hello World!");
        }

        public int MinimumOperations(TreeNode root)
        {
            var res = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var nodes = new List<int>();
                var sorted = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    nodes.Add(cur.val);
                    sorted.Add(cur.val);
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                sorted.Sort();
                res += Swap(nodes, sorted);
            }
            return res;
        }

        public int Swap(List<int> nodes, List<int> sorted)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < sorted.Count; i++)
                dict[sorted[i]] = i;
            int res = 0, index = 0;
            while (index < nodes.Count)
            {
                while (dict[nodes[index]] != index)
                {
                    var target = dict[nodes[index]];
                    (nodes[index], nodes[target]) = (nodes[target], nodes[index]);
                    res++;
                }
                index++;
            }
            return res;
        }
    }
}

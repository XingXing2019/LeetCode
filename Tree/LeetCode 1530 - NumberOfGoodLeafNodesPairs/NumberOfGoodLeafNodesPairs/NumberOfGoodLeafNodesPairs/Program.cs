using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfGoodLeafNodesPairs
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

        public int CountPairs(TreeNode root, int distance)
        {
            var res = 0;
            DFS(root, 0, distance, ref res);
            return res;
        }

        public List<int> DFS(TreeNode node, int level, int distance, ref int res)
        {
            if (node == null)
                return new List<int>();
            if (node.left == node.right)
                return new List<int> { level };
            var left = DFS(node.left, level + 1, distance, ref res);
            var right = DFS(node.right, level + 1, distance, ref res);
            foreach (var l in left)
                res += right.Count(r => l - level + r - level <= distance);
            var path = new List<int>(left);
            path.AddRange(right);
            return path;
        }
    }
}

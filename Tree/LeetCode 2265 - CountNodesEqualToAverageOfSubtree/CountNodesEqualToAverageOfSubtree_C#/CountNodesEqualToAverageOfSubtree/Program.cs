using System;

namespace CountNodesEqualToAverageOfSubtree
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

        private int res;
        public int AverageOfSubtree(TreeNode root)
        {
            DFS(root);
            return res;
        }

        public int[] DFS(TreeNode root)
        {
            if (root == null)
                return new[] { 0, 0 };
            var sum = root.val;
            var count = 1;
            var left = DFS(root.left);
            var right = DFS(root.right);
            sum += left[0] + right[0];
            count += left[1] + right[1];
            if (sum / count == root.val)
                res++;
            return new[] { sum, count };
        }
    }
}

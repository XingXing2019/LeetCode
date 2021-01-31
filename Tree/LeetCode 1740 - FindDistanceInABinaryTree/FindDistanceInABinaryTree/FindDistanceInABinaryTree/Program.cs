using System;

namespace FindDistanceInABinaryTree
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

        public int FindDistance(TreeNode root, int p, int q)
        {
            int diameter = 0;
            DFS(root, p, q, ref diameter);
            return diameter;
        }

        public int DFS(TreeNode node, int p, int q, ref int diameter)
        {
            int depth = 0;
            if (node == null) return depth;
            if (node.val == p || node.val == q)
                depth++;
            var left = DFS(node.left, p, q, ref diameter);
            var right = DFS(node.right, p, q, ref diameter);
            if (left != 0 && right != 0 || depth != 0 && (left != 0 || right != 0))
                diameter = left + right;
            else if (left != 0 || right != 0)
                depth = left + right + 1;
            return depth;
        }
    }
}

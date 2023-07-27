using System;

namespace CountNodesThatAreGreatEnough
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

        public int CountGreatEnoughNodes(TreeNode root, int k)
        {
            if (root == null)
                return 0;
            var res = DFS(root, root.val) >= k ? 1 : 0;
            res += CountGreatEnoughNodes(root.left, k);
            res += CountGreatEnoughNodes(root.right, k);
            return res;
        }

        public int DFS(TreeNode node, int val)
        {
            if (node == null)
                return 0;
            var res = node.val < val ? 1 : 0;
            res += DFS(node.left, val);
            res += DFS(node.right, val);
            return res;
        }
    }
}

using System;

namespace CountUnivalueSubtrees
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
        static int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null)
                return 0;
            int count = 0;
            DFS(root, ref count);
            return count;
        }

        static bool DFS(TreeNode node, ref int count)
        {
            if (node.left == node.right)
            {
                count++;
                return true;
            }
            var isUnique = true;
            if (node.left != null)
                isUnique = DFS(node.left, ref count) && isUnique && node.val == node.left.val;
            if (node.right != null)
                isUnique = DFS(node.right, ref count) && isUnique && node.val == node.right.val;
            if (!isUnique)
                return false;
            count++;
            return true;
        }
    }
}

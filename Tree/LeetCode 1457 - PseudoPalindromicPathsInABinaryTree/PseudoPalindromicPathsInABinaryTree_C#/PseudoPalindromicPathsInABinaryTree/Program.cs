using System;
using System.Linq;

namespace PseudoPalindromicPathsInABinaryTree
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

        private static int count;
        static int PseudoPalindromicPaths(TreeNode root)
        {
            CountValidPath(root, new int[10]);
            return count;
        }

        static void CountValidPath(TreeNode node, int[] record)
        {
            if (node == null) return;
            record[node.val]++;
            if (node.left == node.right && record.Count(x => x % 2 != 0) < 2)
                count++;
            CountValidPath(node.left, record);
            CountValidPath(node.right, record);
            record[node.val]--;
        }
    }
}

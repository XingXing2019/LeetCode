//思路和LeetCode 113相似。
using System;
using System.Collections.Generic;

namespace PathSum
{
    class TreeNode
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
            TreeNode a = new TreeNode(5);
            TreeNode b = new TreeNode(4);
            TreeNode c = new TreeNode(8);
            TreeNode d = new TreeNode(11);
            TreeNode e = new TreeNode(13);
            TreeNode f = new TreeNode(4);
            TreeNode g = new TreeNode(7);
            TreeNode h = new TreeNode(2);
            TreeNode i = new TreeNode(1);

            a.left = b;
            a.right = c;
            b.left = d;
            d.left = g;
            d.right = h;
            c.left = e;
            c.right = f;
            f.right = i;

            int sum = 22;
            Console.WriteLine(HasPathSum(a, sum));
        }
        static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            int pathValue = 0;
            List<int> count = new List<int>();
            Preorder(root, sum, pathValue, count);
            return count.Count != 0;
        }
        static void Preorder(TreeNode node, int sum, int pathValue, List<int> count)
        {
            if (node == null)
                return;
            pathValue += node.val;
            if (node.left == null && node.right == null && pathValue == sum)
                count.Add(pathValue);
            Preorder(node.left, sum, pathValue, count);
            Preorder(node.right, sum, pathValue, count);
            pathValue -= node.val;
        }
        static bool HasPathSum_Recursion(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == root.right) return sum - root.val == 0;
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }
    }
}

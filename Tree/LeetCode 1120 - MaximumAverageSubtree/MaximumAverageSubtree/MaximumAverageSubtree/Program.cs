using System;
using System.Collections.Generic;

namespace MaximumAverageSubtree
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
            TreeNode a = new TreeNode(5);
            TreeNode b = new TreeNode(6);
            TreeNode c = new TreeNode(1);

            a.left = b;
            a.right = c;

            Console.WriteLine(MaximumAverageSubtree(a));
        }
        static double MaximumAverageSubtree(TreeNode root)
        {
            var sum = new List<double>();
            var count = new List<double>();
            GetSum(root, sum);
            GetCount(root, count);
            var max = double.MinValue;
            for (int i = 0; i < sum.Count; i++)
                max = Math.Max(max, sum[i] / count[i]);
            return max;
        }

        static double GetSum(TreeNode node, List<double> res)
        {
            if(node == null)
                return 0;
            double sum = node.val + GetSum(node.left, res) + GetSum(node.right, res);
            res.Add(sum);
            return sum;
        }

        static double GetCount(TreeNode node, List<double> res)
        {
            if (node == null)
                return 0;
            double count = 1 + GetCount(node.left, res) + GetCount(node.right, res);
            res.Add(count);
            return count;
        }
    }
}

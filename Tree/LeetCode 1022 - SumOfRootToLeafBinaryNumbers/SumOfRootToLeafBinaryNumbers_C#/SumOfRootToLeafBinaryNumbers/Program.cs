using System;
using System.Collections.Generic;

namespace SumOfRootToLeafBinaryNumbers
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

        public int SumRootToLeaf(TreeNode root)
        {
            int sum = 0;
            GetNum(root, 0, ref sum);
            return sum;
        }
        private void GetNum(TreeNode node, int num, ref int sum)
        {
            if(node == null)
                return;
            num <<= 1;
            num += node.val;
            if (node.left == null && node.right == null)
                sum += num;
            GetNum(node.left, num, ref sum);
            GetNum(node.right, num, ref sum);
            num -= node.val;
            num >>= 1;
        }
    }
}

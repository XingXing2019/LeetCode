using System;

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

        int num;
        int sum;
        public int SumRootToLeaf(TreeNode root)
        {
            GetNum(root);
            return sum;
        }
        private void GetNum(TreeNode node)
        {
            if(node == null)
                return;
            num <<= 1;
            num += node.val;
            if (node.left == null && node.right == null)
                sum += num;
            GetNum(node.left);
            GetNum(node.right);
            num -= node.val;
            num >>= 1;
        }
    }
}

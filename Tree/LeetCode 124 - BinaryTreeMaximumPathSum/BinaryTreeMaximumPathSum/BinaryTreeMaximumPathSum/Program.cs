//GetMax方法用来获得以当前节点出发，分别走左右两条路能获得的最大路径和。
//在类体里创建maxSum记录最大路径和，初始值设为int最小值。
//如果当前节点为空，则以当前节点为根节点能获得最大路径和为0.
//currentValue记录当前节点的值，分别递归计算以当前节点左节点和右节点为根节点能获得的最大路径和leftMax和rightMax。如果为负，则取零，代表如果为负数则选择不取。
//如果currentValue + leftMax + rightMax 大于maxSum，则更新maxSum。
//返回走左路径的最大和与走右路径最大和中较大的那个。
using System;

namespace BinaryTreeMaximumPathSum
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
        private int maxSum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            if (root == null)
                return 0;
            GetMax(root);
            return maxSum;
        }

        private int GetMax(TreeNode node)
        {
            if (node == null)
                return 0;
            int currentValue = node.val;
            int leftMax = Math.Max(0, GetMax(node.left));
            int rightMax = Math.Max(0, GetMax(node.right));
            maxSum = Math.Max(maxSum, leftMax + currentValue + rightMax);
            return Math.Max(currentValue + leftMax, currentValue + rightMax);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }
}

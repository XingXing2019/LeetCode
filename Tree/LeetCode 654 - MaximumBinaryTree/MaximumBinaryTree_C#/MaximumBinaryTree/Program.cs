//查找nums中的最大值max及其位置index。以max构建根节点root，再以index分割数组。递归调用创建root的左右子树。
//C#数组切片语法。nums[..index] - 0到index(不包含)的所有元素。nums[(index + 1)..nums.Length] - index + 1到数组尾。
using System;
using System.Linq;

namespace MaximumBinaryTree
{
    public class TreeNode
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
            Console.WriteLine("Hello World!");
        }
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums.Length == 0)
                return null;
            int max = nums.Max(num => num);
            int index = Array.IndexOf(nums, max);
            var root = new TreeNode(max);
            int[] left = nums[..index];
            int[] right = nums[(index + 1)..nums.Length];
            root.left = ConstructMaximumBinaryTree(left);
            root.right = ConstructMaximumBinaryTree(right);
            return root;
        }
    }
}

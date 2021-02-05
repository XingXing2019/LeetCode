using System;

namespace ConvertSortedArrayToBinarySearchTree
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
            int[] nums = {-10, -3, 0, 5, 9};
            Console.WriteLine(SortedArrayToBST(nums));
        }
        static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            int index = nums.Length / 2;
            int[] left = index == nums.Length ? new int[0] : nums[..index];
            int[] right = index == nums.Length? new int[0] : nums[(index + 1)..];
            var root = new TreeNode(nums[index]);
            root.left = SortedArrayToBST(left);
            root.right = SortedArrayToBST(right);
            return root;
        }
    }
}

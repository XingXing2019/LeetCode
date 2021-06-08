//和LeetCode_106思路一样，后续变前序。
using System;

namespace ConstructBinaryTree
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
            int[] preorder = {3, 9, 20, 15, 7};
            int[] inorder = {9, 3, 15, 20, 7};

            Console.WriteLine(BuildTree(preorder, inorder));
        }
        static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0) return null;
            var root = new TreeNode(preorder[0]);
            int index = Array.IndexOf(inorder, preorder[0]);

            int[] leftInOrder = index != -1 ? inorder[..index] : new int[0];
            int[] rightInOrder = index != -1 ? inorder[(index + 1)..inorder.Length] : new int[0];
            int[] leftPreOrder = preorder[1..(index + 1)];
            int[] rightPreOrder = preorder[(index + 1)..preorder.Length];

            root.left = BuildTree(leftPreOrder, leftInOrder);
            root.right = BuildTree(rightPreOrder, rightInOrder);
            return root;
        }
    }
}

//后续遍历的得到的数组是根节点在最后一个。中序遍历是跟节点在中间，左边是左子树，右边是右子树。
//所以找到跟节点在中序数组中的位置，左右分别切片，生成两个中序子数组，在找到对应的后续子数组。分别递归带入左子树和右子树
using System;
using System.Collections.Generic;

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
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };
            Console.WriteLine(BuildTree(inorder, postorder));
        }

        static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
                return null;
            var root = new TreeNode(postorder[^1]);
            int index = Array.IndexOf(inorder, postorder[^1]);

            int[] leftInOrder = index != -1 ? inorder[..index] : new int[0];
            int[] rightInOrder = index != -1 ? inorder[(index + 1)..inorder.Length] : new int[0];
            int[] leftPostOrder = postorder[..index];
            int[] rightPostOrder = postorder[index..^1];

            root.right = BuildTree(rightInOrder, rightPostOrder);
            root.left = BuildTree(leftInOrder, leftPostOrder);
            return root;
        }
    }
}

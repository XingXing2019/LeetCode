using System;

namespace CheckIfAStringIsAValidSequence
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
        private static bool res;
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(0);
            TreeNode b = new TreeNode(1);
            TreeNode c = new TreeNode(0);
            TreeNode d = new TreeNode(0);
            TreeNode e = new TreeNode(1);
            TreeNode f = new TreeNode(0);
            TreeNode g = new TreeNode(1);
            TreeNode h = new TreeNode(0);
            TreeNode i = new TreeNode(0);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            d.right = g;
            e.left = h;
            e.right = i;

            int[] arr = {0, 1, 1};
            Console.WriteLine(IsValidSequence(a, arr));
        }
        static bool IsValidSequence(TreeNode root, int[] arr)
        {
            return DFS(root, arr, 0);
        }

        static bool DFS(TreeNode node, int[] arr, int index)
        {
            if (node == null || index >= arr.Length)
                return false;
            if (node.left == null && node.right == null && node.val == arr[index] && index == arr.Length - 1)
                return true;
            return node.val == arr[index] && DFS(node.left, arr, index + 1) || DFS(node.right, arr, index + 1);
        }
    }
}

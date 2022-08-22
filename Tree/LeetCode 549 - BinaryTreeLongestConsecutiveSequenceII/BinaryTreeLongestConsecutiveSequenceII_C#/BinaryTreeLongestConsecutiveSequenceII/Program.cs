using System;

namespace BinaryTreeLongestConsecutiveSequenceII
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(2);
            var b = new TreeNode(1);
            var c = new TreeNode(3);

            a.left = b;
            a.right = c;

            Console.WriteLine(LongestConsecutive(a));
        }

        public static int LongestConsecutive(TreeNode root)
        {
            var res = 0;
            DFS(root, ref res);
            return res;
        }

        public static int[] DFS(TreeNode root, ref int res)
        {
            if (root == null)
                return new int[] { 0, 0 };
            int increase = 1, decrease = 1;
            if (root.left != null)
            {
                var left = DFS(root.left, ref res);
                if (root.val == root.left.val + 1)
                    increase = Math.Max(increase, left[0] + 1);
                if (root.val == root.left.val - 1)
                    decrease = Math.Max(decrease, left[1] + 1);
            }
            if (root.right != null)
            {
                var right = DFS(root.right, ref res);
                if (root.val == root.right.val - 1)
                    decrease = Math.Max(decrease, right[1] + 1);
                if (root.val == root.right.val + 1)
                    increase = Math.Max(increase, right[0] + 1);
            }
            res = Math.Max(res, increase + decrease - 1);
            return new int[] { increase, decrease };
        }
    }
}

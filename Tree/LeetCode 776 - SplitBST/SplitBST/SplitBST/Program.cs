using System;

namespace SplitBST
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
        public TreeNode[] SplitBST(TreeNode root, int V)
        {
            if (root == null)
                return new TreeNode[] {null, null};
            if (root.val > V)
            {
                var splited = SplitBST(root.left, V);
                root.left = splited[1];
                splited[1] = root;
                return splited;
            }
            else
            {
                var splited = SplitBST(root.right, V);
                root.right = splited[0];
                splited[0] = root;
                return splited;
            }
        }
    }
}

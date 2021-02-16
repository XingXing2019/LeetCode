using System;

namespace DeleteLeavesWithAGivenValue
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
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return null;
            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);
            return (root.left == null && root.right == null && root.val == target) ? null : root;
        }
    }
}

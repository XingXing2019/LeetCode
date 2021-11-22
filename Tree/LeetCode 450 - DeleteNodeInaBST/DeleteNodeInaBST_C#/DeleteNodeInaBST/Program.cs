using System;

namespace DeleteNodeInaBST
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
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                if (root.left == null && root.right == null) return null;
                else if (root.left == null && root.right != null) return root.right;
                else if (root.left != null && root.right == null) return root.left;
                else
                {
                    var minNode = GetMinNode(root.right);
                    root.val = minNode.val;
                    root.right = DeleteNode(root.right, minNode.val);
                }
            }
            else if (root.val > key)
                root.left = DeleteNode(root.left, key);
            else
                root.right = DeleteNode(root.right, key);
            return root;
        }

        private TreeNode GetMinNode(TreeNode node)
        {
            while (node.left != null) node = node.left;
            return node;
        }
    }
}

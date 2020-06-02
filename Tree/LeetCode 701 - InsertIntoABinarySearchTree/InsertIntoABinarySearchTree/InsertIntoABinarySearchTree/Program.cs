using System;

namespace InsertIntoABinarySearchTree
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
            TreeNode a = new TreeNode(4);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(7);
            TreeNode d = new TreeNode(1);
            TreeNode e = new TreeNode(3);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;

            int val = 5;
            Console.WriteLine(InsertIntoBST(a, val));
        }
        static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (val > root.val)
                root.right = InsertIntoBST(root.right, val);
            else
                root.left = InsertIntoBST(root.left, val);
            return root;
        }
        
    }
}

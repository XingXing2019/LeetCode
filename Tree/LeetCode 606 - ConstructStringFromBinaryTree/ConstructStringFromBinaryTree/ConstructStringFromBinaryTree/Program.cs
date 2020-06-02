using System;

namespace ConstructStringFromBinaryTree
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

        public string Tree2str(TreeNode t)
        {
            if (t == null)
                return "";
            if (t.left == null && t.right == null)
                return t.val.ToString();
            if (t.right == null)
                return t.val + "(" + Tree2str(t.left) + ")";
            return t.val + "(" + Tree2str(t.left) + ")(" + Tree2str(t.right) + ")";
        }

    }
}

using System;
using System.Collections.Generic;

namespace BinaryTreeInorderTraversal
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
        public IList<int> InorderTraversal(TreeNode root)
        {
            var record = new List<int>();
            GetNode(root, record);
            return record;
        }

        static void GetNode(TreeNode node, List<int> record)
        {
            if (node == null)
                return;
            GetNode(node.left, record);
            record.Add(node.val);
            GetNode(node.right, record);
        }
    }
}

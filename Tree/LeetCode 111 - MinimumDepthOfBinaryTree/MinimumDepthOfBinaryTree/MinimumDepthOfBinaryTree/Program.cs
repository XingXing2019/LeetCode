using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDepthOfBinaryTree
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
        static int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            List<int> record = new List<int>();
            int depth = 0;
            GetDepth(root, record, depth);
            return record.Min(r => r);
        }
        static void GetDepth(TreeNode node, List<int> record, int depth)
        {
            if (node == null)
                return;
            depth++;
            if(node.left == null && node.right == null)
            {
                record.Add(depth);
                return;
            }
            GetDepth(node.left, record, depth);
            GetDepth(node.right, record, depth);
            depth--;
        }
    }
}

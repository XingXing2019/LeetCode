using System;
using System.Collections.Generic;

namespace SecondMinimumNodeInABinaryTree
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
            TreeNode a = new TreeNode(2);
            TreeNode b = new TreeNode(-2);
            TreeNode c = new TreeNode(5);
            TreeNode d = new TreeNode(5);
            TreeNode e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            Console.WriteLine(FindSecondMinimumValue(a));
        }
        static int FindSecondMinimumValue(TreeNode root)
        {
            var record = new Dictionary<int, int>();
            GetNodes(root, record);
            if (record.Count < 2)
                return -1;
            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;
            foreach (var r in record)
            {
                secondMin = Math.Min(secondMin, r.Key);
                if (r.Key < firstMin)
                {
                    secondMin = firstMin;
                    firstMin = r.Key;
                }
            }
            return secondMin;
        }
        static void GetNodes(TreeNode node, Dictionary<int, int> record)
        {
            if (node == null)
                return;
            if (!record.ContainsKey(node.val))
                record[node.val] = 1;
            GetNodes(node.left, record);
            GetNodes(node.right, record);
        }
    }
}

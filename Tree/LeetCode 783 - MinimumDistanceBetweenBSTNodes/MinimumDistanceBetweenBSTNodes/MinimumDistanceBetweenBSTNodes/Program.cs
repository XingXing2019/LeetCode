using System;
using System.Collections.Generic;

namespace MinimumDistanceBetweenBSTNodes
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
            var a = new TreeNode(4);
            var b = new TreeNode(2);
            var c = new TreeNode(6);
            var d = new TreeNode(1);
            var e = new TreeNode(3);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;

            Console.WriteLine(MinDiffInBST(a));
        }
        static int MinDiffInBST(TreeNode root)
        {
            var record = new List<int>();
            GetNodes(root, record);
            var res = int.MaxValue;
            for (int i = 1; i < record.Count; i++)
                res = Math.Min(res, record[i] - record[i - 1]);
            return res;
        }

        static void GetNodes(TreeNode node, List<int> record)
        {
            if (node == null)
                return;
            GetNodes(node.left, record);
            record.Add(node.val);
            GetNodes(node.right, record);
        }
    }
}

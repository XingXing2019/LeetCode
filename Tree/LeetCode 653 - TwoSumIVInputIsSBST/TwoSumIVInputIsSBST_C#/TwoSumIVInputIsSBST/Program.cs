using System;
using System.Collections.Generic;

namespace TwoSumIVInputIsSBST
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
            var a = new TreeNode(5);
            var b = new TreeNode(3);
            var c = new TreeNode(6);
            var d = new TreeNode(2);
            var e = new TreeNode(4);
            var f = new TreeNode(7);
            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;
            int k = 28;
            Console.WriteLine(FindTarget(a, k));
        }
        static bool FindTarget(TreeNode root, int k)
        {
            var record = new List<int>();
            GetNodes(root, record);
            int li = 0, hi = record.Count - 1;
            while (li < hi)
            {
                if (record[li] + record[hi] == k)
                    return true;
                else if (record[li] + record[hi] > k)
                    hi--;
                else
                    li++;
            }
            return false;
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

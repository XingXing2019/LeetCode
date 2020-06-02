//先获得所有节点的值，在做相应操作。
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindModeInBinarySearchTree
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
        static int[] FindMode(TreeNode root)
        {
            var record = new Dictionary<int, int>();
            GetNodes(root, record);
            if (record.Count == 0)
                return new int[0];
            int max = record.Max(r => r.Value);
            int[] res = record.Where(r => r.Value == max).Select(r => r.Key).ToArray();
            return res;
        }
        static void GetNodes(TreeNode node, Dictionary<int, int> record)
        {
            if (node == null)
                return;
            GetNodes(node.left, record);
            if (!record.ContainsKey(node.val))
                record[node.val] = 1;
            else
                record[node.val]++;
            GetNodes(node.right, record);
        }
    }
}

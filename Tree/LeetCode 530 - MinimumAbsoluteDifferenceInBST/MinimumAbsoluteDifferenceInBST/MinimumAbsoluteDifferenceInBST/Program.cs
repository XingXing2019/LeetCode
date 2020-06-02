//中序遍历二叉搜索树，可以获得一个升序的列表。
//然后遍历列表找到最小的差值。
using System;
using System.Collections.Generic;

namespace MinimumAbsoluteDifferenceInBST
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
        static int GetMinimumDifference(TreeNode root)
        {
            List<int> record = new List<int>();
            GetNodes(root, record);
            int res = int.MaxValue;
            if (record.Count < 2)
                return res;
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

using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreePaths
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
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(3);
            TreeNode d = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.right = d;

            BinaryTreePaths(a);
        }
        static IList<string> BinaryTreePaths(TreeNode root)
        {
            var record = new List<string>();
            var nums = new List<int>();
            PreOrder(root, record, nums);
            return record;
        }
        static void PreOrder(TreeNode node, List<string> record, List<int> nums)
        {
            if(node == null)
                return;
            nums.Add(node.val);
            if (node.left == null && node.right == null)
            {
                StringBuilder str = new StringBuilder();
                foreach (var n in nums)
                    str.Append(n + "->");
                if (str.Length >= 2)
                    str.Remove(str.Length - 2, 2);
                record.Add(str.ToString());
            }                     
            PreOrder(node.left, record, nums);
            PreOrder(node.right, record, nums);
            nums.RemoveAt(nums.Count - 1);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumRootToLeafNumbers
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            a.left = b;
            a.right = c;

            Console.WriteLine(SumNumbers(a));
        }
        static int SumNumbers(TreeNode root)
        {
            int sum = 0;
            GetSum(root, ref sum, 0);
            return sum;
        }

        static void GetSum(TreeNode node, ref int sum, int num)
        {
            if (node == null)
                return;
            num = num * 10 + node.val;
            if (node.left == node.right)
            {
                sum += num;
                return;
            }
            GetSum(node.left, ref sum, num);
            GetSum(node.right, ref sum, num);
        }
    }
}

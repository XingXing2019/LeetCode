
using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentSubtreeSum
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
            var b = new TreeNode(2);
            var c = new TreeNode(-3);

            a.left = b;
            a.right = c;

            Console.WriteLine(FindFrequentTreeSum(a));
        }

        
        static int[] FindFrequentTreeSum(TreeNode root)
        {
            if(root == null) return new int[0];
            var dict = new Dictionary<int, int>();
            GetSum(root, dict);
            int max = dict.Max(x => x.Value);
            return dict.Where(x => x.Value == max).Select(x => x.Key).ToArray();
        }

        static int GetSum(TreeNode node, Dictionary<int, int> dict)
        {
            if (node == null) return 0;
            int left = GetSum(node.left, dict);
            int right = GetSum(node.right, dict);
            int sum = node.val + left + right;
            if (!dict.ContainsKey(sum))
                dict[sum] = 1;
            else
                dict[sum]++;
            return sum;
        }
    }
}

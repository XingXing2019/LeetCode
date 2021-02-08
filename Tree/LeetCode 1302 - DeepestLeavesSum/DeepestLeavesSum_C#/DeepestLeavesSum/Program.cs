//对root进行深搜，当到达底部的时候将深度和节点值存入一个字典。
//最后统计字典最大深度对应所有值之和。
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepestLeavesSum
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
            TreeNode e = new TreeNode(5);
            TreeNode f = new TreeNode(6);
            TreeNode g = new TreeNode(7);
            TreeNode h = new TreeNode(8);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;
            d.left = g;
            f.right = h;

            Console.WriteLine(DeepestLeavesSum(a));
        }

        private int deepest;
        private int level;
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        public int DeepestLeavesSum(TreeNode root)
        {
            GetValues(root);
            return dict[deepest];
        }

        private void GetValues(TreeNode node)
        {
            if (node == null)
                return;
            level++;
            deepest = Math.Max(deepest, level);
            dict[level] = dict.ContainsKey(level) ? dict[level] + node.val : node.val;
            GetValues(node.left);
            GetValues(node.right);
            level--;
        }
    }
}

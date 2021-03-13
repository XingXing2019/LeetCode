//使用深度优先搜索加上递归的方法。创建前序遍历方法Preorder。返回条件为node为空，否则将当前值加入path，并更新pathValue，当前node为叶节点(left和right为空)，且pathValue等于sum时，将path加入res。
//递归调用Preorder函数，遍历左右节点。当到达叶节点返回时将path最后一个数字弹出，并更新pathValue。
//在主方法中调用preorder方法将符合要求的结果记入res。
using System;
using System.Collections;
using System.Collections.Generic;

namespace PathSumII
{
    class TreeNode
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
            var b = new TreeNode(4);
            var c = new TreeNode(8);
            var d = new TreeNode(11);
            var e = new TreeNode(13);
            var f = new TreeNode(4);
            var g = new TreeNode(7);
            var h = new TreeNode(2);
            var i = new TreeNode(5);
            var j = new TreeNode(1);
            int sum = 22;

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;
            c.right = f;
            d.left = g;
            d.right = h;
            f.left = i;
            f.right = j;

            Console.WriteLine(PathSum(a, sum));
        }
        static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var res = new List<IList<int>>();
            DFS(root, sum, new List<int>(), res);
            return res;
        }

        static void DFS(TreeNode node, int sum, List<int> item, List<IList<int>> res)
        {
            if (node == null) return;
            item.Add(node.val);
            if (node.left == node.right && sum - node.val == 0)
                res.Add(new List<int>(item));
            DFS(node.left, sum - node.val, item, res);
            DFS(node.right, sum - node.val, item, res);
            item.RemoveAt(item.Count - 1);
        }
    }
}

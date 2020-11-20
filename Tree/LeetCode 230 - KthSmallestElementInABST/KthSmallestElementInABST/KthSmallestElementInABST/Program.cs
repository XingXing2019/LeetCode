//利用二叉搜索树的特点中序遍历，创建一个列表存储数值，先遍历左子树。结束后如果列表长度等于k，就返回，否则将当前节点数值加入列表。再遍历右子树。
//遍历结束后可以获得一个长度为k的升序列表，则列表最后一个数字就是结果。
using System;
using System.Collections.Generic;
using System.Threading;

namespace KthSmallestElementInABST
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
            TreeNode a = new TreeNode(5);
            TreeNode b = new TreeNode(3);
            TreeNode c = new TreeNode(6);
            TreeNode d = new TreeNode(2);
            TreeNode e = new TreeNode(4);
            TreeNode f = new TreeNode(1);
            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            d.left = f;

            int k = 3;
        }
        public int KthSmallest(TreeNode root, int k)
        {
            int res = 0, count = 0;
            DFS(root, ref count, k, ref res);
            return res;
        }

        static void DFS(TreeNode node, ref int count, int k, ref int res)
        {
            if (node == null || count > k) return;
            DFS(node.left, ref count, k, ref res);
            if (k == ++count) res = node.val;
            DFS(node.right, ref count, k, ref res);
        }
    }
}

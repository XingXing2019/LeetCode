//前序更新max，后序记录结果。
using System;

namespace CountGoodNodesInBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(3);
            var b = new TreeNode(1);
            var c = new TreeNode(4);
            var d = new TreeNode(3);
            var e = new TreeNode(1);
            var f = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;
            c.right = f;

            Console.WriteLine(GoodNodes(a));
        }

        private static int res;
        static int GoodNodes(TreeNode root)
        {
            DFS(root, int.MinValue);
            return res;
        }

        static void DFS(TreeNode node, int max)
        {
            if(node == null) return;
            max = Math.Max(max, node.val);
            DFS(node.left, max);
            DFS(node.right, max);
            if (node.val >= max)
                res++;
        }
    }
}

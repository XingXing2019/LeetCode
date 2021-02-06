//前序遍历树，找到左边的叶子，加入结果。
//左边叶子的条件为，其父节点的左子树不为空，且左子树的左右子树都为空。
using System;

namespace SumOfLeftLeaves
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
            TreeNode a = new TreeNode(3);
            TreeNode b = new TreeNode(9);
            TreeNode c = new TreeNode(20);
            TreeNode d = new TreeNode(15);
            TreeNode e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            Console.WriteLine(SumOfLeftLeaves(a));
        }
        static int SumOfLeftLeaves(TreeNode root)
        {
            int res = 0;
            if (root == null)
                return res;
            if (root.left != null && root.left.left == null && root.left.right == null)
                res += root.left.val;
            res += SumOfLeftLeaves(root.left);
            res += SumOfLeftLeaves(root.right);
            return res;
        }
    }
}

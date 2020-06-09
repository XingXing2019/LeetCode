//从跟节点角度考虑，如果抢劫跟节点，那么robRoot能得到的最大收益为跟节点的值，加上抢劫跟节点左子树的左右子树能获得最大收益，加上抢劫跟节点的右子树的左右子树能获得最大收益。
//如果不抢劫跟节点，那么notRobRoot能获得的最大收益为抢劫跟节点左子树获得的最大收益加上抢劫跟节点右子树获得的最大收益。
//递归调用时注意需要避免空引用异常。而且可以用一个字典记录在每个节点能获得的最大收益，以便减少重复计算。
using System;
using System.Collections.Generic;

namespace HouseRobberIII
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
            Console.WriteLine("Hello World!");
        }

        private Dictionary<TreeNode, int> record = new Dictionary<TreeNode, int>();
        public int Rob(TreeNode root)
        {
            if (root == null) return 0;
            if (record.ContainsKey(root)) return record[root];
            int robRoot = root.val;
            robRoot += root.left == null ? 0 : Rob(root.left.left) + Rob(root.left.right);
            robRoot += root.right == null ? 0 : Rob(root.right.left) + Rob(root.right.right);
            int notRobRoot = 0;
            notRobRoot += Rob(root.left) + Rob(root.right);
            var res = Math.Max(robRoot, notRobRoot);
            record[root] = res;
            return res;
        }
    }
}

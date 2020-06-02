//创建GetMaxDepth方法计算最大深度。如果node为空，则证明到达最底层，那么maxDepth为当前depth-1。
//递归查找左右子树的最大深度left和right。如果某个节点的left和right都等于最大深度，则该节点为答案。
//后续遍历就可以找到最低祖先。
using System;

namespace LowestCommonAncestorOfDeepestLeaves
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

        private int maxDepth;
        private TreeNode res;
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            GetMaxDepth(root, 0);
            return res;
        }
        private int GetMaxDepth(TreeNode node, int depth)
        {
            if (node == null) return depth - 1;
            int left = GetMaxDepth(node.left, depth + 1);
            int right = GetMaxDepth(node.right, depth + 1);
            maxDepth = Math.Max(maxDepth, depth);
            if (left == maxDepth && right == maxDepth)
                res = node;
            return Math.Max(left, right);
        }
    }
}

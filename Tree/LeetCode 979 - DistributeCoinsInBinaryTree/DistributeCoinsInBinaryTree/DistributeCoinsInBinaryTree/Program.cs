//后序遍历，将每个节点上多于1的硬币移动到他的父节点上。同时将当前节点值减一的绝对值加入res。
//如果当前节点为0，将-1移动到他的父节点上。相当于找父节点要了一个硬币。
using System;

namespace DistributeCoinsInBinaryTree
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
            
        }
        private int res;
        public int DistributeCoins(TreeNode root)
        {
            MoveCoin(root, null);
            return res;
        }
        private void MoveCoin(TreeNode node, TreeNode parent)
        {
            if (node == null) return;
            MoveCoin(node.left, node);
            MoveCoin(node.right, node);
            if (parent != null)
                parent.val += node.val - 1;
            res += Math.Abs(node.val - 1);
        }
    }
}

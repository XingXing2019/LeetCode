using System;
using System.Collections.Generic;

namespace FlipBinaryTreeToMatchPreorderTraversal
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            a.left = b;
            b.left = c;

            int[] voyage = {1, 3, 2};
            Console.WriteLine(FlipMatchVoyage(a, voyage));
        }

        public static IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            var res = new List<int>();
            int index = 0;
            bool canFlip = true;
            DFS(root, null, voyage, res, ref index, ref canFlip);
            return canFlip ? res : new List<int> {-1};
        }

        public static void DFS(TreeNode node, TreeNode parent, int[] voyage, List<int> res, ref int index, ref bool canFlip)
        {
            if (node == null || !canFlip) return;
            if (node.val != voyage[index])
            {
                if(parent?.left == null || parent.right == null || parent.left.val != voyage[index] && parent.right.val != voyage[index])
                {
                    canFlip = false;
                    return;
                }
                res.Add(parent.val);
                var temp = parent.left;
                parent.left = parent.right;
                parent.right = temp;
                node = parent.left.val == voyage[index] ? parent.left : parent.right;
            }
            index++;
            DFS(node.left, node, voyage, res, ref index, ref canFlip);
            DFS(node.right, node, voyage, res, ref index, ref canFlip);
        }
    }
}

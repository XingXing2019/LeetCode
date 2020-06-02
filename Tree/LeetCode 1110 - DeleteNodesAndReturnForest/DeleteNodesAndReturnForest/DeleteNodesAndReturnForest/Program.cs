//后序遍历树，遍历后如果发现当前节点值在删除列表中，则在其左右子树节点值不为空，且不再删除列表中时，将其左右子树节点加入结果，并使其左右子树节点为空。
//还需要检查当前节点的左右子树节点是否为空，并且在删除列表中。如果是，则需断开其左右子树节点。
//后续遍历结束后，如果根节点值不在删除列表中，还需将根节点人为加入res。
using System;
using System.Collections.Generic;

namespace DeleteNodesAndReturnForest
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
            TreeNode i = new TreeNode(9);
            TreeNode j = new TreeNode(10);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;
            d.left = h;
            d.right = i;
            e.left = j;
            int[] to_delete = { 1, 3, 4, 7 };
            Console.WriteLine(DelNodes(a, to_delete));
        }
        static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            var res = new List<TreeNode>();
            var delect = new Dictionary<int, int>();
            foreach (var num in to_delete)
                delect[num] = 1;
            ProOrder(root, res, delect);
            if (!delect.ContainsKey(root.val))
                res.Add(root);
            return res;
        }
        static void ProOrder(TreeNode node, List<TreeNode> res, Dictionary<int, int> delete)
        {
            if (node == null)
                return;            
            ProOrder(node.left, res, delete);
            ProOrder(node.right, res, delete);
            if (delete.ContainsKey(node.val))
            {
                if(node.left != null && !delete.ContainsKey(node.left.val))
                {
                    res.Add(node.left);
                    node.left = null;
                }
                if(node.right != null && !delete.ContainsKey(node.right.val))
                {
                    res.Add(node.right);
                    node.right = null;
                }               
            }
            if (node.left != null && delete.ContainsKey(node.left.val))
                node.left = null;
            if (node.right != null && delete.ContainsKey(node.right.val))
                node.right = null;
        }
    }
}

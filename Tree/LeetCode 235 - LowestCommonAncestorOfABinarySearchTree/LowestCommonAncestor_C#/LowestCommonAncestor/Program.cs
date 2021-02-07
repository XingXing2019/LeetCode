//因为是二叉搜索树，如果p，q值小于root的值，则证明p和q都在root左边，则返回递归调用root的左子树。
//如果p，q值大于root的值，则证明p和q都在root右边，则返回递归调用root的右子树。
//否则证明p和q都在root两边，则直接返回root。
using System;
using System.Collections.Generic;

namespace LowestCommonAncestor
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
            Console.WriteLine("Hello World!");
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor_DFS(root.left, p, q);
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor_DFS(root.right, p, q);
            return root;
        }

        public TreeNode LowestCommonAncestor_DFS(TreeNode root, TreeNode p, TreeNode q)
        {
            var pAncestors = new HashSet<TreeNode>();
            var qAncestors = new HashSet<TreeNode>();
            GetAncestors(root, pAncestors, p.val);
            GetAncestors(root, qAncestors, q.val);
            foreach (var ancestor in pAncestors)
                if (qAncestors.Contains(ancestor))
                    return ancestor;
            return null;
        }

        private void GetAncestors(TreeNode node, HashSet<TreeNode> ancestors, int val)
        {
            if (node == null) return;
            if(node.val > val)
                GetAncestors(node.left, ancestors, val);
            if(node.val < val)
                GetAncestors(node.right, ancestors, val);
            ancestors.Add(node);
        }
    }
}

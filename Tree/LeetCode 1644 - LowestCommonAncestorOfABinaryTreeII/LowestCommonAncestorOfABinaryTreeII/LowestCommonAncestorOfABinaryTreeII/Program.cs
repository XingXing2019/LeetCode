using System;
using System.Collections.Generic;

namespace LowestCommonAncestorOfABinaryTreeII
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

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var pAncestor = new List<TreeNode>();
            var qAncestor = new List<TreeNode>();
            var found = false;
            DFS(root, p, pAncestor, ref found);
            found = false;
            DFS(root, q, qAncestor, ref found);
            var set = new HashSet<TreeNode>();
            foreach (var node in pAncestor)
                set.Add(node);
            foreach (var node in qAncestor)
            {
                if (set.Contains(node))
                    return node;
            }
            return null;
        }

        static void DFS(TreeNode node, TreeNode target, List<TreeNode> ancestor, ref bool found)
        {
            if (node == null || found) return;
            if(node == target)
            {
                found = true;
                ancestor.Add(node);
            }
            DFS(node.left, target, ancestor, ref found);
            DFS(node.right, target, ancestor, ref found);
            if (found)
                ancestor.Add(node);
        }
    }
}

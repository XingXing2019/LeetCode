using System;
using System.Collections.Generic;

namespace InorderSuccessorInBST
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
            var a = new TreeNode(6);
            var b = new TreeNode(2);
            var c = new TreeNode(8);
            var d = new TreeNode(0);
            var e = new TreeNode(4);
            var f = new TreeNode(7);
            var g = new TreeNode(9);
            var h = new TreeNode(3);
            var i = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;
            e.left = h;
            e.right = i;

            Console.WriteLine(InorderSuccessor(a, h));
        }
        static TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            var nodes = new List<TreeNode>();
            DFS(root, p, nodes);
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i] == p)
                    return i == nodes.Count - 1 ? null : nodes[i + 1];
            }
            return null;
        }

        static void DFS(TreeNode node, TreeNode p, List<TreeNode> nodes)
        {
            if(node == null) return;
            DFS(node.left, p, nodes);
            nodes.Add(node);
            DFS(node.right, p, nodes);
        }
    }
}

using System;
using System.Collections.Generic;

namespace EncodeNaryTreeToBinaryTree
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {
        // Encodes an n-ary tree to a binary tree.
        public TreeNode Encode(Node root)
        {
            if (root == null)
                return null;
            var res = new TreeNode(root.val);
            if (root.children.Count == 0)
                return res;
            res.left = Encode(root.children[0]);
            var point = res.left;
            for (int i = 1; i < root.children.Count; i++)
            {
                point.right = Encode(root.children[i]);
                point = point.right;
            }
            return res;
        }

        // Decodes your binary tree to an n-ary tree.
        public Node Decode(TreeNode root)
        {
            if (root == null)
                return null;
            var res = new Node(root.val, new List<Node>());
            var cur = root.left;
            while (cur != null)
            {
                res.children.Add(Decode(cur));
                cur = cur.right;
            }
            return res;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Node(1);
            var b = new Node(3);
            var c = new Node(2);
            var d = new Node(4);
            var e = new Node(5);
            var f = new Node(6);
            a.children.Add(b);
            a.children.Add(c);
            a.children.Add(d);
            b.children.Add(e);
            b.children.Add(f);

            var codec = new Codec();
            var treeNode = codec.Encode(a);
            var node = codec.Decode(treeNode);
        }
    }
}

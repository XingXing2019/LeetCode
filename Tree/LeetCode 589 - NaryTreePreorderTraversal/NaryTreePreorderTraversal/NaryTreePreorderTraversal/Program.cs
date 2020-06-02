using System;
using System.Collections.Generic;

namespace NaryTreePreorderTraversal
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<int> Preorder(Node root)
        {
            var res = new List<int>();
            Pre(root, res);
            return res;
        }
        private void Pre(Node node, List<int> res)
        {
            if (node == null)
                return;
            res.Add(node.val);
            foreach (var child in node.children)
                Pre(child, res);
        }
    }
}

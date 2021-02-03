using System;
using System.Collections.Generic;

namespace NaryTreePostorderTraversal
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
        public IList<int> Postorder(Node root)
        {
            var res = new List<int>();
            Post(root, res);
            return res;
        }
        private void Post(Node node, List<int> res)
        {
            if (node == null)
                return;            
            foreach (var child in node.children)
                Post(child, res);
            res.Add(node.val);
        }
    }
}

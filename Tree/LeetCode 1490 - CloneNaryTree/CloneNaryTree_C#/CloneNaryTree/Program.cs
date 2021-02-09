//如果root为空直接返回null。否则复制root，并复制root的每一个child并加入clone的children。
using System;
using System.Collections.Generic;

namespace CloneNaryTree
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
            val = 0;
            children = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, List<Node> _children)
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
        static Node CloneTree(Node root)
        {
            if (root == null)
                return null;
            var clone = new Node(root.val);
            foreach (var child in root.children)
                clone.children.Add(CloneTree(child));
            return clone;
        }
    }
}

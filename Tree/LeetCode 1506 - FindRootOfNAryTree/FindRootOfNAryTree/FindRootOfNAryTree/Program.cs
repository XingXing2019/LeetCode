using System;
using System.Collections.Generic;

namespace FindRootOfNAryTree
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
        public Node FindRoot_HashSet(List<Node> tree)
        {
            var set = new HashSet<Node>();
            foreach (var node in tree)
            {
                foreach (var child in node.children)
                    set.Add(child);
            }
            foreach (var node in tree)
            {
                if (!set.Contains(node))
                    return node;
            }
            return null;
        }
        public Node FindRoot_O1Space(List<Node> tree)
        {
            int sum = 0, childernSum = 0;
            foreach (var node in tree)
            {
                sum += node.val;
                foreach (var child in node.children)
                    childernSum += child.val;
            }
            foreach (var node in tree)
            {
                if (node.val == sum - childernSum)
                    return node;
            }
            return null;
        }
    }
}

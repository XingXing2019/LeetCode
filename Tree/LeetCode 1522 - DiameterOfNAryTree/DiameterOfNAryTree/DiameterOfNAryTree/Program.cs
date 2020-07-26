using System;
using System.Collections.Generic;

namespace DiameterOfNAryTree
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

        private int diameter;
        public int Diameter(Node root)
        {
            GetMaxDepth(root);
            return diameter;
        }

        private int GetMaxDepth(Node node)
        {
            if (node == null) return 0;
            int max = 0, secondMax = 0;
            foreach (var child in node.children)
            {
                int path = GetMaxDepth(child);
                if (path > max)
                {
                    secondMax = max;
                    max = path;
                }
                else if (path > secondMax)
                    secondMax = path;
            }
            diameter = Math.Max(diameter, max + secondMax);
            return max + 1;
        }
    }
}

//深搜遍历树的每个节点，记录最大的高度。
using System;
using System.Collections.Generic;

namespace MaximumDepthOfN_aryTree
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
        static int MaxDepth(Node root)
        {
            if (root == null)
                return 0;
            int depth = 1;
            foreach (var child in root.children)
                depth = Math.Max(depth, MaxDepth(child) + 1);
            return depth;
        }
    }
}

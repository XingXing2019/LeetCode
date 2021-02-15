using System;
using System.Collections.Generic;

namespace LowestCommonAncestorOfABinaryTreeIII
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static Node LowestCommonAncestor(Node p, Node q)
        {
            var set = new HashSet<Node>();
            while (p != null)
            {
                set.Add(p);
                p = p.parent;
            }
            while (q != null)
            {
                if (set.Contains(q))
                    return q;
                q = q.parent;
            }
            return null;
        }
    }
}

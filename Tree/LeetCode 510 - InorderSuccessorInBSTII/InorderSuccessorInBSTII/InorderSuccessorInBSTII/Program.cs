using System;
using System.Collections.Generic;

namespace InorderSuccessorInBSTII
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;

        public Node()
        {
            
        }

        public Node(int num)
        {
            val = num;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Node(5);
            var b = new Node(3);
            var c = new Node(6);
            var d = new Node(2);
            var e = new Node(4);
            var f = new Node(1);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            b.parent = a;
            c.parent = a;
            d.left = f;
            d.parent = b;
            e.parent = b;
            f.parent = d;

            Console.WriteLine(InorderSuccessor(e));
        }
        static Node InorderSuccessor(Node x)
        {
            if (x.right != null)
            {
                x = x.right;
                while (x.left != null)
                    x = x.left;
                return x;
            }
            while (x.parent != null && x == x.parent.right)
                x = x.parent;
            return x.parent;
        }
    }
}

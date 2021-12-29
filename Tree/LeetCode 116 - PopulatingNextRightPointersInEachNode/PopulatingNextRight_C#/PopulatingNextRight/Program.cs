using System;
using System.Collections.Generic;

namespace PopulatingNextRight
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();
            if (root == null) return null;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                while (count != 0)
                {
                    count--;
                    var current = queue.Dequeue();
                    current.next = count == 0? null : queue.Peek();
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);                    
                }
            }
            return root;
        }
    }
}

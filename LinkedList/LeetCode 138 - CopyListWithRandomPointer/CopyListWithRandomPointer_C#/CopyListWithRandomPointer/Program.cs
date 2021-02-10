using System;
using System.Collections.Generic;

namespace CopyListWithRandomPointer
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static Node CopyRandomList(Node head)
        {
            var dict = new Dictionary<Node, Node>();
            var newHead = CopyNode(head, dict);
            var cur = head;
            var newCur = newHead;
            while (cur != null)
            {
                newCur.next = CopyNode(cur.next, dict);
                newCur.random = CopyNode(cur.random, dict);
                cur = cur.next;
                newCur = newCur.next;
            }
            return newHead;
        }

        static Node CopyNode(Node node, Dictionary<Node, Node> dict)
        {
            if (node == null) return null;
            if (dict.ContainsKey(node)) return dict[node];
            var newNode = new Node(node.val);
            dict[node] = newNode;
            return newNode;
        }
    }
}

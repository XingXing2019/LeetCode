using System;
using System.ComponentModel;

namespace InsertIntoASortedCircularLinkedList
{
    public class Node
    {
        public int val;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            next = null;
        }

        public Node(int _val, Node _next)
        {
            val = _val;
            next = _next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Node(5);
            var b = new Node(1);
            var c = new Node(3);

            a.next = b;
            b.next = c;
            c.next = a;

            int insertVal = 2;
            Console.WriteLine(Insert(a, insertVal));
        }
        static Node Insert(Node head, int insertVal)
        {
            if (head == null)
            {
                head = new Node(insertVal);
                head.next = head;
                return head;
            }
            var pointer = head;
            var visit = false;
            Node min = new Node(int.MaxValue), max = new Node(int.MinValue);
            while (!visit)
            {
                if (pointer.val < min.val) min = pointer;
                if (pointer.val >= max.val) max = pointer;
                pointer = pointer.next;
                if (pointer == head) visit = true;
            }
            if (insertVal >= max.val || insertVal <= min.val)
            {
                max.next = new Node(insertVal, min);
                return head;
            }
            var pre = head;
            while (pre.next != head)
                pre = pre.next;
            while (!(pointer.val >= insertVal && pre.val <= insertVal))
            {
                pre = pre.next;
                pointer = pointer.next;
                if (pointer == head)
                    visit = true;
            }
            pre.next = new Node(insertVal, pointer);
            return head;
        }
    }
}

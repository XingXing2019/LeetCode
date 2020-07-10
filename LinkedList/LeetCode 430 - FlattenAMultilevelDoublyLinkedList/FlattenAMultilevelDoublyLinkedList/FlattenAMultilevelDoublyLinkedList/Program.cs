//用栈辅助，如果一个节点的child不为null，就将他的next压栈，需要判断一下，不要将null压栈，并将他与他的child双向连起来，再将他的child设为null。
//如果指针指向null了，如果栈中有元素，就把栈顶弹出和当前指针相连。
using System;
using System.Collections.Generic;

namespace FlattenAMultilevelDoublyLinkedList
{
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node(int num) { val = num; }
        public Node() { }
        public Node(int _val, Node _prev, Node _next, Node _child)
        {
            val = _val;
            prev = _prev;
            next = _next;
            child = _child;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            var a = new Node(1);
            var b = new Node(2);
            var c = new Node(3);

            a.child = b;
            b.child = c;

            #endregion

            Console.WriteLine(Flatten(a));
        }
        static Node Flatten(Node head)
        {
            var stack = new Stack<Node>();
            var dummy = new Node();
            dummy.next = head;
            while (head != null)
            {
                if (head.child != null)
                {
                    if (head.next != null)
                        stack.Push(head.next);
                    head.next = head.child;
                    head.child.prev = head;
                    head.child = null;
                }
                if (head.next == null)
                {
                    if (stack.Count == 0)
                        break;
                    var node = stack.Pop();
                    node.prev = head;
                    head.next = node;
                }
                head = head.next;
            }
            return dummy.next;
        }
    }
}

using System;

namespace InsertGreatestCommonDivisorsInLinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            var point = head;
            while (point != null && point.next != null)
            {
                var gcd = GCD(point.val, point.next.val);
                var node = new ListNode(gcd, point.next);
                point.next = node;
                point = node.next;
            }
            return head;
        }

        public int GCD(int x, int y)
        {
            return y == 0 ? x : GCD(y, x % y);
        }
    }
}

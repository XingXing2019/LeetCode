using System;

namespace DoubleANumberRepresentedAsALinkedList
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

        public ListNode DoubleIt(ListNode head)
        {
            head = Reverse(head);
            ListNode dummy = new ListNode(), point = dummy;
            int cur = 0, car = 0;
            while (head != null)
            {
                cur = (head.val * 2 + car) % 10;
                car = (head.val * 2 + car) / 10;
                head = head.next;
                point.next = new ListNode(cur);
                point = point.next;
            }
            if (car != 0)
                point.next = new ListNode(car);
            return Reverse(dummy.next);
        }

        public ListNode Reverse(ListNode head)
        {
            var dummty = new ListNode(0, head);
            while (head != null && head.next != null)
            {
                var next = head.next;
                head.next = next.next;
                next.next = dummty.next;
                dummty.next = next;
            }
            return dummty.next;
        }
    }
}

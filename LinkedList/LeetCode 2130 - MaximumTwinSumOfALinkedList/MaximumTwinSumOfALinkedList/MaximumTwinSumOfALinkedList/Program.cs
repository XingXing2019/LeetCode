using System;

namespace MaximumTwinSumOfALinkedList
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

        public int PairSum(ListNode head)
        {
            var point = head;
            ListNode reversed = null;
            var len = 0;
            while (point != null)
            {
                reversed = new ListNode(point.val, reversed);
                point = point.next;
                len++;
            }
            var res = 0;
            for (int i = 0; i < len / 2; i++)
            {
                res = Math.Max(res, head.val + reversed.val);
                head = head.next;
                reversed = reversed.next;
            }
            return res;
        }
    }
}

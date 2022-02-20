using System;
using System.Collections.Generic;

namespace MergeNodesInBetweenZeros
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
            var head = Generate(new[] { 0, 3, 1, 0, 4, 5, 2, 0 });
            Console.WriteLine(MergeNodes(head));
        }
        public static ListNode MergeNodes(ListNode head)
        {
            ListNode p1 = head, dummy = new ListNode(), p2 = dummy;
            head = head.next;
            while (head != null)
            {
                while (head != null && head.val != 0)
                {
                    p1.val += head.val;
                    head = head.next;
                }
                p2.next = new ListNode(p1.val);
                p2 = p2.next;
                p1 = head;
                head = head.next;
            }
            return dummy.next;
        }

        public static ListNode Generate(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i], res);
            return res;
        }
    }
}

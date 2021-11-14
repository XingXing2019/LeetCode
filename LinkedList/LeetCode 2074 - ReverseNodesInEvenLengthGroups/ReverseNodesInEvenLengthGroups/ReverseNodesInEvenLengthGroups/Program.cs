using System;
using System.Collections.Generic;

namespace ReverseNodesInEvenLengthGroups
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
            Console.WriteLine(ReverseEvenLengthGroups(Generate(new[] { 1, 2, 3, 4, 5 })));
        }

        public static ListNode ReverseEvenLengthGroups(ListNode head)
        {
            int len = 1, count = 0;
            ListNode dummy = new ListNode(0, head), pre = dummy, point = head;
            while (point != null)
            {
                count++;
                point = point.next;
            }
            while (head != null)
            {
                head = pre.next;
                for (int i = 0; i < len && head != null; i++)
                {
                    head = head.next;
                    pre = pre.next;
                }
                count = Math.Max(0, count - len);
                len++;
                if (Math.Min(len, count) % 2 != 0) continue;
                for (int i = 0; i < len - 1 && head?.next != null; i++)
                {
                    var next = head.next;
                    head.next = next.next;
                    next.next = pre.next;
                    pre.next = next;
                }
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

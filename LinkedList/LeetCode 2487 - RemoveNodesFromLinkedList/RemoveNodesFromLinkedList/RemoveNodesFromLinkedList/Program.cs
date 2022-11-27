using System;

namespace RemoveNodesFromLinkedList
{
    internal class Program
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
        static void Main(string[] args)
        {
            var head = Generate(new[] { 7, 6, 2, 1 });
            Console.WriteLine(RemoveNodes(head));
        }

        public static ListNode RemoveNodes(ListNode head)
        {
            var reversed = Reverse(head);
            var dummy = new ListNode(0, reversed);
            var max = reversed.val;
            var point = dummy;
            while (reversed != null)
            {
                if (max > reversed.val)
                    point.next = reversed.next;
                else
                    point = point.next;
                max = Math.Max(max, reversed.val);
                reversed = reversed.next;
            }
            return Reverse(dummy.next);
        }

        public static ListNode Reverse(ListNode head)
        {
            var dummy = new ListNode(0, head);
            while (head.next != null)
            {
                var next = head.next;
                head.next = next.next;
                next.next = dummy.next;
                dummy.next = next;
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

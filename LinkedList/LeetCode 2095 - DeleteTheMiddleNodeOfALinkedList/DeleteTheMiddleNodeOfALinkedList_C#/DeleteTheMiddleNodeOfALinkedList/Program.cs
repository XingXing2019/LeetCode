
using System;

namespace DeleteTheMiddleNodeOfALinkedList
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
            var head = Generate(new[] { 1, 2, 3 });
            Console.WriteLine(DeleteMiddle(head));
        }

        public static ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode pre = new ListNode(0, head), slow = head, fast = head;
            while (fast != null)
            {
                fast = fast.next;
                if (fast == null) break;
                fast = fast.next;
                slow = slow.next;
                pre = pre.next;
            }

            pre.next = slow.next;
            return head;
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

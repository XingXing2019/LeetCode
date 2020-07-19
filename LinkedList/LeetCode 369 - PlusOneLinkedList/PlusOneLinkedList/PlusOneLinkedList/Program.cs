using System;

namespace PlusOneLinkedList
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
    class Program
    {
        static void Main(string[] args)
        {
            var head = Build(new[] {9, 9, 9});
            Console.WriteLine(PlusOne(head));
        }
        static ListNode PlusOne(ListNode head)
        {
            var reversed = Reverse(head);
            var dummyHead = reversed;
            int car = 1;
            while (reversed != null)
            {
                int cur = (reversed.val + car) % 10;
                car = (reversed.val + car) / 10;
                reversed.val = cur;
                if(car == 0 || reversed.next == null) break;
                reversed = reversed.next;
            }
            if (car != 0)
                reversed.next = new ListNode(car);
            return Reverse(dummyHead);
        }

        static ListNode Reverse(ListNode head)
        {
            ListNode res = null;
            while (head != null)
            {
                res = new ListNode(head.val){next = res};
                head = head.next;
            }
            return res;
        }

        static ListNode Build(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                head = new ListNode(nums[i]) {next = head};
            return head;
        }
    }
}

//找到翻转点的前一节点(pre)。将翻转点设为start，其下一节点设为then。将start的下一节点设为then的下一节点。
//将then下一节点设为pre的下一节点。
//将pre的下一节点设为then。循环此操作。
using System;

namespace ReverseLinkedListII
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
            ListNode head = CreateList(new int[] { 1, 2, 3, 4, 5 });
            PrintList(head);
            Console.WriteLine("");
            ListNode res1 = ReverseBetween_ReverseInPlace(head, 2, 4);
            PrintList(res1);
        }
        static ListNode CreateList(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                head = new ListNode(nums[i]) { next = head };
            }
            return head;
        }
        static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + "->");
                head = head.next;
            }
            Console.Write("null");
        }
        static ListNode ReverseBetween_ReverseInPlace(ListNode head, int m, int n)
        {
            if (head == null)
                return null;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode pre = null;
            for (int i = 0; i < m - 1; i++)
            {
                pre = head;
                head = head.next;
            }
            ListNode start = pre.next;
            for (int i = 0; i < n - m; i++)
            {
                ListNode then = start.next;
                start.next = then.next;
                then.next = pre.next;
                pre.next = then;
            }
            return dummy.next;
        }

        public ListNode ReverseBetween_CreateNewNode(ListNode head, int m, int n)
        {
            ListNode pre = new ListNode(0, head), dummy = pre;
            ListNode pointer = head, reverse = null, last = null;
            for (int i = 1; i < m; i++)
            {
                pre = pre.next;
                pointer = pointer.next;
            }
            for (int i = 0; i <= n - m; i++)
            {
                reverse = new ListNode(pointer.val, reverse);
                if (last == null) last = reverse;
                pointer = pointer.next;
            }
            pre.next = reverse;
            last.next = pointer;
            return dummy.next;
        }
    }
}

using System;

namespace ReverseLinkedList
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
            ListNode list = CreateList(new int[] { 1, 2, 3, 4, 5 });
            ListNode res = ReverseLinkedList(list);
            PrintList(list);
            Console.WriteLine("");
            PrintList(res);
        }
        static ListNode CreateList(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                head = new ListNode() { val = nums[i], next = head };
            }
            return head;
        }
        static void PrintList(ListNode nodeHead)
        {
            while (nodeHead != null)
            {
                Console.Write(nodeHead.val + "->");
                nodeHead = nodeHead.next;
            }
        }
        static ListNode ReverseLinkedList(ListNode list)
        {
            ListNode res = null;
            while (list != null)
            {
                res = new ListNode() { val = list.val, next = res };
                list = list.next;
            }
            return res;
        }
        public ListNode ReverseList_ReverseInPlace(ListNode head)
        {
            if (head == null) return null;
            ListNode pre = new ListNode(0, head);
            while (head.next != null)
            {
                var post = head.next;
                head.next = post.next;
                post.next = pre.next;
                pre.next = post;
            }
            return pre.next;
        }
    }
}

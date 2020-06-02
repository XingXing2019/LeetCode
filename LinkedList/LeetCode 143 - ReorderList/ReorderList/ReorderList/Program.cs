//建立方法翻转链表。设立两个节点l1和l2分别指向原始链表和翻转后的链表头。
//遍历链表使两个链表的各个节点交叉相连。遍历中，需要设立l1的下一节点为tem节点作为辅助。
//建立快慢指针从而找到链表中点，人为使链表的前后两部分断开。
using System;

namespace ReorderList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
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
        static void Main(string[] args)
        {
            ListNode head = CreateList(new int[] { });
            ReorderList(head);
            PrintList(head);
        }
        static void ReorderList(ListNode head)
        {
            ListNode l1 = head;
            ListNode l2 = ReverseList(head);
            while (l1 != null)
            {
                ListNode tem = l1.next;
                l1.next = l2;
                l2 = l2.next;
                l1 = l1.next;
                l1.next = tem;
                l1 = l1.next;
            }
            ListNode slow = head;
            ListNode fast = head;
            if(head != null)
            {
                while (fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next;
                    fast = fast.next;
                }
                slow.next = null;
            }
        }
        static ListNode ReverseList(ListNode head)
        {
            ListNode res = null;
            while (head != null)
            {
                res = new ListNode(head.val) { next = res };
                head = head.next;
            }
            return res;
        }
    }
}

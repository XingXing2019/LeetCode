//计算链表长度len。如为奇则之后循环次数times为len/2，如为偶则之后循环次数times为len/2-1。
//设立dummy节点其下一节点指向head。设立pre节点使其指向dummy。设立point节点指向head。首先让pre和point都前进一位。
//循环times次，每次循环可调整一个奇节点的位置使其与pre相连。可设立point的下一节点为tem节点作为辅助。
//每次调整位置后是pre和point前进一位。
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OddEvenLinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = CreateList(new int[] {});
            //PrintList(head);
            ListNode res = OddEvenList(head);
            PrintList(res);
        }

        private int GetLen(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;
            int len = GetLen(head);
            int times = (len & 1) == 0 ? len / 2 - 1 : len / 2;
            var dummyHead = new ListNode(0) {next = head};
            var pre = head;
            var point = head.next;
            for (int i = 0; i < times; i++)
            {
                var temp = point.next;
                point.next = temp.next;
                temp.next = pre.next;
                pre.next = temp;
                pre = pre.next;
                point = point.next;
            }
            return dummyHead.next;
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
        
    }
}

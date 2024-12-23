﻿//建立方法翻转链表。设立两个节点l1和l2分别指向原始链表和翻转后的链表头。
//遍历链表使两个链表的各个节点交叉相连。遍历中，需要设立l1的下一节点为tem节点作为辅助。
//建立快慢指针从而找到链表中点，人为使链表的前后两部分断开。
using System;
using System.Collections.Generic;

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
            ListNode head = CreateList(new int[] {1, 2, 3, 4});
            ReorderList_Array(head);
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
        
        static void ReorderList_Array(ListNode head)
        {
            if(head == null) return;
            var l1 = head;
            var l2 = ReverseList(head);
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            var reorder = new ListNode[count];
            for (int i = 0; i < reorder.Length; i++)
            {
                if (i % 2 == 0)
                {
                    reorder[i] = l1;
                    l1 = l1.next;
                }
                else
                {
                    reorder[i] = l2;
                    l2 = l2.next;
                }
            }
            for (int i = 1; i < reorder.Length; i++)
                reorder[i - 1].next = reorder[i];
            reorder[reorder.Length - 1].next = null;
            head = reorder[0];
        }
        static void ReorderList_List(ListNode head)
        {
            if (head == null) return;
            var nodes = new List<ListNode>();
            var pointer = head;
            while (pointer != null)
            {
                nodes.Add(pointer);
                pointer = pointer.next;
            }
            int li = 0, hi = nodes.Count - 1;
            while (li < hi)
            {
                nodes[li++].next = nodes[hi];
                nodes[hi--].next = nodes[li];
            }
            nodes[li].next = null;
        }
    }
}

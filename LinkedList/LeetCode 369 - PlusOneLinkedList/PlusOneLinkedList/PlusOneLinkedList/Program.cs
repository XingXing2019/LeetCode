//利用Stack先进后出的特点将head中的nodes存入栈中。
//在用过计算car和cur将栈中的node值更新。
//最后要根据car判断一下是否需要再给res加一位。
using System;
using System.Collections.Generic;

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

        static ListNode PlusOne_Stack(ListNode head)
        {
            var nodes = new Stack<ListNode>();
            while (head != null)
            {
                nodes.Push(head);
                head = head.next;
            }
            ListNode res = null;
            int car = 1;
            while (nodes.Count != 0)
            {
                int cur = (nodes.Peek().val + car) % 10;
                car = (nodes.Peek().val + car) / 10;
                nodes.Peek().val = cur;
                res = new ListNode(nodes.Pop().val) {next = res};
            }
            if (car != 0)
                res = new ListNode(1) {next = res};
            return res;
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

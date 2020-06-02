//先获得两个链表的长度，在较短的链表前面补0使其与长链表对其。
//利用栈先进后出原理储存链表数值。
//依次从栈顶读取数据进行计算，用current和carry分别记录数字和进位
//使用current生成新链表。循环结束后在链表头人为利用carry添加头结点。
using System;
using System.Collections;

namespace AddTwoNumbersII
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = CreatList(new int[] { 4, 7, 5, 8, 5 });
            ListNode l2 = CreatList(new int[] { 4, 6, 4, 8, 5 });
            ListNode res = AddTwoNumbers(l1, l2);
            Print(res);
        }
        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int lenL1 = GetLen(l1);
            int lenL2 = GetLen(l2);
            if (lenL1 > lenL2)
                l2 = ExtendList(l2, lenL1, lenL2);
            else
                l1 = ExtendList(l1, lenL2, lenL1);           
            Stack l1Stack = new Stack();
            Stack l2Stack = new Stack();
            while (l1 != null)
            {
                l1Stack.Push(l1.val);
                l2Stack.Push(l2.val);
                l1 = l1.next;
                l2 = l2.next;
            }
            ListNode res = null;
            int current = 0;
            int carry = 0;
            while (l1Stack.Count != 0)
            {
                current = ((int)l1Stack.Peek() + (int)l2Stack.Peek() + carry) % 10;
                carry = ((int)l1Stack.Pop() + (int)l2Stack.Pop() + carry) / 10;
                res = new ListNode(current) { next = res };  
            }
            res = new ListNode(carry) { next = res };
            if (res.val != 0)
                return res;
            else
                return res.next;
        }
        static int GetLen(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }
        static ListNode ExtendList(ListNode head, int longLen, int shortLen)
        {
            for (int i = 0; i < longLen - shortLen; i++)
            {
                head = new ListNode(0) { next = head };
            }
            return head;
        }
        static ListNode CreatList(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                head = new ListNode(nums[i]){ next = head };
            }
            return head;
        }
        static void Print(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
    }
}

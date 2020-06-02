//对两个节点的每位数相加，把结果的各位存入新的节点，十位带入下一次相加。循环进行直到两个节点都为空， 如有一节点先为空，人为在其后连接一个0值节点。
//最后一次相加如有进位，人为在其后连接一个1值节点。
using System;
using System.Diagnostics;

namespace AddTwoNumbers
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }     
    class Program
    {
        static void Main(string[] args)
        {
          
        }
        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode res = dummy;
            int x = 0;
            int y = 0;
            while (true)
            {
                x = (l1.val + l2.val + y) % 10;
                y = (l1.val + l2.val + y) / 10;
                dummy.next = new ListNode(x);
                l1 = l1.next;
                l2 = l2.next;
                dummy = dummy.next;
                if (l1 == null && l2 == null)
                    break;
                if (l1 == null)
                    l1 = new ListNode(0);
                if (l2 == null)
                    l2 = new ListNode(0);
            }
            if (y == 1)
                dummy.next = new ListNode(y);
            return res.next;
        }
    }
}
